using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCStrategies.Strategies
{
    internal class WinKeepLoseSwitch : AbstractStrategy
    {
        bool WonLastRound = false;
        public new void Pick()
        {
            if (WonLastRound) { return; }

            var random = new System.Random();
            Hand = random.Next(0, 3) switch
            {
                0 => Hand.ROCK,
                1 => Hand.PAPER,
                _ => Hand.SCISSORS,
            };
        }

        public new void Play(Hand opponentHand)
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
