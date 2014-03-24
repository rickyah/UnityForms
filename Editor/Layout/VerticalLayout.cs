using UnityEngine;
using UnityForms.Layouts;

namespace UnityForms.Layouts
{
    public class VerticalLayout : Layout
    {
        protected override void StartLayoutAbstractMethod()
        {
            GUILayout.BeginVertical();
        }

        protected override void EndLayoutAbstractMethod()
        {
            GUILayout.EndVertical();
        }
    }

    public class VerticalLayoutOutlined : VerticalLayout
    {
        protected override void StartLayoutAbstractMethod()
        {
            GUILayout.BeginVertical(GUI.skin.box);
        }
    }
}