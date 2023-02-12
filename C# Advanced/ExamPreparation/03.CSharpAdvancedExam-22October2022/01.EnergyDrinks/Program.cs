namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> milligramsOfCaffeinе = new(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse).
                ToArray());

            Queue<int> energyDrinks = new(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse).
                ToArray());

            int stamatsCaffeine = 0;

            while (milligramsOfCaffeinе.Any() && energyDrinks.Any())
            {
                if (stamatsCaffeine + (milligramsOfCaffeinе.Peek() * energyDrinks.Peek()) <= 300)
                {
                    stamatsCaffeine += milligramsOfCaffeinе.Pop() * energyDrinks.Dequeue();
                }
                else
                {
                    milligramsOfCaffeinе.Pop();
                    int temp = energyDrinks.Dequeue();
                    energyDrinks.Enqueue(temp);
                    if (stamatsCaffeine - 30 < 0)
                    {
                        stamatsCaffeine = 0;
                    }
                    else
                    {
                        stamatsCaffeine -= 30;
                    }
                }
            }

            if (energyDrinks.Any())
            {

                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");

            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {stamatsCaffeine} mg caffeine.");

        }
    }
}