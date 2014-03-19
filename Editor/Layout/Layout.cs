using UnityEngine;
using System;

namespace UnityForms.Layouts
{
    public abstract class Layout : IDisposable
    {
        GUIStyle _style;
        bool _isInLayout;

        public Layout() : this(GUIStyle.none)
        {
            
        }

        public Layout(GUIStyle style)
        {
            _style = style;
        }

        public void BeginLayout()
        {
            StartLayoutAbstractMethod(_style);
            _isInLayout = true;
        }

        public void EndLayout()
        {
            EndLayoutAbstractMethod();
            _isInLayout = false;
        }

        protected abstract void StartLayoutAbstractMethod(GUIStyle style);

        protected abstract void EndLayoutAbstractMethod();

        #region IDisposable implementation

        public void Dispose()
        {
            if (_isInLayout)
            {
                EndLayout();
            }
        }

        #endregion
    }
}