namespace _02.MakeASalad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vegetalble = new (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            
        }
    }
}