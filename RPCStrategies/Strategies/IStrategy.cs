using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCStrategies.Strategies
{
    public enum Hand
    {
        NOT_PICKED,
        ROCK,
        PAPER,
        SCISSORS
    }

    internal interface IStrategy
    {
        public void Pick();
        public void Play(Hand opponentHand);
    }
}
