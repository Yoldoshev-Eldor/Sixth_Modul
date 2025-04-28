namespace StrategyAndFactory;

public class Factory
{
    public static IMessage GetObject(string option)
    {
        if (option.ToLower() == "sms") return new Sms();
        if (option.ToLower() == "insatgram") return new Instagram();
        if (option.ToLower() == "telegram") return new Telegram();
        if (option.ToLower() == "email") return new Emil();
        throw new Exception("not exists");        
    }
}
