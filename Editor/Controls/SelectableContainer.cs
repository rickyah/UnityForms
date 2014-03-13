using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms.Controls
{

    public abstract class SelectableContainer : ControlContainer
    {
        public SelectableContainer() 
        {
            SelectedIndex = 0;
        }  

        public event EventHandler SelectedIndexChanged = delegate {};

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {   
                var oldSelectedIndex = _selectedIndex;
                _selectedIndex = value;
                
                if (value != oldSelectedIndex)
                {
                    SelectedIndexChanged(this, EventArgs.Empty);
                }
                
            }
        }

        public Control SelectedElement
        {
            get
            {
                return _childs[SelectedIndex];
            }
        }

        public override void AddChilds(params Control[] childControls)
        {
            
            foreach(var child in childControls)
            {
                AddChilds(child);
            }

            SelectedIndex = 0;
            
            Enabled = (_childs.Count > 0);
        }
        

        protected int _selectedIndex;
    }
}