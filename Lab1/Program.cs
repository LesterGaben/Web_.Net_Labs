//using Lab1.MyList;
using MyListLibrary;
namespace Lab1 {
    internal class Program {
        static void Main(string[] args) {
            MyList<int> list;

            list = new MyList<int>(5) { 1, 2, 3, 4, 5 };
            list.ArrayResized += MyEventHandlers.ListResizedEventHandler!;
            list.ItemAdded += MyEventHandlers.ListItemChangesEventHandler!;
            list.ItemRemoved += MyEventHandlers.ListItemChangesEventHandler!;

            list.Add(1);
            OutputMyIntArray(list);

            Console.WriteLine("Array Contains 1? : " + list.Contains(1));

            Console.WriteLine("Getting index 5, result: " + list[5]);
            list[5] = 10;
            Console.WriteLine("Setting 10 in index 5, result: " + list[5]);

            list.Clear();
            OutputMyIntArray(list);

            list = new MyList<int>(5) { 1, 2, 3, 4, 5 };
            list.ArrayResized += MyEventHandlers.ListResizedEventHandler!;
            list.ItemAdded += MyEventHandlers.ListItemChangesEventHandler!;
            list.ItemRemoved += MyEventHandlers.ListItemChangesEventHandler!;

            Console.WriteLine("List contains 20?: " +list.Contains(20));

            

            Console.WriteLine("Index of 5: " + list.IndexOf(5));
            list.Insert(2, 100);
            Console.Write("List after insert 100 on 10 index: ");
            OutputMyIntArray(list);

            list.Remove(1);

            Console.Write("List after removing 1: ");
            OutputMyIntArray(list);

            list.RemoveAt(3);
            Console.Write("List after removing index 3: ");
            OutputMyIntArray(list);

            

        }
        
        public static void OutputMyIntArray(MyList<int> list) {
            Console.Write("Array: ");
            for (int i = 0; i < list.Count; i++) {
                Console.Write(list[i] + "  ");
            }
            Console.WriteLine();
        }
    }
}