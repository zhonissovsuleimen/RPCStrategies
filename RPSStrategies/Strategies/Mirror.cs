using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSStrategies.Strategies
{
    internal class Mirror : AbstractStrategy
    {
        Hand OpponentsLastPick;

        public override void Pick()
        {
            if (OpponentsLastPick == Hand.NOT_PICKED)
            {
                Hand = GetRandomHand();
                return;
            }

            Hand = OpponentsLastPick;
        }

        public override void Play(Hand opponentHand)
        {
            OpponentsLastPick = opponentHand;
        }

        public override void Reset()
        {
            OpponentsLastPick = Hand.NOT_PICKED;
        }
    }
}
