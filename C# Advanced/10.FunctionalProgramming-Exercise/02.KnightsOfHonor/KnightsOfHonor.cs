namespace _02.KnightsOfHonor
{
    internal class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split();

            Action<string> print = name => 
            {
                Console.WriteLine($"Sir {name}"); 
            };

            for (int i = 0; i < names.LongLength; i++)
            {
                print(names[i]);
            }
        }
    }
}