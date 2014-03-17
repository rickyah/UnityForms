using System;

namespace UnityForms
{
    public abstract class ArrangedElementsControl<TCollection, TItem> : Control where TCollection : GenericObjectCollection<TItem> where TItem : new()
    {
        protected int _selectedIndex = 0;

        public event EventHandler SelectedIndexChanged;

        TCollection items;

        public TCollection Items
        {
            get
            {
                return items;
            }
            protected set
            {
                items = value;
                BindItemEvents();
            }
        }

        private void InitDataStructures()
        {
            _selectedIndex = 0;
        }

        protected virtual void BindItemEvents()
        {
            Items.Added += (s, a) =>
        {
                
            };
            
            Items.Removed += (s, a) => {
                _selectedIndex = 0;
                
            };
            
            
            Items.Cleared += (s, a) => {
                _selectedIndex = 0;
            };
            
                
        }     

        public ArrangedElementsControl(string text) : base(text)
        {
            InitDataStructures();;
        }
        

        public ArrangedElementsControl(string text, Control parent) : base(text, parent)
        {
            InitDataStructures();
        }
        
        public ArrangedElementsControl()
        {
            InitDataStructures();
        }
        
        protected virtual void OnSelectedIndexChanged(int oldValue, int newValue)
        {
            if (newValue != oldValue)
            {
                if(SelectedIndexChanged != null)
                    SelectedIndexChanged(this, EventArgs.Empty);
            } 
        }
        
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {   
                var oldSelectedIndex = _selectedIndex;
                _selectedIndex = value;
                OnSelectedIndexChanged(oldSelectedIndex, value);
                
            }
        }

        public TItem SelectedItem
        {
            get
            {
                return Items[SelectedIndex];
            }
        }
    }
}