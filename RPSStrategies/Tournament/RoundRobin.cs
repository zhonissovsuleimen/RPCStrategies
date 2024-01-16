using System.Text;
using RPSStrategies.Strategies;

namespace RPSStrategies.Tournament
{
    internal class RoundRobin
    {
        public List<AbstractStrategy> Players { get; init; }
        //temporary scoring system
        public List<int> Scores { get; init; }

        public int WinReward { get; init; } = 2;
        public int TieReward { get; init; } = 1;
        public int LossReward { get; init; } = 0;

        public int SeriesRounds { get; init; } = 100;
        public bool OvertimeEnabled { get; init; } = false;

        public RoundRobin(params AbstractStrategy[] players)
        {
            Players = new(players);
            Scores = new List<int>(new int[players.Length]);
        }

        public void Run()
        {
            //temporary scoring system
            for (int i = 0; i < Players.Count; i++)
            {
                for (int j = i + 1; j < Players.Count; j++)
                {
                    Series series = new(Players[i], Players[j], SeriesRounds);
                    series.Play();

                    switch (series.Outcome)
                    {
                        case Outcome.PLAYER1_WIN:
                            Scores[i] += WinReward;
                            Scores[j] += LossReward;
                            break;
                        case Outcome.PLAYER2_WIN:
                            Scores[i] += LossReward;
                            Scores[j] += WinReward;
                            break;
                        case Outcome.TIE:
                            Scores[i] += TieReward;
                            Scores[j] += TieReward;
                            break;
                    }
                }
            }
        }

        public string GetScores()
        {
            StringBuilder sb = new();
            for (int i = 0; i < Players.Count; i++)
            {
                sb.Append($"{Players[i].GetType().Name}: {Scores[i]}\n");
            }
            return sb.ToString();
        }
    }
}
