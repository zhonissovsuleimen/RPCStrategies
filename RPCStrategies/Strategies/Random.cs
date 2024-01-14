

namespace RPCStrategies.Strategies
{
    internal class Random : AbstractStrategy
    {
        public new void Pick()
        {
            Hand = GetRandomHand();
        }
    }
}
