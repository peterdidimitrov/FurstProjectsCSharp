namespace _07.PredicateForNames
{
    internal class PredicateForNames
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            List<string> listOfNames = new List<string>();

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Length <= n)
                {
                    listOfNames.Add(names[i]);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, listOfNames));
        }
    }
}