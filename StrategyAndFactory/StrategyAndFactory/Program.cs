namespace StrategyAndFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var option = "sms";
            var factory=  Factory.GetObject(option);    

            var strategy =new Strategy(factory);
            strategy.Message($"opyion(){strategy}");
        }
    }
}
