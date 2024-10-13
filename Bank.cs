using System;

namespace HW_5
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }// Свойство для хранения номера счета
                                                         // Свойство для хранения баланса
        public decimal Balance { get; private set; }
        // Свойство для хранения владельца счета
        public string Owner { get; private set; }

        // Конструктор, принимающий номер счета и владельца, устанавливая баланс в 0
        public BankAccount(string accountNumber, string owner)
        {
            AccountNumber = accountNumber; // Присваивание номера счета
            Owner = owner; // Присваивание владельца
            Balance = 0; // Установка начального баланса в 0
        }

        // Метод для пополнения баланса на указанную сумму
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма должна быть положительной."); // Проверка на отрицательное значение
            }
            Balance += amount; // Увеличение баланса на указанную сумму
        }

        // Метод для снятия денег с баланса (если достаточно средств)
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма должна быть положительной."); // Проверка на отрицательное значение
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Недостаточно средств."); // Проверка на достаточность средств
            }
            Balance -= amount; // Уменьшение баланса на указанную сумму
        }

        // Метод для получения информации о счете
        public string GetAccountInfo()
        {
            return $"Номер счета: {AccountNumber}, Владелец: {Owner}, Баланс: {Balance:C}"; // Возвращение строки с информацией о счете
        }

        // Метод для перевода денег с одного счета на другой
        public void Transfer(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                throw new ArgumentNullException(nameof(targetAccount), "Целевой счет не может быть null."); // Проверка на null
            }
            Withdraw(amount); // Снятие денег с текущего счета
            targetAccount.Deposit(amount); // Пополнение целевого счета
        }
    }
}
