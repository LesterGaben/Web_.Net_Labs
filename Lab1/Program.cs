using Lab1.MyList;
namespace Lab1 {
    internal class Program {
        static void Main(string[] args) {
            MyList<int> list;

            list = new MyList<int>(5) { 1, 2, 3, 4, 5 };
            list.ArrayResized += MyEventHandlers.ListResizedEventHandler!;

            list.Add(1);
            for (int i = 0; i < list.Count; i++) {
                Console.Write(list[i] + "  ");
            }

        }
    }
}