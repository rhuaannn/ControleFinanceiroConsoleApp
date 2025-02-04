namespace ControleFinanceiroConsoleApp.Account;
public class Validation
{
    public bool ValidateAccountNumber(int accountNumber)
    {

        if (accountNumber.ToString().Length <= 2)
        {
            Console.WriteLine("Número de conta inválido!");
            return false;
        }
        return true;
    }
}
