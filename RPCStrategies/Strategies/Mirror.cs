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
            Hand = OpponentsLastPick switch
            {
                Hand.ROCK => Hand.ROCK,
                Hand.PAPER => Hand.PAPER,
                Hand.SCISSORS => Hand.SCISSORS,
                _ => Hand.NOT_PICKED,
            };
        }
    }
}
