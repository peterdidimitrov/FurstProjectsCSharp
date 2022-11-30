using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(@#+)([A-Z][A-Za-z\d]{4,}[A-Z])(@#+)$";
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(pattern);


            for (int i = 0; i < n; i++)
            {
                StringBuilder productGroup = new StringBuilder();
                string barcode = Console.ReadLine();
                var match = regex.Match(barcode);
                if (match.Success)
                {
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        char currChar = barcode[j];
                        if (Char.IsDigit(currChar))
                        {
                            productGroup.Append(currChar);
                        }
                    }
                    if (productGroup.Length == 0)
                    {
                        productGroup.Append("00");
                    }
                Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
