using System;

namespace MoneyTransactions
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> accountInfo = Console.ReadLine()
                .Split(',').ToList();
            List<BankAccount> bankAccounts = new List<BankAccount>();

            for (int i = 0; i < accountInfo.Count; i++)
            {
                string[] currAccount = accountInfo[i].Split("-");

                int accountNumber = int.Parse(currAccount[0]);
                decimal accountBalance = decimal.Parse(currAccount[1]);

                BankAccount bankAccount = new BankAccount(accountNumber, accountBalance);

                bankAccounts.Add(bankAccount);
            }

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commandArguments = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currCommand = commandArguments[0];
                int currAccountNumber = int.Parse(commandArguments[1]);
                decimal sum = decimal.Parse(commandArguments[2]);

                try
                {
                    if (currCommand == Commands.Withdraw.ToString())
                    {
                        if (!CheckAccountNumber(bankAccounts, currAccountNumber))
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        var bankAccount = bankAccounts.FirstOrDefault(a => a.Number == currAccountNumber);
                        bankAccount.Withdraw(sum);
                    }
                    else if (currCommand == Commands.Deposit.ToString())
                    {
                        if (!CheckAccountNumber(bankAccounts, currAccountNumber))
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        var bankAccount = bankAccounts.FirstOrDefault(a => a.Number == currAccountNumber);
                        bankAccount.Deposit(sum);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        private static bool CheckAccountNumber(List<BankAccount> bankAccounts, int currAccountNumber)
            => bankAccounts.Any(a => a.Number == currAccountNumber);
    }
    public interface IBankAccount
    {
        int Number { get; }
        decimal Balance { get; }
        public void Deposit(decimal sum);
        public void Withdraw(decimal sum);
    }
    public class BankAccount : IBankAccount
    {
        private int number;
        private decimal balance;

        public BankAccount(int number, decimal balance)
        {
            Number = number;
            Balance = balance;
        }

        public int Number
        {
            get { return number; }
            private set { number = value; }
        }
        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }
        public void Deposit(decimal sum)
        {
            Balance += sum;
            Console.WriteLine($"Account {Number} has new balance: {Balance:f2}");
        }

        public void Withdraw(decimal sum)
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                Console.WriteLine($"Account {Number} has new balance: {Balance:f2}");
            }
            else
            {
                throw new ArgumentException("Insufficient balance!");
            }
        }
    }
    public enum Commands
    {
        Deposit = 1,
        Withdraw = 2,
    }
}
