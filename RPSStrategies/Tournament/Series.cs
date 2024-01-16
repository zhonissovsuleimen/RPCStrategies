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
        public (Hand, Hand)[] HandsHistory { get; init; }

        public bool OvertimeEnabled { get; init; }
        public List<(Hand, Hand)> OvertimeHandsHistory { get; } = new(); 

        public Series(AbstractStrategy player1, AbstractStrategy player2, int numberOfRounds = 19, bool overtimeEnabled = false)
        {
            Player1 = player1;
            Player2 = player2;
            OvertimeEnabled = overtimeEnabled;

            NumberOfRounds = numberOfRounds;
            HandsHistory = new (Hand, Hand)[numberOfRounds];
        }

        public void Play()
        {
            Player1.Reset();
            Player2.Reset();

            for (int i = 0; i < NumberOfRounds; i++)
            {
                Player1.Pick();
                Player2.Pick();

                HandsHistory[i] = (Player1.Hand, Player2.Hand);

                Player1.Play(Player2.Hand);
                Player2.Play(Player1.Hand);
            }

            DecideOutcome();
            if (!OvertimeEnabled)
            {
                return;
            }

            //sudden death overtime
            do
            {
                Player1.Pick();
                Player2.Pick();
                
                OvertimeHandsHistory.Add((Player1.Hand, Player2.Hand));

                Player1.Play(Player2.Hand);
                Player2.Play(Player1.Hand);

            } while (Player1.Hand == Player2.Hand);
        }

        void DecideOutcome()
        {
            int sum = 0;

            if(OvertimeHandsHistory.Count == 0)
            {
                foreach (var (p1, p2) in HandsHistory)
                {
                    int singleRound = p1 switch
                    {
                        _ when p1 == p2 => 0,
                        Hand.ROCK => p2 == Hand.SCISSORS ? 1 : -1,
                        Hand.PAPER => p2 == Hand.ROCK ? 1 : -1,
                        Hand.SCISSORS => p2 == Hand.PAPER ? 1 : -1,
                        _ => throw new Exception("Unexpected match outcome")
                    };
                    sum += singleRound;
                }
            }
            else
            {
                var(p1, p2) = OvertimeHandsHistory[^1];
                int decider = p1 switch
                {
                    Hand.ROCK => p2 == Hand.SCISSORS ? 1 : -1,
                    Hand.PAPER => p2 == Hand.ROCK ? 1 : -1,
                    Hand.SCISSORS => p2 == Hand.PAPER ? 1 : -1,
                    _ => throw new Exception("Unexpected match outcome")
                };
                sum += decider;
            }

            Outcome = sum switch
            {
                0 => Outcome.TIE,
                > 0 => Outcome.PLAYER1_WIN,
                < 0 => Outcome.PLAYER2_WIN
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Player 1: {Player1.GetType().Name}\n");
            sb.Append($"Player 2: {Player2.GetType().Name}\n");
            sb.Append($"Outcome: {Outcome.ToString()}\n");

            return sb.ToString();
        }
    }
}
