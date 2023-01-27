namespace _04.FindEvensOrOdds
{
    internal class FindEvensOrOdds
    {
        static void Main(string[] args)
        {

            int[] range = Console.ReadLine()
                 .Split()
                 .Select(x => int.Parse(x))
                 .ToArray();

            int start = range[0];
            int end = range[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            string type = Console.ReadLine();

            Predicate<int> predicate = null;
            

            if (type == "even")
            {
                predicate = number => number % 2 == 0;
            }
            else if (type == "odd")
            {
                predicate = number => number % 2 != 0;
            }
            Console.WriteLine(string.Join(" ", numbers.FindAll(predicate)));
        }
    }
}