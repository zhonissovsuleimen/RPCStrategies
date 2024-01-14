using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPCStrategies.Strategies;

namespace RPCStrategies.Tournament
{
    internal class Series
    {
        public AbstractStrategy Player1 { get; init; }
        public AbstractStrategy Player2 { get; init; }
        public bool player1Won;

        public int NumberOfRounds { get; init; }
        public int[] Rounds { get; init; }
        public List<int> Overtime { get; } = new List<int>(); 

        public Series(AbstractStrategy player1, AbstractStrategy player2, int numberOfRounds = 19)
        {
            Player1 = player1;
            Player2 = player2;
            NumberOfRounds = numberOfRounds;
            Rounds = new int[numberOfRounds];
        }

        public void Play()
        {
            for (int i = 0; i < NumberOfRounds; i++)
            {
                Player1.Pick();
                Player2.Pick();

                Rounds[i] = GetIntOutcome(Player1.Hand, Player2.Hand);

                Player1.Play(Player2.Hand);
                Player2.Play(Player1.Hand);
            }

            int count = Rounds.Sum();

            //sudden death overtime
            if (count == 0)
            {
                do
                {
                    Player1.Pick();
                    Player2.Pick();

                    Overtime.Add(GetIntOutcome(Player1.Hand, Player2.Hand));

                    Player1.Play(Player2.Hand);
                    Player2.Play(Player1.Hand);
                }while (Player1.Hand != Player2.Hand);
            }

            player1Won = (count + Overtime.Last()) > 0;
        }

        int GetIntOutcome(Hand hand1, Hand hand2)
        {
            if (hand1 == hand2)
            {
                return 0;
            }
            else if (hand1 == Hand.ROCK && hand2 == Hand.SCISSORS ||
                     hand1 == Hand.PAPER && hand2 == Hand.ROCK ||
                     hand1 == Hand.SCISSORS && hand2 == Hand.PAPER)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
