using ControleFinanceiroConsoleApp.Account;
using ControleFinanceiroConsoleApp.User;

public class Program
{
    public static void Main(string[] args)
    {
        GetInputUser getInputUser = new GetInputUser();
        UserService userService = new UserService();

        Validation validation = new Validation();
        AccountService accountService = new AccountService(validation);
        GetInputAccount getInputAccount = new GetInputAccount(accountService);


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
            Console.WriteLine("9. Verificar Histórico de saque");
            Console.WriteLine("10. Verificar Histórico de depósito");
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
                    getInputAccount.CreateBankAccount();
                    break;
                case "4":
                    getInputAccount.LinkUserAccount();
                    break;
                case "5":
                    getInputAccount.Deposit();
                    break;
                case "6":
                    getInputAccount.Withdrawal();
                    break;
                case "8":
                    getInputAccount.GetBalance();
                    break;
                case "7":
                    getInputAccount.TransferValue();
                    break;
                case "9":
                    getInputAccount.VerifyHistoryWithdrawal();
                    break;
                case "10":
                    getInputAccount.VerifyHistoryDeposit();
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