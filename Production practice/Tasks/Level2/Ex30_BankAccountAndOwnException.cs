using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex30_BankAccountAndOwnException : ITask
    {
        public string Title => "BankAccount + свой Exception";
        public string Description => "Реализовать банковский счёт с собственным исключением.";
        public string[] Condition => new[]
        {
            "Класс BankAccount с приватным балансом",
            "Методы Deposit(decimal), Withdraw(decimal)",
            "Свой класс InsufficientFundsException : Exception",
            "Withdraw бросает исключение, если сумма больше баланса",
            "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)"
        };

        public void Launch()
        {
            Console.WriteLine("--- Демонстрация работы BankAccount ---\n");

            var Account = new BankAccount();
            Console.WriteLine($"Начальный баланс: {Account.Balance:C}");

            Account.Deposit(1000m);
            Console.WriteLine($"После пополнения на 1000: {Account.Balance:C}\n");

            try
            {
                Console.WriteLine("Попытка снять 200...");
                Account.Withdraw(200m);
                Console.WriteLine($"Операция проведена. Текущий баланс: {Account.Balance:C}\n");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }
            try
            {
                Console.WriteLine("Попытка снять 1000 (больше, чем остаток)..");
                Account.Withdraw(1000m);
                Console.WriteLine("Операция не проводится.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Поймано исключение: {ex.Message}");
                Console.WriteLine($"Не хватает: {(ex.WithdrawAmount - ex.CurrentBalance):C}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Поймано другое исключение: {ex.Message}\n");
            }
            Console.WriteLine($"Итоговый баланс: {Account.Balance:C} (ушел ли в минус? {(Account.Balance < 0 ? "Да" : "Нет")})");

            try
            {
                Console.WriteLine("\nПопытка пополнить на -50...");
                Account.Deposit(-50m);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }
        }
        public class BankAccount
        {
            private decimal balance;
            public decimal Balance => balance;
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Сумма пополнения должна быть больше нуля!");
                }
                balance += amount;
            }
            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Сумма снятия должна быть больше нуля!");
                }
                if (amount > balance)
                {
                    throw new InsufficientFundsException(balance, amount);
                }
                balance -= amount;
            }
        }
        public class InsufficientFundsException : Exception
        {
            public decimal CurrentBalance { get; }
            public decimal WithdrawAmount { get; }
            public InsufficientFundsException(decimal currentBalance, decimal withdrawAmount)
                : base($"Недостаточно средств. На счету: {currentBalance:C}, запрошено: {withdrawAmount:C}.")
            {
                CurrentBalance = currentBalance;
                WithdrawAmount = withdrawAmount;
            }
            public InsufficientFundsException() : base() { }
            public InsufficientFundsException(string message) : base(message) { }
            public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { }
        }
    }
}
