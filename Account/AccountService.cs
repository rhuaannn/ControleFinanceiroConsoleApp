namespace ControleFinanceiroConsoleApp.Account;
public class AccountService : Account
{
    public override Dictionary<int, double> NumberAccount { get; set; } = new Dictionary<int, double>();
    public Dictionary<int, Guid> AccountUserAssociation { get; set; } = new Dictionary<int, Guid>();

    private readonly Validation _validationAccount;

    public AccountService(Validation validation)
    {
        _validationAccount = validation;
    }

    public void CreateBankAccount(int number, double balance)
    {
        if (!_validationAccount.ValidateAccountNumber(number))
        {
            return;
        }
        else if (NumberAccount.ContainsKey(number))
        {
            Console.WriteLine("Account already exists!");
            return;
        }
        else
        {
            NumberAccount.Add(number, balance);
            Console.WriteLine($"Account created successfully - {number}!");
        }
    }
    public void LinkUserAccount(int number, Guid user)
    {
        if (AccountUserAssociation.ContainsKey(number))
        {
            Console.WriteLine("Conta vinculada a outro usuário!");
            return;
        }
        else
        {
            AccountUserAssociation.Add(number, user);
            Console.WriteLine($"Account created successfully - {number}!");
        }


    }
    public double Deposit(int accountNumber, double amount)
    {
        if (NumberAccount.ContainsKey(accountNumber))
        {
            double currentBalance = NumberAccount[accountNumber];
            if (amount <= 0)
            {
                Console.WriteLine("Value invalid");
                return amount;
            }

            currentBalance += amount;
            NumberAccount[accountNumber] = currentBalance;
            if (RegisterDepositAccountHistory.ContainsKey(accountNumber))
            {
                RegisterDepositAccountHistory[accountNumber] += amount;
            }
            else
            {
                RegisterDepositAccountHistory.Add(accountNumber, amount);
            }
            Console.WriteLine($"Deposit made successfully {amount}");
            return amount;
        }
        else
        {
            Console.WriteLine("Account invalid!");
            return accountNumber;
        }
    }


    public double GetBalance(int accountNumber)
    {

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

    public double TransferValue(int sourceAccountNumber, int destinationAccountNumber, double value)
    {

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


    public double Withdrawal(int accountNumber, double amount)
    {
        if (NumberAccount.ContainsKey(accountNumber))
        {
            double currentBalance = NumberAccount[accountNumber];
            if (currentBalance <= amount || amount == 0)
            {
                Console.WriteLine("Value invalid");

            }
            else
            {
                DateTime data = DateTime.Now;
                NumberAccount[accountNumber] = currentBalance - amount;
                Console.WriteLine($"Withdrawal made successfully! Data {data}");
                RegisterWithdrawalAccountHistory.Add((accountNumber, amount));
            }
        }
        else
        {
            Console.WriteLine("Account invalid!");
        }
        return NumberAccount.ContainsKey(accountNumber) ? NumberAccount[accountNumber] : 0;
    }




}