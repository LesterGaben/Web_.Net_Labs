using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListLibrary {
    public class MyEventHandlers {
        public static void ListCreatedEventHandler(object sender, MyListCreatedEventArgs e) {
            Console.WriteLine($"\nEvent: array creating; Capacity: {e.Capacity}\n");
        }
        public static void ListResizedEventHandler(object sender, MyListNewSizeEventArgs e) {
            Console.WriteLine($"\nEvent: change size; OldCapacity: {e.OldCapacity}, NewCapacity: {e.NewCapacity}\n");
        }

        public static void ListItemChangesEventHandler<T>(object sender, MyListItemChangesEventArgs<T> e) {
            Console.WriteLine($"\nEvent: {e.ItemChangeType}; Item: {e.Item}; Index: {e.Index}\n");
        }
    }
}
