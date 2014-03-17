using System;
using UnityEngine;

namespace UnityForms.Layouts
{
    public class HorizontalLayout : Layout
    {
        public HorizontalLayout()
        {
        }

        public HorizontalLayout(GUIStyle style) : base(style)
        {
        }

        protected override void StartLayoutAbstractMethod(GUIStyle style)
        {
            GUILayout.BeginHorizontal(style);
        }

        protected override void EndLayoutAbstractMethod()
        {
            GUILayout.EndHorizontal();
        }
    }
}