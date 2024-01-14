

namespace RPCStrategies.Strategies
{
    internal class Random : AbstractStrategy
    {
        public new void Pick()
        {
            var random = new System.Random();
            Hand = random.Next(0, 3) switch
            {
                0 => Hand.ROCK,
                1 => Hand.PAPER,
                _ => Hand.SCISSORS,
            };
        }
    }
}
