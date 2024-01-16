using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPSStrategies.Strategies;

namespace RPSStrategies.Tournament
{
    public enum Outcome
    {
        NOT_STARTED,
        PLAYER1_WIN,
        PLAYER2_WIN,
        TIE
    }

    internal class Series
    {
        public AbstractStrategy Player1 { get; init; }
        public AbstractStrategy Player2 { get; init; }
        public Outcome Outcome { get; private set; } = Outcome.NOT_STARTED;

        public int NumberOfRounds { get; init; }
        public int[] Rounds { get; init; }
        public bool OvertimeEnabled { get; init; }
        public List<int> Overtime { get; } = new List<int>(); 

        public Series(AbstractStrategy player1, AbstractStrategy player2, int numberOfRounds = 19, bool overtimeEnabled = false)
        {
            Player1 = player1;
            Player2 = player2;
            NumberOfRounds = numberOfRounds;
            Rounds = new int[numberOfRounds];
            OvertimeEnabled = overtimeEnabled;
        }

        public void Play()
        {
            Player1.Reset();
            Player2.Reset();

            for (int i = 0; i < NumberOfRounds; i++)
            {
                Player1.Pick();
                Player2.Pick();

                Rounds[i] = GetIntOutcome(Player1.Hand, Player2.Hand);

                Player1.Play(Player2.Hand);
                Player2.Play(Player1.Hand);
            }

            int count = Rounds.Sum();
            if (OvertimeEnabled)
            {
                Outcome = count > 0 ? Outcome.PLAYER1_WIN : count < 0 ? Outcome.PLAYER2_WIN : Outcome.TIE;
                return;
            }

            do
            {
                Player1.Pick();
                Player2.Pick();
                
                Overtime.Add(GetIntOutcome(Player1.Hand, Player2.Hand));

                Player1.Play(Player2.Hand);
                Player2.Play(Player1.Hand);

            } while (Player1.Hand == Player2.Hand);

            count += Overtime.Last();
            Outcome = count > 0 ? Outcome.PLAYER1_WIN : Outcome.PLAYER2_WIN;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Player 1: {Player1.GetType().Name}\n");
            sb.Append($"Player 2: {Player2.GetType().Name}\n");
            sb.Append($"Outcome: {Outcome.ToString()}\n");

            if (Outcome == Outcome.NOT_STARTED)
            {
                return sb.ToString();
            }

            sb.Append($"Rounds: ");
            for (int i = 0; i < Rounds.Length; i++)
            {
                string result = Rounds[i] > 0 ? "P1" : Rounds[i] < 0 ? "P2" : "TIE";
                sb.Append($"{result}; ");
            }
            sb.Append("\n");

            
            if (Overtime.Count > 0)
            {
                sb.Append($"Overtime: ");
                for (int i = 0; i < Overtime.Count; i++)
                {
                    string result = Overtime[i] > 0 ? "P1" : Overtime[i] < 0 ? "P2" : "TIE";
                    sb.Append($"{result}; ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
