using UnityEngine;

namespace UnityForms
{
    
    public class Label : Control
    {
        protected override void OnPaint()
        {
            GUILayout.Label(this.Text);
        }
    } 
}