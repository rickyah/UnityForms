using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms.Controls
{
    public abstract class Control
    {
        public Control()
        {
            Enabled = true;
        }
        
        public ControlContainer Parent {get; internal set;}
        
        public void SetParent(ControlContainer parent)
        {
            Parent = parent;
        }
        
        public string Text {get; set;}
        public bool Enabled { get; set; }
        
        protected virtual void OnPaint()
        {
            //blank
        }
        
        public void Paint()
        {
            GUI.enabled = Enabled;

            OnPaint();
            
            GUI.enabled = true;
        }
    }
    
    public class Label : Control
    {
        protected override void OnPaint()
        {
            GUILayout.Label(this.Text);
        }
    } 
    
    public class RadioButton : Control
    {
        
    }
    
    public class ControlContainer : Control
    {
        public ControlContainer()
        {
            _childs = new List<Control>();
        }
        
        public virtual void AddChilds(params Control[] childControls)
        {
            foreach( var ctr in childControls) 
                ctr.SetParent(this);
            
            _childs.AddRange(childControls);
        }

        public IEnumerable<Control> Childs { get { return _childs; } }
        
        protected override void OnPaint()
        {
            foreach(var child in Childs)
            {
                child.Paint(); 
            }
        }
        
        protected List<Control> _childs;
    }

    public class RadioButtonGroup : SelectableContainer
    {       
        List<RadioButton> _radioButtonsInGroup;
        
        public RadioButtonGroup()
        {
            _radioButtonsInGroup = new List<RadioButton>();
        }
        
        public override void AddChilds(params Control[] childControls)
        {
            foreach(var child in childControls)
            {
                if (child is RadioButton)
                    _radioButtonsInGroup.Add(child as RadioButton);    
            }
            
            base.AddChilds(childControls);
        }
        
        protected override void OnPaint()
        {
            for (int idx=0; idx < _radioButtonsInGroup.Count; ++idx)
            {
                
                if(EditorGUILayout.Toggle(SelectedIndex == idx, EditorStyles.radioButton))
                {
                    SelectedIndex = idx;
                }
                
                _childs[idx].Paint();
            }
        }   
    }
}