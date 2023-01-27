namespace _06.ReverseAndExclude
{
    internal class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = Console.ReadLine()
                 .Split()
                 .Select(x => decimal.Parse(x))
                 .ToList();

            decimal devider = decimal.Parse(Console.ReadLine());

            Predicate<decimal> predicate = x => x % devider == 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (predicate(numbers[i]))
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}