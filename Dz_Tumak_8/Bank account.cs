using System;
using System.Collections;
using System.Collections.Generic;

namespace Tumakov
{
    public class Bank_account
    {
        private string number;
        private decimal balance;
        private Account type;
        private static List<string> numbers = new List<string>();
        private static Queue<BankTransaction> bankTransactions = new Queue<BankTransaction>();

        public Bank_account()
        {
            number = UniqueNum();
            balance = 0;
            type = Account.текущий;
        }

        public Bank_account(decimal balance)
        { this.balance = balance; 
         number = UniqueNum();
        }

        public Bank_account(Account type)
        { this.type = type;
          number = UniqueNum();
        }

        public Bank_account(decimal balance, Account type)
        {
            number = UniqueNum();
            this.balance = balance;
            this.type = type;
        }

        public string UniqueNum()
        {
            string newNumber;
            do
            {
                Random rand = new Random();
                int[] rand_numbers = new int[20];
                for (int i = 0; i < rand_numbers.Length; i++)
                {
                    rand_numbers[i] = rand.Next(0, 9);
                }
                newNumber = string.Join("", rand_numbers);
            }
            while (numbers.Contains(newNumber));
            numbers.Add(newNumber);
            return newNumber;
        }

        public void Print()
        {
            Console.WriteLine($"\nНомер счёта: {number}\nБаланс: {balance}\nТип банковского счёта: {type}");
        }

        static bool IsAllDigit(string n)
        {
            foreach (char c in n)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public void Deposit()
        {
            Console.WriteLine("\nВведите сумму для пополнения:");
            decimal bal;
            while (!decimal.TryParse(Console.ReadLine(), out bal))
            {
                Console.WriteLine("\nНеверный формат данных. Повторите попытку.");
            }
            BankTransaction a = new BankTransaction(bal);
            bankTransactions.Enqueue(a);
            balance += bal;
        }

        public void Withdraw()
        {
            Console.WriteLine("\nВведите сумму для снятия:");
            decimal bal;
            while (!decimal.TryParse(Console.ReadLine(), out bal) || bal > balance)
            {
                Console.WriteLine("\nНеверный формат данных или недостаточно средств. Повторите попытку.");
            }
            BankTransaction a = new BankTransaction(bal);
            bankTransactions.Enqueue(a);
            balance -= bal;
        }

        public void Transfer(Bank_account targetAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\nСумма перевода должна быть больше нуля.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("\nНедостаточно средств для перевода.");
                return;
            }
            BankTransaction a = new BankTransaction(amount);
            bankTransactions.Enqueue(a);
            balance -= amount;
            targetAccount.balance += amount;
            Console.WriteLine($"\nПеревод успешно выполнен.\nС вашего счёта снято: {amount}\nТекущий баланс: {balance}");
            Console.WriteLine($"На счёт {targetAccount.number} зачислено: {amount}\nТекущий баланс получателя: {targetAccount.balance}");
        }
        public void Dispose()
        {
            string filePath = "transactions.txt";
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                while (bankTransactions.Count > 0)
                {
                    var transaction = bankTransactions.Dequeue();
                    writer.WriteLine($"Дата: {transaction.date}, Сумма: {transaction.sum}");
                }
            }
            Console.WriteLine($"Транзакции записаны в файл {filePath}.");
            GC.SuppressFinalize(this);
        }
    }
}