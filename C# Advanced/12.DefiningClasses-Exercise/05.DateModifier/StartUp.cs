namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string inputTwo = Console.ReadLine();

            DateModifier diff = new();

            Console.WriteLine(Math.Abs(diff.GetDifference(input, inputTwo)));

        }
    }
}