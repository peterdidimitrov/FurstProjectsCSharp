namespace _01.Furniture
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var regex = @"(>>(?<furniture>[A-za-z\s]+)<<)(?<price>\d+(.\d+)?)!(?<quantity>\d+)\b";
            double spendMoney = 0;

            Console.WriteLine("Bought furniture:");
            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                var futnituresMathches = Regex.Matches(input, regex);

                foreach (Match item in futnituresMathches)
                {
                    var furniture = item.Groups["furniture"].Value;
                    var price = item.Groups["price"].Value;
                    var quantity = item.Groups["quantity"].Value;

                    Console.WriteLine(furniture);

                    spendMoney += double.Parse(price) * int.Parse(quantity);
                }
            }
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}