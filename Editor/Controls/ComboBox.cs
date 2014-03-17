using System.Linq;
using UnityEditor;

namespace UnityForms
{
    public class ComboBox : ListControl
    {
        public ComboBox()
        {
        }
        
        public ComboBox(string text) : base(text)
        {
        }
        
        public ComboBox(string text, Control parent) : base(text, parent)
        {
        }
        
        protected override void BindEvents()
        {
            base.BindEvents();
            
            Items.Changed += (sender, args) => {
                this.Enabled = Items.Count > 0;
            };
        }
        
        protected override void OnPaint()
        {
            SelectedIndex = EditorGUILayout.Popup(SelectedIndex, Items.Select(i => i.ToString()).ToArray());
        }
    }
}