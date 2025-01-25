
using ControleFinanceiroConsoleApp.User;

namespace ControleFinanceiroConsoleApp.Account;
public class BankAccount : Account
{
    public override Dictionary<int, double> NumberAccount { get; set; } = new Dictionary<int, double>();
    public override Dictionary<int, double> RegisterDepositAccountHistory { get; set; } = new Dictionary<int, double>();
    public override Dictionary<int, double> RegisterWithdrawalAccountHistory { get; set; } = new Dictionary<int, double>();

    public Dictionary<int, int> AccountUserAssociation { get; set; } = new Dictionary<int, int>();

    public void CreateBankAccount()
    {
        Console.Write("Digite o número da conta: ");
        var accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Digite o saldo inicial: ");
        var balance = double.Parse(Console.ReadLine());

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

    public void LinkUserAccount(Dictionary<Guid, Users> users, BankAccount bankAccount)
    {
        Console.Write("Digite o ID do usuário: ");
        var userId = Guid.Parse(Console.ReadLine());
        if (!users.ContainsKey(userId))
        {
            Console.WriteLine("Usuário não encontrado!");
            return;
        }

        Console.Write("Digite o número da conta a ser vinculada: ");
        var accountNumber = int.Parse(Console.ReadLine());

        if (!bankAccount.NumberAccount.ContainsKey(accountNumber))
        {
            Console.WriteLine("Conta bancária não encontrada!");
            return;
        }
        if (bankAccount.AccountUserAssociation.ContainsKey(accountNumber))
        {
            Console.WriteLine("Conta já vinculada a um usuário!");
            return;
        }

        users[userId].BankAccounts.Add(bankAccount);

        Console.WriteLine($"Usuário {users[userId].Name} vinculado à conta {accountNumber} com sucesso!");
    }
    public override double Deposit()
    {
        Console.Write("Digite o número da conta: ");
        var accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Digite o valor do depósito: ");
        var amount = double.Parse(Console.ReadLine());
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
            Console.WriteLine($"Deposit made successfully {amount}");
            return amount;
        }
        else
        {
            Console.WriteLine("Account invalid!");
            return 0;
        }

    }

    public override double GetBalance()
    {
        Console.Write("Digite o número da conta: ");
        var accountNumber = int.Parse(Console.ReadLine());
        if (NumberAccount.ContainsKey(accountNumber))
        {
            double currentBalance = NumberAccount[accountNumber];
            Console.WriteLine($"Value {currentBalance}");
            return currentBalance;
        }
        else
        {
            Console.WriteLine($"Data incorrent");
            return 0;
        }

    }

    public override double TransferValue()
    {
        var value = 0;
        Console.Write("Digite o número da conta de origem: ");
        var sourceAccountNumber = int.Parse(Console.ReadLine());
        Console.Write("Digite o número da conta de destino: ");
        var destinationAccountNumber = int.Parse(Console.ReadLine());
        if (!NumberAccount.ContainsKey(sourceAccountNumber))
        {
            Console.WriteLine("Source account does not exist!");
            return 0;
        }

        if (!NumberAccount.ContainsKey(destinationAccountNumber))
        {
            Console.WriteLine("Destination account does not exist!");
            return 0;
        }

        if (value <= 0)
        {
            Console.WriteLine("Invalid transfer amount!");
            return 0;
        }

        if (NumberAccount[sourceAccountNumber] < value)
        {
            Console.WriteLine("Insufficient funds in source account!");
            return 0;
        }
        NumberAccount[sourceAccountNumber] -= value;
        NumberAccount[destinationAccountNumber] += value;

        Console.WriteLine($"Transfer of {value} from account {sourceAccountNumber} to {destinationAccountNumber} completed successfully!");
        return value;
    }


    public override double Withdrawal()
    {
        Console.Write("Digite o número da conta: ");
        var accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Digite o valor do saque: ");
        var amount = double.Parse(Console.ReadLine());
        if (NumberAccount.ContainsKey(accountNumber))
        {
            double currentBalance = NumberAccount[accountNumber];
            if (currentBalance <= amount || amount == 0)
            {
                Console.WriteLine("Value invalid");

            }
            else
            {
                NumberAccount[accountNumber] = currentBalance - amount;
                Console.WriteLine("Withdrawal made successfully");
                RegisterWithdrawalAccountHistory.Add(accountNumber, amount);
            }
        }
        else
        {
            Console.WriteLine("Account invalid!");
        }
        return NumberAccount.ContainsKey(accountNumber) ? NumberAccount[accountNumber] : 0;
    }

    public void VerifyHistoryWithdrawal()
    {
        Console.Write("Digite o número da conta: ");
        var accountNumber = int.Parse(Console.ReadLine());
        if (RegisterWithdrawalAccountHistory.ContainsKey(accountNumber))
        {
            Console.WriteLine("=== Histórico de Saques ===");
            foreach (var withdrawal in RegisterWithdrawalAccountHistory)
            {
                Console.WriteLine($"Valor: {withdrawal.Value}");
            }
        }
        else
        {
            Console.WriteLine("Conta inválida!");
        }
    }
}