using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListLibrary {
    public class MyListNewSizeEventArgs : EventArgs {

        public int OldCapacity { get; private set; }
        public int NewCapacity { get; private set; }
        public MyListNewSizeEventArgs(int OldCapacity, int NewCapacity)
        {
            this.OldCapacity = OldCapacity;
            this.NewCapacity = NewCapacity;
        }
    }

    public class MyListCreatedEventArgs : EventArgs {
        public int Capacity { get; private set; }
        public MyListCreatedEventArgs(int Capacity)
        {
            this.Capacity = Capacity;
        }
    }

    public enum ItemChangeType {
        ItemAdded,
        ItemRemoved
    }

    public class MyListItemChangesEventArgs<T> : EventArgs {
        public ItemChangeType ItemChangeType { get; private set; }

        public T Item { get; private set; }
        public int Index { get; private set; }

        public MyListItemChangesEventArgs(T item, int index, ItemChangeType itemChangeType)
        {
            Item = item;
            this.Index = index;
            ItemChangeType = itemChangeType;
        }
    }
}
