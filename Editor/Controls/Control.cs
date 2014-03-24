using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;
using UnityEditor.VersionControl;


namespace UnityForms
{
    public struct Size
    {
        int _height;
        int _width;

        public Size(int height, int width)
        {
            _height = height < 0 ? 0 : height;
            _width = width < 0 ? 0 : width;
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = (value < 0) ? 0 : value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = (value < 0) ? 0 : value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (Height * Width <= 0);
            }
        }
    }

    public abstract class Control
    {
        #region Initialization

        public Control(string text) : this()
        {
            Text = text;
        }

        public Control(string text, Control parent) : this(text)
        {
            SetParent(parent);
        }

        public Control()
        {
            Enabled = true;
            Controls = new ControlCollection();

            BindChildControlEvents();
        }

        protected virtual void BindChildControlEvents()
        {
            Controls.Added += (sender, e) =>
            {
                OnControlAdded(new ControlEventArgs(e.Object));
            };
            
            Controls.Removed += (sender, e) =>
            {
                OnControlRemoved(new ControlEventArgs(e.Object));
            };
        }

        protected GUILayoutOption[] ComputeLayoutOptions()
        {
            var options = new List<GUILayoutOption>();
            
            if (!Size.IsEmpty)
            {
                options.Add(GUILayout.Width(this.Size.Width));
                options.Add(GUILayout.Height(this.Size.Height));
            }
            
            return options.ToArray();
        }

        #endregion

        #region Events

        public event EventHandler<ControlEventArgs> ControlAdded;

        public event EventHandler<ControlEventArgs> ControlRemoved;

        #endregion

        #region OnEvents

        protected virtual void OnControlAdded(ControlEventArgs args)
        {
            if (ControlAdded != null)
            {
                ControlAdded(this, args);
            }
        }

        protected virtual void OnControlRemoved(ControlEventArgs args)
        {
            if (ControlRemoved != null)
            {
                ControlRemoved(this, args);
            }
        }

        #endregion

        #region Properties

        public Control Parent { get; private set; }

        public ControlCollection Controls { get; private set; }

        #endregion

        #region Public Methods

        public void SetParent(Control parent)
        {
            Parent = parent;
        }

        public string Text { get; set; }

        public bool Enabled { get; set; }

        public Size Size { get; set; }

        public void Paint()
        {
            GUI.enabled = Enabled;

            this.OnPaint();
            
            foreach (var control in Controls)
            {
                control.Paint();
            }
            
            this.OnPaintFinish();
            
            GUI.enabled = true;
        }

        #endregion

        #region Abstract Method Pattern

        public event EventHandler Click;
        /*
        public event EventHandler<MouseEventArgs> MouseDown;
        public event EventHandler<MouseEventArgs> MouseUp;

        protected virtual void OnMouseDown(MouseEventArgs args)
        {
            if (MouseDown != null)
                MouseDown(this, args);
        }

        protected virtual void OnMouseUp(MouseEventArgs args)
        {
            if (MouseUp != null)
                MouseUp(this, args);
            
        }
        */
        protected virtual void OnClick()
        {
            if (Click != null)
                Click(this, EventArgs.Empty);
        }
        /*
        private readonly int _unityControlId;

        protected void ProcessEvents()
        {
            if (!Enabled)
                return;
           
            var evt = Event.current;
            var rect = GUILayoutUtility.GetLastRect();
            
            switch (evt.type)
            {
                case EventType.MouseDown:
                    if (rect.Contains(evt.mousePosition))
                    {
                        this.OnMouseDown(new MouseEventArgs(evt.button, evt.mousePosition, evt.clickCount));
                    }
                    
                    break;
                case EventType.MouseUp:
                    if (rect.Contains(evt.mousePosition))
                    {
                        this.OnMouseUp(new MouseEventArgs(evt.button, evt.mousePosition, evt.clickCount));
                        this.OnClick();
                    }
                    
                    break;
                case EventType.MouseMove:
                    break;
                case EventType.KeyDown:
                    break;
                case EventType.KeyUp:
                    break;
            }
            
           
        }
        */
        protected virtual void OnPaint()
        {
            // blank
        }

        protected virtual void OnPaintFinish()
        {
            // blank
        }

        protected T GetParentControl<T>() where T : Control
        {
            if (typeof(T) == this.GetType())
            {
                return this as T;
            }
            
            if (Parent == null)
            {
                return null;
            }
            
            return Parent.GetParentControl<T>();
        }

        #endregion
    }
}