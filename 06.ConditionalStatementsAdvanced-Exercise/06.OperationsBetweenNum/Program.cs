﻿using System;

namespace _06.OperationsBetweenNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0;

            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    Console.Write($"{number1} {operation} {number2} = {result}");
                    break;
                case '-':
                    result = number1 - number2;
                    Console.Write($"{number1} {operation} {number2} = {result}");
                    break;
                case '*':
                    result = number1 * number2;
                    Console.Write($"{number1} {operation} {number2} = {result}");
                    break;
                case '/':
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        result = (double)number1 / number2;
                        Console.WriteLine($"{number1} {operation} {number2} = {result:f2}");
                    }
                    break;
                case '%':
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        result = number1 % number2;
                        Console.WriteLine($"{number1} {operation} {number2} = {result}");
                    }
                    break;
            }
            if (operation == '+' || operation == '-' || operation == '*')
            {
                 if (result % 2 == 0)
                 {
                     Console.WriteLine(" - even");
                 }
                 else
                 {
                     Console.WriteLine(" - odd");
                 }
            }
                    
         
        }
    }
}
