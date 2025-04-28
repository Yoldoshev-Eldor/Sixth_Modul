namespace Singlton;

public class PaymentStrategy
{
    private readonly IPaymentSysteam _option;
    public PaymentStrategy(IPaymentSysteam option)
    {
        _option = option;
    }

    public void Payment(string payment)
    {
        _option.ChoosePayment(payment);
    }
}
