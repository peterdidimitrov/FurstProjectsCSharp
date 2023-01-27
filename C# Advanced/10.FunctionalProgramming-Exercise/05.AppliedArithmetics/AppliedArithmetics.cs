namespace _05.AppliedArithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = Console.ReadLine()
                 .Split()
                 .Select(x => decimal.Parse(x))
                 .ToList();

            Func<List<decimal>, List<decimal>> add = list => list
            .Select(n => n += 1).ToList();
            Func<List<decimal>, List<decimal>> multiply = list => list
            .Select(n => n *= 2).ToList();
            Func<List<decimal>, List<decimal>> subtract = list => list
            .Select(n => n -= 1).ToList();

            Action<List<decimal>> print = n => Console.WriteLine(string.Join(" ", numbers));

            string operation;
            while ((operation = Console.ReadLine()) != "end")
            {
                switch (operation)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}