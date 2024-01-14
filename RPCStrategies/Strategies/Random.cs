﻿

namespace RPCStrategies.Strategies
{
    internal class Random : AbstractStrategy
    {
        public override void Pick()
        {
            Hand = GetRandomHand();
        }

        public override void Play(Hand opponentHand) {}
    }
}
