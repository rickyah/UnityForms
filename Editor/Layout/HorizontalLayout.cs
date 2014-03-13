using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;
using UnityEditor;

namespace UnityForms.Layouts
{
    public class HorizontalLayout : IDisposable
    {
        public HorizontalLayout(GUIStyle style)
        {
            GUILayout.BeginHorizontal(style);
        }

        public HorizontalLayout()
        {
            GUILayout.BeginHorizontal();
        }

        public void Dispose()
        {
            GUILayout.EndHorizontal();
        }
        
    }
    
}