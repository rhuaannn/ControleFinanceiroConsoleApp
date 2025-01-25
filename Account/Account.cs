using ControleFinanceiroConsoleApp.Interface;

namespace ControleFinanceiroConsoleApp.Account;
public abstract class Account : IPayments
{
    public abstract Dictionary<int, double> NumberAccount { get; set; }
    public abstract Dictionary<int, double> RegisterDepositAccountHistory { get; set; }
    public abstract Dictionary<int, double> RegisterWithdrawalAccountHistory { get; set; }
    public abstract double Balance(int accountNumber, double balance);
    public abstract double Deposit(int accountNumber, double amount);
    public abstract double Withdrawal(double amount, int accountNumber);
    public abstract double GetBalance(int accountNumber);

    public decimal PaymentBankSlip()
    {
        throw new NotImplementedException();
    }

    public decimal PaymentCard()
    {
        throw new NotImplementedException();
    }
    public decimal PaymentPix()
    {
        throw new NotImplementedException();
    }
}
