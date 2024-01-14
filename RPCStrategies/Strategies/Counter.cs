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
            if (OpponentsLastPick == Hand.NOT_PICKED)
            {
                Hand = GetRandomHand();
                return;
            }

            Hand = GetCounter(OpponentsLastPick);
        }

        public new void Play(Hand opponentHand)
        {
            OpponentsLastPick = opponentHand;
        }
    }
}
