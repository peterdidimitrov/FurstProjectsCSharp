namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new();
            List<Box<int>> list = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

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