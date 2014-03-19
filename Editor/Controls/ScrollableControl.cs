using UnityEngine;
using UnityForms;

namespace UnityForms
{
    public abstract class ScrollableControl : Panel
    {
        Vector2 _scrollPosition = new Vector2();

        protected override void OnPaint()
        {
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
        }

        protected override void OnPaintFinish()
        {
            GUILayout.EndScrollView();
        }
    }
}
