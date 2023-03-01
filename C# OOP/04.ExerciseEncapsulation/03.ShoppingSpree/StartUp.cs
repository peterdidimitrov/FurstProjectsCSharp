using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new();
            List<Product> products = new();


            try
            {
                string[] namesAndMoney = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < namesAndMoney.Length; i++)
                {
                    string[] personInfo = namesAndMoney[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    Person person = new(name, money);
                    persons.Add(person);
                }


                string[] productsAndCosts = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productsAndCosts.Length; i++)
                {
                    string[] productInfo = productsAndCosts[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);

                    Product product = new(name, cost);
                    products.Add(product);
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);

                return;
            }

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "END")
            {
                string[] commandArg = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = commandArg[0];
                string productName = commandArg[1];

                Person person = persons.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person is not null && product != null)
                {
                    Console.WriteLine(person.AddProduct(product));
                }
            }
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}