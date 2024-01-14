using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCStrategies.Strategies
{
    internal class Counter : AbstractStrategy
    {
        Hand OpponentsLastPick;

        public new void Pick()
        {
            switch (OpponentsLastPick)
            {
                case Hand.ROCK: Hand = Hand.PAPER; break;
                case Hand.PAPER: Hand = Hand.SCISSORS; break;
                case Hand.SCISSORS: Hand = Hand.ROCK; break;
                default:
                    {
                        var random = new System.Random();
                        Hand = random.Next(0, 3) switch
                        {
                            0 => Hand.ROCK,
                            1 => Hand.PAPER,
                            _ => Hand.SCISSORS,
                        };
                        break;
                    }
            };
        }

        public new void Play(Hand opponentHand)
        {
            OpponentsLastPick = opponentHand;
        }
    }
}
