using UnityEngine;
using UnityForms;

namespace UnityForms
{
    public class Panel : ScrollableControl
    {
        public UnityForms.Layouts.Layout Layout { get; set; }

        public Panel() : this(null)
        {
        }

        public Panel(UnityForms.Layouts.Layout layout)
        {
            this.Layout = layout;
        }

        protected override void OnPaint()
        {
            if (Layout != null)
            {
                Layout.BeginLayout();
            }
            
            base.OnPaint();
            
            if (Layout != null)
            {
                Layout.EndLayout();
            }
        }
    }
}