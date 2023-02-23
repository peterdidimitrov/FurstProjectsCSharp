namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.Push("1");

            List<string> list = new List<string>()
            {
                "edno",
                "dve",
                "tri",
                "chetiri"
            };
            
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(string.Join(" ", stack));

            stack.AddRange(list);
            Console.WriteLine(string.Join(" ", stack));

            stack.Clear();

            Console.WriteLine(stack.IsEmpty());
        }
    }
}