using ControleFinanceiroConsoleApp.User;

public class UserService
{
    public Dictionary<Guid, Users> users = new Dictionary<Guid, Users>();



    public void AddUser(Users user)
    {
        users.Add(user.Id, user);
        Console.WriteLine($"O Id gerado é {user.Id}");
        Console.WriteLine("Usuário criado com sucesso!");

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
            Console.WriteLine($"ID: {user.Key}, Nome: {user.Value.Name}, E-mail: {user.Value.Email}");
        }
    }
}
