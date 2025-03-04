using System.Runtime.CompilerServices;

namespace ControleFinanceiroConsoleApp.User.ValueObject
{
    public class Phone
    {
        public string Number { get; private set; } = string.Empty;

        public void SetPhone(string number)
        {
            if (IsValid(number))
                
            {
                throw new ArgumentException("Número de telefone inválido.");
            }
            Number = number;
        }

        public static bool IsValid(string number) => string.IsNullOrWhiteSpace(number);
        public Phone(string number)
        {
            SetPhone(number);
        }

        public override string ToString() => Number;
        
    }
}
