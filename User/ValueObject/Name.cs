namespace ControleFinanceiroConsoleApp.User.ValueObject
{
   public class Name
    {
        public string FullName { get; private set; } = string.Empty;

        public void IsNameValid(string name)
        {
            if (!IsValid(name))
            {
                throw new ArgumentException("Nome inválido.");
            }
            FullName = name;
        }
        public static bool IsValid(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
        public Name(string name)
        {
            IsNameValid(name);
        }

        public override string ToString() => FullName;
    }
}
