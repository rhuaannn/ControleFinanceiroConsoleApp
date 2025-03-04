using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ControleFinanceiroConsoleApp.User.ValueObject;


    public class Email
    {
        public string Address { get; private set; }

        public void SetEmail(string address)
        {
            if (!IsValid(address))
            {
                throw new ArgumentException("Endereço de e-mail inválido.");
            }
            Address = address;
        }
        public Email(string address)
        {
            SetEmail(address);
        }

        public static bool IsValid(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && new EmailAddressAttribute().IsValid(email);
        }

        public override string ToString() => Address;
    }
