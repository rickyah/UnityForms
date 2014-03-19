using UnityEngine;

namespace UnityForms
{
    public class Button : ButtonBase
    {
        public Button(string text) : base(text)
        {
        }

        public Button(string text, Control parent) : base(text, parent)
        {
        }

        public Button()
        {
        }

        protected override void OnPaint()
        {
            if (GUILayout.Button(this.Text, this.ComputeLayoutOptions()))
            {
                this.OnClick();
            }
        }
    }
}