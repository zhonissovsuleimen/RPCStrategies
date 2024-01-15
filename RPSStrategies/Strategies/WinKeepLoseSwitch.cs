using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSStrategies.Strategies
{
    internal class WinKeepLoseSwitch : AbstractStrategy
    {
        bool WonLastRound = false;
        public override void Pick()
        {
            if (WonLastRound) { return; }

            Hand = GetRandomHand();
        }

        public override void Play(Hand opponentHand)
        {
            WonLastRound = opponentHand switch
            {
                Hand.ROCK => Hand == Hand.PAPER,
                Hand.PAPER => Hand == Hand.SCISSORS,
                Hand.SCISSORS => Hand == Hand.ROCK,
                _ => true
            };
        }
    }
}
