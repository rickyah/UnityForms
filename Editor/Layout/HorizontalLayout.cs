using System;
using UnityEngine;
using UnityForms.Layouts;

namespace UnityForms.Layouts
{
    public class HorizontalLayout : Layout
    {
        public HorizontalLayout()
        {
        }

        protected override void StartLayoutAbstractMethod()
        {
            GUILayout.BeginHorizontal();
        }

        protected override void EndLayoutAbstractMethod()
        {
            GUILayout.EndHorizontal();
        }
    }

    public class HorizontalLayoutOutlined : HorizontalLayout
    {
        protected override void StartLayoutAbstractMethod()
        {
            GUILayout.BeginHorizontal(GUI.skin.box);
        }
    }
}