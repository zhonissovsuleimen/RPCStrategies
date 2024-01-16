

namespace RPSStrategies.Strategies
{
    internal class Random : AbstractStrategy
    {
        public override void Pick()
        {
            Hand = GetRandomHand();
        }

        public override void Play(Hand opponentHand) {}

        public override void Reset() {}
    }
}
