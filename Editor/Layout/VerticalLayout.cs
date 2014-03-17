using UnityEngine;

namespace UnityForms.Layouts
{
    public class VerticalLayout : Layout
    {
        public VerticalLayout()
        {
        }

        public VerticalLayout(GUIStyle style) : base(style)
        {
        }

        protected override void StartLayoutAbstractMethod(GUIStyle style)
        {
            GUILayout.BeginVertical(style);
        }

        protected override void EndLayoutAbstractMethod()
        {
            GUILayout.EndVertical();
        }
    }
}