using ControleFinanceiroConsoleApp.Account;
using ControleFinanceiroConsoleApp.User;

public class Program
{
    public static void Main(string[] args)
    {
        BankAccount bankAccount = new BankAccount();
        UserService userService = new UserService();
        GetInputUser getInputUser = new GetInputUser();


        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Menu Interativo ===");
            Console.WriteLine("1. Criar Usuário");
            Console.WriteLine("2. Listar Usuários");
            Console.WriteLine("3. Criar Conta Bancária");
            Console.WriteLine("4. Vincular Usuário a Conta Bancária");
            Console.WriteLine("5. Depositar");
            Console.WriteLine("6. Sacar");
            Console.WriteLine("7. Transferir");
            Console.WriteLine("8. Consultar Saldo");
            Console.WriteLine("9. Verificar Histório de saque");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    userService.AddUser(getInputUser.GetInput());
                    break;
                case "2":
                    userService.ListUsers();
                    break;
                case "3":
                    bankAccount.CreateBankAccount();
                    break;
                case "4":
                    bankAccount.LinkUserAccount(userService.users, bankAccount);
                    break;
                case "5":
                    bankAccount.Deposit();
                    break;
                case "6":
                    bankAccount.Withdrawal();
                    break;
                case "8":
                    bankAccount.GetBalance();
                    break;
                case "7":
                    bankAccount.TransferValue();
                    break;
                case "9":
                    bankAccount.VerifyHistoryWithdrawal();
                    break;
                case "0":
                    Console.WriteLine("Saindo do sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

}