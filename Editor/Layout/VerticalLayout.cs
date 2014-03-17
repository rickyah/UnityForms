using UnityEngine;

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