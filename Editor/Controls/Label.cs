using UnityEngine;

namespace UnityForms
{
    public class Label : Control
    {
        public Label(string text) : base(text)
        {
        }

        public Label(string text, Control parent) : base(text, parent)
        {
        }

        protected override void OnPaint()
        {
            GUILayout.Label(this.Text);
        }
    }
}