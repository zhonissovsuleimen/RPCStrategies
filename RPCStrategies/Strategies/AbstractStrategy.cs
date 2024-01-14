namespace RPCStrategies.Strategies
{
    public abstract class AbstractStrategy : IStrategy
    {
        public Hand Hand = Hand.NOT_PICKED;
        public void Pick() {}
    }
}