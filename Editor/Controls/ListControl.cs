using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UnityForms.Controls
{
    public abstract class ListControl : ArrangedElementsControl<ObjectCollection, object>
    {
        public ListControl(string text) : base(text)
        {
        }
        

        public ListControl(string text, Control parent) : base(text, parent)
        {
        }
        
        public ListControl() 
        {
            Items = new ObjectCollection();
        }    
    }
}