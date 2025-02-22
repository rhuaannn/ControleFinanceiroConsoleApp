﻿namespace ControleFinanceiroConsoleApp.User;
public class GetInputUser
{
    public Users GetInput()
    {
        Console.Write("Digite o nome: ");
        string name = Console.ReadLine();
        Console.Write("Digite o e-mail: ");
        string email = Console.ReadLine();
        Console.Write("Digite o telefone: ");
        string phone = Console.ReadLine();
        Console.Write("Digite a senha: ");
        string password = Console.ReadLine();

        try
        {
            return new Users(name, email, phone, password);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return null;
        }
    }
}
