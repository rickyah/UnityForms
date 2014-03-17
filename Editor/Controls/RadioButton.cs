using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms
{
    
    public class RadioButton : Control
    {
        public event EventHandler CheckedChanged;
        
        protected virtual void OnCheckedChanged()
        {
            if (CheckedChanged != null)
            {
                CheckedChanged(this, EventArgs.Empty);
            }
        }
        
        public RadioButton(string text) : base(text)
        {
        }
        

        public RadioButton(string text, Control parent) : base(text, parent)
        {
        }
        

        public RadioButton()
        {
        }
        
        bool _checked;
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                var previousValue = _checked;
                _checked = value;
                
                if (previousValue != _checked)
                {
                    OnCheckedChanged();    
                }
                
            }
        }
        
        internal void SetChecked(bool value)
        {
            _checked = value;
        }
        
        protected override void OnPaint()
        {
            Checked = GUILayout.Toggle(Checked, Text, EditorStyles.radioButton);
        }
    }
    
}