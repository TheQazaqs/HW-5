using System; 

namespace HW_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankaccount = new BankAccount("145537258", "Eldos");
            BankAccount user = new BankAccount("172641756", "Rahat");
            bankaccount.Deposit(2000);
            bankaccount.Withdraw(1000);
            bankaccount.Transfer(user, 1000);
            Console.WriteLine(user.GetAccountInfo());
            Console.WriteLine(bankaccount.GetAccountInfo());
        }

    }

}