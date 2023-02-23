namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList();
            List<string> list = new List<string>()
            {
                "edno",
                "dve",
                "tri",
                "chetiri"
            };
            list.Add("1");
            Console.WriteLine(strings.RandomString(list));
        }
    }
}