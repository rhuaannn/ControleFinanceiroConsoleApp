using ControleFinanceiroConsoleApp.Account;
using System.Collections.Generic;

namespace ControleFinanceiroConsoleApp.User
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
