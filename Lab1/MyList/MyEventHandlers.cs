using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.MyList {
    public class MyEventHandlers {
        public static void ListCreatedEventHandler(object sender, MyListCreatedEventArgs e) {
            Console.WriteLine($"Event: array creating; Capacity: {e.Capacity}\n");
        }
        public static void ListResizedEventHandler(object sender, MyListNewSizeEventArgs e) {
            Console.WriteLine($"Event: change size; OldCapacity: {e.OldCapacity}, NewCapacity: {e.NewCapacity}\n");
        }
    }
}
