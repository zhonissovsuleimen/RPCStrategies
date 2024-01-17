using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSStrategies.Strategies
{
    internal class LeastPickedCounter : AbstractStrategy
    {
        Dictionary<Hand, uint> count = new Dictionary<Hand, uint>();

        public LeastPickedCounter()
        {
            count.Add(Hand.ROCK, 0);
            count.Add(Hand.PAPER, 0);
            count.Add(Hand.SCISSORS, 0);
        }

        public override void Pick()
        {
            if (!count.Values.Any(v => v != 0))
            {
                Hand = GetRandomHand();
                return;
            }

            var leastPickedHands = count.Where(kvp => kvp.Value == count.Values.Min()).Select(kvp => kvp.Key);

            var random = new System.Random();
            Hand leastPicked = leastPickedHands.ElementAt(random.Next(0, leastPickedHands.Count()));
            Hand = leastPicked switch
            {
                Hand.ROCK => Hand.SCISSORS,
                Hand.PAPER => Hand.ROCK,
                Hand.SCISSORS => Hand.PAPER,
                _ => Hand.NOT_PICKED
            };
        }
        public override void Play(Hand opponentHand)
        {
            count[opponentHand] += 1;
        }

        public override void Reset()
        {
            count[Hand.ROCK] = 0;
            count[Hand.PAPER] = 0;
            count[Hand.SCISSORS] = 0;
        }
    }
}
