using ControleFinanceiroConsoleApp.Account;
using ControleFinanceiroConsoleApp.User.Validation;

namespace ControleFinanceiroConsoleApp.User
{
    public class Users : UserService
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Email Email { get; set; } 
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<AccountService> BankAccounts { get; set; } = new List<AccountService>();

        public Users(string name, string email, string phone, string password)
        { 
            Name = name;
            Email = new Email(email);
            Phone = phone;
            Password = password;

        }
    }
}
