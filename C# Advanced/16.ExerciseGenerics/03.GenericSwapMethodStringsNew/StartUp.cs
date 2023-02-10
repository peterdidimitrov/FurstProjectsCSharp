namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new();
            List<Box<string>> list = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                box.Add(input);
                list.Add(box);
            }

            List<int> indices = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            box.Swap(indices[0], indices[1]);

            Console.WriteLine(box.ToString());
        }
    }
}