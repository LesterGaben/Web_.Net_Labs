using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListLibrary {
    public class MyList<T> : IList<T> {

        private T[] _items;
        private const int DefaultCapacity = 5;

        private int _capacity;
        private int _size;

        public int Count => _size;
        public bool IsReadOnly => false;

        public EventHandler<MyListNewSizeEventArgs> ArrayResized;
        public EventHandler<MyListCreatedEventArgs> ArrayCreated;
        public EventHandler<MyListItemChangesEventArgs<T>> ItemAdded;
        public EventHandler<MyListItemChangesEventArgs<T>> ItemRemoved;

        public int GetCapacity () { return _capacity; }

        public MyList(int capacity = DefaultCapacity)
        {
            if (capacity < 0) {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity is invalid");
            }
            _capacity = capacity;
            _size = 0;
            _items = capacity is 0 ? Array.Empty<T>() : new T[capacity];
            ArrayCreated += MyEventHandlers.ListCreatedEventHandler!;
            OnArrayCreated();
        }

        public T this[int index] {
            get => _items[index];
            set {
                if (index < 0 || index >= _items.Length - 1) {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                _items[index] = value;
            }
        }

        public void Add(T item) {
            if (_size >= _capacity) {
                Resize();
            }
            _items[_size] = item;
            OnItemAdded(item, _size);
            _size++;
        }

        public void Clear() {
            _items = new T[_capacity];
            _size = 0;
        }

        public bool Contains(T item) {
            for (int i = 0; i < _capacity; i++) {
                var element = _items[i];
                if (element?.Equals(item) == true) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex) {
            if (array == null) {
                throw new ArgumentNullException(nameof(array));
            }
            if(arrayIndex >= array.Length || arrayIndex < 0) {
                throw new ArgumentException("Index is invalid");
            }
            if (array.Length - arrayIndex < _size) {
                throw new ArgumentException("Dest array is too small");
            }
            Array.ConstrainedCopy(_items, 0, array, arrayIndex, _size);
        }

        public int IndexOf(T item) {
            return Array.IndexOf(_items, item);
        }

        public void Insert(int index, T item) {
            if(_size < index || index < 0) {
                throw new ArgumentOutOfRangeException("Inalid index. Index must be in range.");
            }
            if(_capacity == _size) {
                Resize();
            }
            OnItemAdded(item, index);
            Array.Copy(_items, index, _items, index + 1, _size - index);
            _size++;
            _items[index] = item;
        }

        public bool Remove(T item) {
            if(_size == 0) {
                throw new InvalidOperationException("You can't remove item because array is empty");
            }
            var index = Array.IndexOf(_items, item);
            var isRemoved = index != -1;
            RemoveAt(index);
            return isRemoved;
        }

        public void RemoveAt(int index) {
            if (index > _size || index < 0) {
                throw new ArgumentOutOfRangeException("You can't remove item because index is out of range");
            }
            _size--;
            OnItemRemoved(_items[index], index);
            Array.Copy(_items, index + 1, _items, index, _size - index);
        }

        public IEnumerator<T> GetEnumerator() {
            return new MyListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private void Resize() {
            var NewCapacity = _capacity * 2;
            var tempArray = new T[NewCapacity];
            Array.Copy(_items, tempArray, _size);
            _items = tempArray;
            _capacity = NewCapacity;

            OnArrayResized(NewCapacity / 2, _capacity);
        }

        private void OnArrayResized(int oldCapacity, int newCapacity) {
            if (ArrayResized != null) {
                ArrayResized(this, new MyListNewSizeEventArgs(oldCapacity, newCapacity));
            }
        }

        private void OnArrayCreated() {
            if (ArrayCreated != null) {
                ArrayCreated(this, new MyListCreatedEventArgs(this._capacity));
            }
        }

        private void OnItemAdded(T item, int index) {
            if (ItemAdded != null) {
                ItemAdded(this, new MyListItemChangesEventArgs<T>(item, index, ItemChangeType.ItemAdded));
            }
        }

        private void OnItemRemoved(T item, int index) {
            if (ItemRemoved != null) {
                ItemRemoved(this, new MyListItemChangesEventArgs<T>(item, index, ItemChangeType.ItemRemoved));
            }
        }
    }
}
