using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.MyList {
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
}
