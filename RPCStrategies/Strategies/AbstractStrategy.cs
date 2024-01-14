namespace RPCStrategies.Strategies
{
    public enum Hand
    {
        NOT_PICKED,
        ROCK,
        PAPER,
        SCISSORS
    }

    public abstract class AbstractStrategy
    {
        public Hand Hand { get; protected set; } = Hand.NOT_PICKED;
        public void Pick() {}
        public void Play(Hand opponentHand) {}

        protected Hand GetRandomHand()
        {
            var random = new System.Random();
            return random.Next(0, 3) switch
            {
                0 => Hand.ROCK,
                1 => Hand.PAPER,
                _ => Hand.SCISSORS,
            };
        }

        protected Hand GetCounter(Hand hand)
        {
            return hand switch
            {
                Hand.ROCK => Hand.PAPER,
                Hand.PAPER => Hand.SCISSORS,
                Hand.SCISSORS => Hand.ROCK,
                _ => Hand.NOT_PICKED
            };
        }
    }
}