using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms
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
    
}