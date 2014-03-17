using System;
using UnityEngine;

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