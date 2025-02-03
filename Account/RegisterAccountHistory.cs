namespace ControleFinanceiroConsoleApp.Account;
public class RegisterAccountHistory
{
    public Dictionary<int, double> RegisterDepositAccountHistory { get; set; } = new Dictionary<int, double>();

    public List<(int accountNumber, double amount)> RegisterWithdrawalAccountHistory = new List<(int accountNumber, double amount)>();


}
