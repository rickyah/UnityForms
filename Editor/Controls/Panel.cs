using UnityEngine;
using UnityForms;
using System;

namespace UnityForms
{
    public class Panel : Control
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
        }

        protected override void OnPaintFinish()
        {
            if (Layout != null)
            {
                Layout.EndLayout();
            }
        }
    }
}
