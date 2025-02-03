using ControleFinanceiroConsoleApp.User;

namespace ControleFinanceiroConsoleApp.Account;
public class GetInputAccount
{
    private readonly AccountService _accountService;

    public GetInputAccount(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void CreateBankAccount()
    {
        Console.Write("Digite o número da conta: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Número inválido!");
            return;
        }

        Console.Write("Digite o saldo inicial: ");
        if (!double.TryParse(Console.ReadLine(), out double balance))
        {
            Console.WriteLine("Saldo inválido!");
            return;
        }

        _accountService.CreateBankAccount(accountNumber, balance);
    }

    public void LinkUserAccount()
    {
        Console.Write("Digite o número da conta a ser vinculada: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Número da conta inválido!");
            return;
        }
        Console.Write("Digite o ID do usuário: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid userId))
        {
            Console.WriteLine("ID inválido!");
            return;
        }

        _accountService.LinkUserAccount(accountNumber, userId);

    }

    public void Deposit()
    {
        Console.Write("Digite o número da conta: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Número inválido!");
            return;
        }

        Console.Write("Digite o valor do depósito: ");
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Valor inválido!");
            return;
        }

        _accountService.Deposit(accountNumber, amount);
    }

    public void Withdrawal()
    {
        Console.Write("Digite o número da conta: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Número inválido!");
            return;
        }

        Console.Write("Digite o valor do saque: ");
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Valor inválido!");
            return;
        }

        _accountService.Withdrawal(accountNumber, amount);
    }

    public void TransferValue()
    {
        Console.Write("Digite o número da conta de origem: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumberOrigin))
        {
            Console.WriteLine("Número inválido!");
            return;
        }

        Console.Write("Digite o número da conta de destino: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumberDestiny))
        {
            Console.WriteLine("Número inválido!");
            return;
        }

        Console.WriteLine("Digite o valor");

        if (!double.TryParse(Console.ReadLine(), out double value))
        {
            Console.WriteLine("Valor inválido!");
        }

        _accountService.TransferValue(accountNumberOrigin, accountNumberDestiny, value);
    }

    public void GetBalance()
    {
        Console.Write("Digite o número da conta: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Número inválido!");
            return;
        }

        _accountService.GetBalance(accountNumber);
    }

    public void VerifyHistoryWithdrawal()
    {
        Console.Write("Digite o número da conta: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Número inválido!");
            return;
        }

        var history = _accountService.RegisterWithdrawalAccountHistory
                       .Where(h => h.accountNumber == accountNumber);
        if (history != default)
        {
            Console.WriteLine($"Histórico de saques para a conta {accountNumber}:{history.Count()}");
        }
        else
        {
            Console.WriteLine("Nenhum histórico de saques encontrado para esta conta.");
        }
    }

    public void VerifyHistoryDeposit()
    {
        Console.Write("Digite o número da conta: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Número inválido!");
            return;
        }
        var history = _accountService.RegisterDepositAccountHistory
                       .FirstOrDefault(h => h.Key == accountNumber);
        if (history.Value != default)
        {
            Console.WriteLine($"Histórico de depósitos para a conta {accountNumber}: Valor total: -{history.Value}");
        }
        else
        {
            Console.WriteLine("Nenhum histórico de depósitos encontrado para esta conta.");
        }
    }
}
