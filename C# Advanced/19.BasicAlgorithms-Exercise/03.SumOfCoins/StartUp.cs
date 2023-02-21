namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            return null;
        }
    }
}