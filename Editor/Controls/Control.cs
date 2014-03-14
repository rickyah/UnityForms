using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms.Controls
{
    public class ControlEventArgs : EventArgs
    {
        public ControlEventArgs(Control control)
        {
            this.Control = control;
        }
        
        public Control Control
        {
            get; private set;
        }
    }
    
    public abstract class Control
    {
        #region Initialization
        public Control(string text):this()
        {
            Text = text;
        }
        
        public Control(string text, Control parent) :this(text)
        {
            SetParent(parent);
        }
        
        public Control()
        {
            Enabled = true;
            Controls = new ControlCollection();
           
            BindEvents();
        }
        
        protected virtual void BindEvents()
        {
            Controls.Added += (sender, e) => {
                OnControlAdded(new ControlEventArgs(e.Object));
            };
            
            Controls.Removed += (sender, e) => {
                OnControlRemoved(new ControlEventArgs(e.Object));
            };
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
        
        public Control Parent {get; private set;}
        
        public ControlCollection Controls {get; private set;}
        #endregion
        
        #region Public Methods
        public void SetParent(Control parent)
        {
            Parent = parent;
        }
        
        public string Text {get; set;}
        
        public bool Enabled { get; set; }
        
        public void Paint()
        {
            GUI.enabled = Enabled;

            this.OnPaint();
            
            foreach(var control in Controls)
            {
                control.Paint();
            }
            
            GUI.enabled = true;
        }
        #endregion
        
        #region Abstract Method Pattern
                
        protected virtual void OnPaint()
        {
            // blank
        }
        #endregion
    }
}