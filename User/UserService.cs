using ControleFinanceiroConsoleApp.User;
using ControleFinanceiroConsoleApp.User.ValueObject;

public class UserService
{
    public Dictionary<Guid, Users> users = new Dictionary<Guid, Users>();

    public void AddUser(string name, Email email, string phone, string password)
    {
        try
        {
            Users newUser = new Users(name, email, phone, password);

            users.Add(newUser.Id, newUser);

            Console.WriteLine($"Usuário '{name}' adicionado com sucesso! ID: {newUser.Id}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao adicionar usuário: {ex.Message}");
        }
    }
    public void ListUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado!");
            return;
        }

        Console.WriteLine("=== Lista de Usuários ===");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Key}, Nome: {user.Value.Name}, E-mail: {user.Value.Email.Address}");
        }
    }
}
