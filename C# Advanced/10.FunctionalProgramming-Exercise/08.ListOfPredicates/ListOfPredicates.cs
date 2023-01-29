namespace _08.ListOfPredicates
{
    internal class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            double[] numbers = Console.ReadLine().Split()
                .Select(double.Parse).ToArray();

            Predicate<int> isDivisible = n => n % numbers[n] == 0;

            List<double> divisibleNumbers = new List<double>();
            
            for (int i = 1; i <= endOfRange; i++)
            {
                List<double> current = new List<double>();

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i % numbers[j] == 0)
                    {
                        current.Add(numbers[j]);
                    }
                }
                if (current.Count == numbers.Length)
                {
                    divisibleNumbers.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", divisibleNumbers));
        }
    }
}