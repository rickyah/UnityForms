using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UnityForms
{
    public class GenericObjectCollectionEventArgs<T> : EventArgs
    {
        public GenericObjectCollectionEventArgs(T thatObject)
        {
            this.Object = thatObject;
        }

        public T Object { get; private set; }
    }

    public class GenericObjectCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        private List<T> _dataContainer = new List<T>();
        private object _dataContainerSyncRoot = new object();

        #region Events

        public event EventHandler<GenericObjectCollectionEventArgs<T>> Added;
        public event EventHandler Cleared;
        public event EventHandler Changed;
        public event EventHandler<GenericObjectCollectionEventArgs<T>> Removed;

        #endregion

        #region OnEvents

        protected virtual void OnAdded(T addedObject)
        {
            if (Added != null)
                Added(this, new GenericObjectCollectionEventArgs<T>(addedObject));
            OnChanged();
        }

        protected virtual void OnCleared()
        {
            if (Cleared != null)
                Cleared(this, EventArgs.Empty);
            
            OnChanged();
        }

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        protected virtual void OnRemoved(T removedObject)
        {
            if (Removed != null)
                Removed(this, new GenericObjectCollectionEventArgs<T>(removedObject));
            
            OnChanged();
        }

        #endregion

        #region IList implementation

        public void Add(T value)
        {
            this.Add(new T[] { value });
        }

        public void Add(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                _dataContainer.Add(value);
                OnAdded(value);
            }
        }

        public void Clear()
        {
            _dataContainer.Clear();
            OnCleared();
        }

        public bool Contains(T value)
        {
            return _dataContainer.Contains(value);
        }

        public int IndexOf(T value)
        {
            return _dataContainer.IndexOf(value);
        }

        public void Insert(int index, T value)
        {
            _dataContainer.Insert(index, value);
            OnAdded(value);
        }

        public bool Remove(T value)
        {
            var result = _dataContainer.Remove(value);
            if (result)
            {
                OnRemoved(value);
            }
            
            return result;
        }

        public void RemoveAt(int index)
        {
            var value = this[index];
            _dataContainer.RemoveAt(index);
            OnRemoved(value);
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                return _dataContainer[index];
            }
            set
            {
                _dataContainer[index] = value;
            }
        }

        #endregion

        #region ICollection implementation

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_dataContainer.ToArray(), array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return _dataContainer.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                // We are using a List as data container, and .NET generic collection are
                // not thread safe
                // http://msdn.microsoft.com/en-us/library/bb345109(v=vs.110).aspx  
                return false;
                
            }
        }

        public object SyncRoot
        {
            get
            {
                return _dataContainerSyncRoot;
            }
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator<T> GetEnumerator()
        {
            return _dataContainer.GetEnumerator();
        }

        #endregion

        #region IEnumerable implementation

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}