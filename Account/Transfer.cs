namespace ControleFinanceiroConsoleApp.Account;
public abstract class Transfer
{
    Guid Id { get; set; } = Guid.NewGuid();
    double TransferValue { get; set; }
}
