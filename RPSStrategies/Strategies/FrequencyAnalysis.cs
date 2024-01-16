using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSStrategies.Strategies
{
    internal class FrequencyAnalysis : AbstractStrategy
    {
        List<Hand> opponentHandHistory = new List<Hand>();

        public override void Pick()
        {
            if (opponentHandHistory.Count == 0)
            {
                Hand = GetRandomHand();
                return;
            }

            var random = new System.Random();
            var randomIndex = random.Next(0, opponentHandHistory.Count);
            Hand = GetCounter(opponentHandHistory[randomIndex]);
        }
        public override void Play(Hand opponentHand)
        {
            opponentHandHistory.Add(opponentHand);
        }

        public override void Reset()
        {
            opponentHandHistory.Clear();
        }
    }
}
