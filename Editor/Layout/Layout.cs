using UnityEngine;
using System;

namespace UnityForms.Layouts
{
    public abstract class Layout : IDisposable
    {
        protected bool IsInLayout { get; set; }

        internal virtual void BeginLayout()
        {
            StartLayoutAbstractMethod();
            IsInLayout = true;
        }

        internal virtual void EndLayout()
        {
            EndLayoutAbstractMethod();
            IsInLayout = false;
        }

        protected abstract void StartLayoutAbstractMethod();

        protected abstract void EndLayoutAbstractMethod();

        #region IDisposable implementation

        public void Dispose()
        {
            if (IsInLayout)
            {
                EndLayout();
            }
        }

        #endregion
    }
}