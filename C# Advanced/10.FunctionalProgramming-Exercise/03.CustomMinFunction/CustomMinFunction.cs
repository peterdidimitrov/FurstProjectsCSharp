namespace _03.CustomMinFunction
{
    internal class CustomMinFunction
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            Func<List<int>, int> getMinNumber = numbers => numbers.Min();
            Console.WriteLine(getMinNumber(numbers));
        }
    }
}