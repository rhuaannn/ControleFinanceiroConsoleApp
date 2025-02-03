using System.Net.Mail;

namespace ControleFinanceiroConsoleApp.User.Validation;
public abstract class Validation
{
    public bool ValidateEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return true;
        }
        catch
        {

            return false;

        }
    }
    public bool ValidatePhone(string phone)
    {
        if (phone.Length != 11)
        {
            Console.WriteLine("Telefone inválido!");
            return false;
        }
        return true;
    }
    public abstract bool VerifyPhoneInUser(string phone);
    public abstract bool VerifyEmailInUser(string email);


}
