using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms.Controls
{
    
    public class Label : Control
    {
        protected override void OnPaint()
        {
            GUILayout.Label(this.Text);
        }
    } 
    
}