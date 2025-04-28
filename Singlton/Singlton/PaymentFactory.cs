using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singlton;

public class PaymentFactory
{
    public static IPaymentSysteam GetObject(string option)
    {
        if (option.ToLower() == "uzum") return new UzumPayment();
        if (option.ToLower() == "payme") return new PaymePayment();
       
        throw new Exception($"your option : {option} not our system");
    }
}
