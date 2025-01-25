
namespace ControleFinanceiroConsoleApp.Account;
public class BankAccount : Account
{
    public override Dictionary<int, double> NumberAccount { get; set; } = new Dictionary<int, double>();
    public override Dictionary<int, double> RegisterDepositAccountHistory { get; set; } = new Dictionary<int, double>();
    public override Dictionary<int, double> RegisterWithdrawalAccountHistory { get; set; } = new Dictionary<int, double>();
    public override double Balance(int idAccount, double balance)
    {
        throw new NotImplementedException();
    }

    public void CreateBankAccount(int accountNumber, double balance)
    {
        if (NumberAccount.ContainsKey(accountNumber))
        {
            Console.WriteLine("Account already exists");
            return;
        }
        else
        {
            NumberAccount.Add(accountNumber, balance);
            Console.WriteLine("Account created successfully");
        }

    }

    public override double Deposit(int accountNumber, double amount)
    {
        if (NumberAccount.ContainsKey(accountNumber))
        {
            double currentBalance = NumberAccount[accountNumber];
            if (amount <= 0)
            {
                Console.WriteLine("Value invalid");
                return currentBalance;
            }

            currentBalance += amount;
            NumberAccount[accountNumber] = currentBalance;
            RegisterDepositAccountHistory.Add(accountNumber, currentBalance);
            return amount;
        }
        else
        {
            Console.WriteLine("Account invalid!");
            return 0;
        }

    }

    public override double GetBalance(int accountNumber)
    {
        double currentBalance = NumberAccount[accountNumber];
        if (NumberAccount.ContainsKey(accountNumber))
        {
            Console.WriteLine($"Value {currentBalance}");
            return 0;
        }
        else
        {
            Console.WriteLine($"Value Invalid!");
        }
        return currentBalance;
    }

    public override double Withdrawal(double amount, int accountNumber)
    {
        if (NumberAccount.ContainsKey(accountNumber))
        {
            double currentBalance = NumberAccount[accountNumber];
            if (currentBalance <= amount)
            {
                Console.WriteLine("Value invalid");

            }
            else
            {
                NumberAccount[accountNumber] = currentBalance - amount;
                Console.WriteLine("Withdrawal made successfully");
                RegisterWithdrawalAccountHistory.Add(accountNumber, currentBalance - amount);
            }
        }
        else
        {
            Console.WriteLine("Account invalid!");
        }
        return NumberAccount.ContainsKey(accountNumber) ? NumberAccount[accountNumber] : 0;
    }

}