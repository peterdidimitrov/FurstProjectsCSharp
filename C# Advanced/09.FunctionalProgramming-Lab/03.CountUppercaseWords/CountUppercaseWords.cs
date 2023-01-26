namespace _03.CountUppercaseWords
{
    internal class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Predicate<string> isUper = n => n[0] == n.ToUpper()[0] 
            && char.IsLetter(n[0]);
            
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isUper(w))
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }     
        }
    }
}