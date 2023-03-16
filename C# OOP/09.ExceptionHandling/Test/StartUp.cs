using System;

namespace MoneyTransactions
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string currCommand = "Deposit";
            if (currCommand == Commands.Deposit.ToString())
            {

            }
        }
    }
    public enum Commands
    {
        Deposit = 1,
        Withdraw = 2,
    }
}
