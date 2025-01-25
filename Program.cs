using ControleFinanceiroConsoleApp.Account;

namespace ControleFinanceiroConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.CreateBankAccount(123, 1000);
            bankAccount.Deposit(123, 10.75);
            bankAccount.GetBalance(123);
            bankAccount.Withdrawal(150, 123);
            bankAccount.GetBalance(123);
        }
    }
}
