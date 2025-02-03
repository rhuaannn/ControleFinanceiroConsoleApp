using ControleFinanceiroConsoleApp.Account;

namespace ControleFinanceiroConsoleApp.User
{
    public class Users : UserService
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<AccountService> BankAccounts { get; set; } = new List<AccountService>();

        public Users(string name, string email, string phone, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;

        }
    }
}
