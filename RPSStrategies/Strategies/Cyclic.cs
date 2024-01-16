using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSStrategies.Strategies
{
    internal class Cyclic : AbstractStrategy
    {
        Hand[] Sequence = new Hand[3];
        uint counter = 0;

        public Cyclic()
        {
            GenerateSequence();
        }

        public override void Pick()
        {
            Hand = Sequence[counter];
            counter = (counter + 1) % 3;
        }

        public override void Play(Hand opponentHand) {}

        public override void Reset()
        {
            GenerateSequence();
        }

        void GenerateSequence()
        {
            Sequence[0] = GetRandomHand();
            Sequence[1] = GetRandomHand();
            Sequence[2] = GetRandomHand();
        }
    }
}
