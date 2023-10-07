using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.MyList {
    public class MyList<T> : IList<T> {

        private T[] _items;
        private const int DefaultCapacity = 5;

        private int _capacity;
        private int _size;

        public int Count => _size;
        public bool IsReadOnly => false;

        public MyList(int capacity = DefaultCapacity)
        {
            if(capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity is invalid");
            _capacity = capacity;
            _size = 0;
            _items = capacity is 0 ? Array.Empty<T>() : new T[capacity];
        }

        public T this[int index] {
            get => _items[index];
            set {
                if (index < 0 || index >= _items.Length - 1)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }
        }

        public void Add(T item) {
            if (_size >= _capacity) {
                Resize();
            }
            _items[_size] = item;
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
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() {
            return new MyListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int IndexOf(T item) {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index) {
            throw new NotImplementedException();
        }

        private void Resize() {
            var NewCapacity = _capacity * 2;
            var tempArray = new T[NewCapacity];
            Array.Copy(_items, tempArray, _size);
            _items = tempArray;
            _capacity = NewCapacity;
        }
    }
}
