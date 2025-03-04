using ControleFinanceiroConsoleApp.Account;
using ControleFinanceiroConsoleApp.User.ValueObject;

namespace ControleFinanceiroConsoleApp.User
{
    public class Users
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Name Name { get; set; } 
        public Email Email { get; set; } 
        public Phone Phone { get; set; }
        public string Password { get; set; } = string.Empty;
        public List<AccountService> BankAccounts { get; set; } = new List<AccountService>();

        public Users(Name name, Email email, Phone phone, string password)
        { 
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;

        }
    }
}
