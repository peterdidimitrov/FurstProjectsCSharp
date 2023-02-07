namespace _01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> conqueredPeaks = new();
            int[] inputOne = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputTwo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> foodPortions = new(inputOne);
            Queue<int> stamina = new(inputTwo);

            string[] peaksName =
                { "Vihren", "Kutelo", "Banski Suhodol", "Polezhan", "Kamenitza" };
            int[] difficultyLevel = { 80, 90, 100, 60, 70 };

            for (int i = 0; i < peaksName.Length; i++)
            {
                if (foodPortions.Count == 0 && i < peaksName.Length)
                {
                    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                    if (conqueredPeaks.Count > 0)
                    {
                        Console.WriteLine("Conquered peaks:");
                        Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
                    }
                    return;
                }
                int lastDailyFoodPortion = foodPortions.Peek();
                int quantityOfTheFirstDailyStamina = stamina.Peek();

                if ((lastDailyFoodPortion + quantityOfTheFirstDailyStamina) >= difficultyLevel[i])
                {
                    foodPortions.Pop();
                    stamina.Dequeue();
                    conqueredPeaks.Add(peaksName[i]);
                }
                else
                {
                    i--;
                    foodPortions.Pop();
                    stamina.Dequeue();
                }
            }
            if (conqueredPeaks.Count == peaksName.Length)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
            }
            else
            {
                if (conqueredPeaks.Count > 0)
                {
                    Console.WriteLine("Conquered peaks:");
                    Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
                }
            }
        }
    }
}