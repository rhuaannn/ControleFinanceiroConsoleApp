using ControleFinanceiroConsoleApp.Account;
using System.Collections.Generic;

namespace ControleFinanceiroConsoleApp.User
{
    public class Users
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

        public void CreateUser(Dictionary<Guid, Users> users)
        {
            Console.Write("Digite o nome: ");
            string name = Console.ReadLine();
            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();
            Console.Write("Digite o telefone: ");
            string phone = Console.ReadLine();
            Console.Write("Digite a senha: ");
            string password = Console.ReadLine();

            Users newUser = new Users
            {
                Name = name,
                Email = email,
                Phone = phone,
                Password = password
            };
            users.Add(newUser.Id, newUser);
            Console.WriteLine($"O Id gerado é {Id}");
            Console.WriteLine("Usuário criado com sucesso!");

        }

        public void ListUsers(Dictionary<Guid, Users> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado!");
                return;
            }

            Console.WriteLine("=== Lista de Usuários ===");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Key}, Nome: {user.Value.Name}, E-mail: {user.Value.Email}");
            }
        }

    }
}
