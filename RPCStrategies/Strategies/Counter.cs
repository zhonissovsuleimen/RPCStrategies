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
            Hand = OpponentsLastPick switch
            {
                Hand.ROCK => Hand.PAPER,
                Hand.PAPER => Hand.SCISSORS,
                Hand.SCISSORS => Hand.ROCK,
                _ => Hand.NOT_PICKED,
            };
        }
    }
}
