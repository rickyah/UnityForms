using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms
{
    public abstract class ButtonBase : Control
    {
        public ButtonBase(string text) : base(text)
        {
        }

        public ButtonBase(string text, Control parent) : base(text, parent)
        {
        }

        public ButtonBase()
        {
        }
        
    }
    
}