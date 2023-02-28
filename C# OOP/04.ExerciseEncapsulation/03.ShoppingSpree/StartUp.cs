using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] namesAndMoney = Console.ReadLine()
                .Split(';');

            Dictionary<string, int> shopingInfo = new Dictionary<string, int>();

            for (int i = 0; i < namesAndMoney.Length; i++)
            {
                string[] personInfo = namesAndMoney[i].Split('=');

                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);

                Console.WriteLine();
            }

            //string commands = string.Empty;
            //while ((commands = Console.ReadLine()) != "END")
            //{

            //}
        }
    }
}