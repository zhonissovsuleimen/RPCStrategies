using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCStrategies.Strategies
{
    internal class Mirror : AbstractStrategy
    {
        Hand OpponentsLastPick;

        public new void Pick()
        {
            switch (OpponentsLastPick)
            {
                case Hand.ROCK: Hand = Hand.ROCK; break;
                case Hand.PAPER: Hand = Hand.PAPER; break;
                case Hand.SCISSORS: Hand = Hand.SCISSORS; break;
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

        public new void Play(Hand hand)
        {
            OpponentsLastPick = hand;
        }
    }
}
