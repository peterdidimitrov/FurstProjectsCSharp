namespace _07.PredicateForNames
{
    internal class PredicateForNames
    {
        static void Main(string[] args)
        {

            Action<string[], Predicate<string>> printNames = (names, match) =>
            {
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            int length = int.Parse(Console.ReadLine());

            //Predicate<string> match = name =>
            //    name.Length <= length;

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(names, n => n.Length <= length);
        }
    }
}