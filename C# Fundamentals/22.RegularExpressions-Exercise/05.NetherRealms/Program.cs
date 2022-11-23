namespace _05.NetherRealms
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            char[] split = { ',', ' ' };
            string damagePattern = @"(?<damage>-?\d+\.?\d*)";
            string multuplayOrDividePattern = @"(?<operator>[\*\/])";

            string[] names = Console.ReadLine().Split(split, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToArray();

            for (int i = 0; i < names.Length; i++)
            {
                int health = 0;
                double damage = 0;

                var matchHealth = Regex.Matches(names[i], healthPattern);
                var matchDamage = Regex.Matches(names[i], damagePattern);
                var matchOperator = Regex.Matches(names[i], multuplayOrDividePattern);

                string strHealth = string.Empty;

                foreach (Match symbol in matchHealth)
                {
                    strHealth += symbol;
                }

                foreach (Match number in matchDamage)
                {
                    var damageNum = number.Groups["damage"].Value;
                    damage += double.Parse(damageNum);
                }
                for (int j = 0; j < strHealth.Length; j++)
                {
                    health += (int)(strHealth[j]);
                }
                foreach (Match operation in matchOperator)
                {
                    var symbol = operation.Groups["operator"].Value;
                    if (symbol == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{names[i]} - {health} health, {damage:f2} damage");
            }
        }
    }
}