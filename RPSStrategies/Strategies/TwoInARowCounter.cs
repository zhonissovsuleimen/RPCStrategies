using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSStrategies.Strategies
{
    internal class TwoInARowCounter : AbstractStrategy
    {
        Hand OpponentsLastPick = Hand.NOT_PICKED;
        Hand OpponentsSecondToLastPick = Hand.NOT_PICKED;

        public override void Pick()
        {
            if (OpponentsSecondToLastPick != Hand.NOT_PICKED && OpponentsLastPick == OpponentsSecondToLastPick)
            {
                Hand = GetCounter(OpponentsLastPick);
                return;
            }

            Hand = GetRandomHand();
        }

        public override void Play(Hand opponentHand)
        {
            OpponentsSecondToLastPick = OpponentsLastPick;
            OpponentsLastPick = opponentHand;
        }

        public override void Reset()
        {
            OpponentsLastPick = Hand.NOT_PICKED;
            OpponentsSecondToLastPick = Hand.NOT_PICKED;
        }
    }
}
