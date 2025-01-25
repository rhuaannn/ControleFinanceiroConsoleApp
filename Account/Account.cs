
namespace ControleFinanceiroConsoleApp.Account;
public abstract class Account : Transfer
{
    public abstract Dictionary<int, double> NumberAccount { get; set; }
    public abstract Dictionary<int, double> RegisterDepositAccountHistory { get; set; }
    public abstract Dictionary<int, double> RegisterWithdrawalAccountHistory { get; set; }
    public abstract double Deposit();
    public abstract double Withdrawal();
    public abstract double GetBalance();


}
