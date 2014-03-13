using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;
using UnityEditor;

namespace UnityForms.Layouts
{
    
    public class VerticalLayout : IDisposable
    {

        public VerticalLayout(GUIStyle style)
        {
            GUILayout.BeginVertical(style);
        }
        
        public VerticalLayout()
        {
            GUILayout.BeginVertical();
        }

        public void Dispose()
        {
            GUILayout.EndVertical();
        }
        
    }
    
}