namespace _02.SumNumbersWithLambda
{
    internal class SumNumbersWithLambda
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ")
                .Select(Parse)
                .ToList();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
        static int Parse(string numbers)
        {
            return int.Parse(numbers);
        }
    }
}