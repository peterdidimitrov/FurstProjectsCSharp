namespace _01.ActionPrint
{
    internal class ActionPrint
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Action<string> print = name => Console.WriteLine(name);

            names.ForEach(print);
        }
    }
}