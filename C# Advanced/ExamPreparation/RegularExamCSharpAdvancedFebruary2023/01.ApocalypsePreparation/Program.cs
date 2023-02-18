namespace FirstProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            //read the input

            Queue<int> textile = new(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse).
                ToArray());

            Stack<int> medicaments = new(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse).
                ToArray());

            Dictionary<int, string> healingItems = new Dictionary<int, string>();
            healingItems.Add(30, "Patch");
            healingItems.Add(40, "Bandage");
            healingItems.Add(100, "MedKit");

            Dictionary<string, int> createdItems = new Dictionary<string, int>();

            //main logic
            while (medicaments.Any() && textile.Any())
            {
                int sum = textile.Peek() + medicaments.Peek();

                if (healingItems.ContainsKey(sum))
                {
                    if (!createdItems.ContainsKey(healingItems[sum]))
                    {
                        createdItems.Add(healingItems[sum], 0);
                    }
                    createdItems[healingItems[sum]]++;

                    textile.Dequeue();
                    medicaments.Pop();
                }
                else if (sum > 100)
                {

                    int differens = sum - 100;

                    if (!createdItems.ContainsKey(healingItems[100]))
                    {
                        createdItems.Add(healingItems[100], 0);
                    }
                    createdItems[healingItems[100]]++;

                    textile.Dequeue();
                    medicaments.Pop();

                    int temp = medicaments.Pop() + differens;
                    medicaments.Push(temp);
                }
                else if (sum < 100)
                {
                    textile.Dequeue();
                    int temp = medicaments.Pop() + 10;
                    medicaments.Push(temp);
                }
            }

            //conditional statements for output
            if (!textile.Any() && medicaments.Any())
            {
                Console.WriteLine($"Textiles are empty.");
            }
            else if (!medicaments.Any() && textile.Any())
            {
                Console.WriteLine($"Medicaments are empty.");
            }
            else if (!medicaments.Any() && !textile.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            if (createdItems.Any())
            {
                foreach (var item in createdItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    string name = item.Key;
                    int count = item.Value;
                    Console.WriteLine($"{name} - {count}");
                }
            }

            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textile.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
            }
        }
    }
}