using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCStrategies.Strategies
{
    internal class FrequencyAnalysis : AbstractStrategy
    {
        List<Hand> opponentHandHistory = new List<Hand>();

        public new void Pick()
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
        public new void Play(Hand opponentHand)
        {
            opponentHandHistory.Add(opponentHand);
        }
    }
}
