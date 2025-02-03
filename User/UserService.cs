using ControleFinanceiroConsoleApp.User;
using ControleFinanceiroConsoleApp.User.Validation;

public class UserService : Validation
{
    public Dictionary<Guid, Users> users = new Dictionary<Guid, Users>();

    public void AddUser(Users user)
    {
        if (ValidateEmail(user.Email))
        {
            if (VerifyEmailInUser(user.Email))
            {
                Console.WriteLine("E-mail já cadastrado!");
                return;
            }
            else if (VerifyPhoneInUser(user.Phone))
            {
                Console.WriteLine("Telefone já cadastrado!");
                return;
            }
            else
            {
                users.Add(user.Id, user);
                Console.WriteLine($"O Id gerado é {user.Id}");
                Console.WriteLine("Usuário criado com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("E-mail inválido!");
            return;
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
            Console.WriteLine($"ID: {user.Key}, Nome: {user.Value.Name}, E-mail: {user.Value.Email}");
        }
    }
    public override bool VerifyEmailInUser(string email)
    {
        if (users.Values.Any(user => user.Email == email))
        {
            return true;
        }
        return false;
    }
    public override bool VerifyPhoneInUser(string phone)
    {
        if (users.Values.Any(user => user.Phone == phone))
        {
            return true;
        }
        return false;
    }
}
