
namespace ControleFinanceiroConsoleApp.Account;
public abstract class Account : RegisterAccountHistory
{
    public abstract Dictionary<int, double> NumberAccount { get; set; }

}
