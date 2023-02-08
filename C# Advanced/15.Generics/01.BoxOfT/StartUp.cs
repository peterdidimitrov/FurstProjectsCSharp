namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new();
            Box <int> box = new();
            box.Add(1);
            box.Add(2);
            box.Add(3);

            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }
}