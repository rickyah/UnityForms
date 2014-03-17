namespace UnityForms
{
    public abstract class ListControl : ArrangedElementsControl<ObjectCollection, object>
    {
        public ListControl(string text) : base(text)
        {
        }

        public ListControl(string text, Control parent) : base(text, parent)
        {
        }

        public ListControl()
        {
            Items = new ObjectCollection();
        }
    }
}