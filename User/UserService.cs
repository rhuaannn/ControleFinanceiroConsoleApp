using ControleFinanceiroConsoleApp.User;
using ControleFinanceiroConsoleApp.User.ValueObject;

public class UserService
{
    public Dictionary<Guid, Users> users = new Dictionary<Guid, Users>();

    public bool EmailExists(string email)
    {
        return users.Values.Any(u => u.Email.Address == email);
    }

    public bool PhoneIsValid(string number)
    {
        if (number.Length != 11)
        {
            return false;

        }

        return true;
    }
    public void AddUser(Name name, Email email, Phone phone, string password)
    {
        if (EmailExists(email.Address))
        {
            Console.WriteLine("Email já existe!");
            return;
        }

        if (!PhoneIsValid(phone.Number))
        {
            Console.WriteLine("Numero inválado!");
            return;
        }
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
