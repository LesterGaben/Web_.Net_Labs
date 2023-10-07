using Lab1.MyList;
namespace Lab1 {
    internal class Program {
        static void Main(string[] args) {
            MyList<int> ints = new MyList<int>(0);
            ints.Remove(0);
        }
    }
}