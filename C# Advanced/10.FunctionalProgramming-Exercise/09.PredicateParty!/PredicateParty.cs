namespace _09.PredicateParty
{
    internal class PredicateParty
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<List<string>, string, List<string>> starts = (collection, command) => collection.FindAll(x => x.StartsWith(command));
            Func<List<string>, string, List<string>> ends = (collection, command) => collection.FindAll(x => x.EndsWith(command));
            Func<List<string>, string, List<string>> length = (collection, command) => collection.FindAll(x => x.Length == int.Parse(command));
            while (true)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command.Length != 1)
                {
                    if (command[1] == "StartsWith")
                    {
                        if (command[0] == "Double")
                        {
                            names.AddRange(starts(names, command[2]));
                        }
                        else if (command[0] == "Remove")
                        {
                            starts(names, command[2]).ForEach(x => names.Remove(x));
                        }
                    }
                    else if (command[1] == "EndsWith")
                    {
                        if (command[0] == "Double")
                        {
                            names.AddRange(ends(names, command[2]));
                        }
                        else if (command[0] == "Remove")
                        {
                            ends(names, command[2]).ForEach(x => names.Remove(x));
                        }
                    }
                    else if (command[1] == "Length")
                    {
                        if (command[0] == "Double")
                        {
                            names.AddRange(length(names, command[2]));
                        }
                        else if (command[0] == "Remove")
                        {
                            length(names, command[2]).ForEach(x => names.Remove(x));
                        }
                    }
                }
                if (command[0] == "Party!")
                {
                    break;
                }

            }
            if (names.Count != 0)
            {

                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}