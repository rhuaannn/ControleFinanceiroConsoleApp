namespace ControleFinanceiroConsoleApp.Interface;
public interface IPayments
{
    decimal PaymentCard();
    decimal PaymentBankSlip();
    decimal PaymentPix();
}
