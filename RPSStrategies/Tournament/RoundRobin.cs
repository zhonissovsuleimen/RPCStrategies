using System.Text;
using System.Linq;
using RPSStrategies.Strategies;


namespace RPSStrategies.Tournament
{
    internal class RoundRobin
    {
        public List<AbstractStrategy> Players { get; init; }
        Dictionary<AbstractStrategy, int> Scores = new();

        public int WinReward { get; init; } = 3;
        public int TieReward { get; init; } = 1;
        public int LossReward { get; init; } = 0;

        public int SeriesRounds { get; set; } = 100;
        public bool SeriesOvertimeEnabled { get; set; } = false;

        public RoundRobin(params AbstractStrategy[] players)
        {
            Players = new(players);
            ResetScores();
        }

        public void Run()
        {
            ResetScores();
            for (int i = 0; i < Players.Count; i++)
            {
                for (int j = i + 1; j < Players.Count; j++)
                {
                    Series series = new(Players[i], Players[j], SeriesRounds, SeriesOvertimeEnabled);
                    series.Play();

                    switch (series.Outcome)
                    {
                        case Outcome.PLAYER1_WIN:
                            Scores[Players[i]] += WinReward;
                            Scores[Players[j]] += LossReward;
                            break;
                        case Outcome.PLAYER2_WIN:
                            Scores[Players[i]] += LossReward;
                            Scores[Players[j]] += WinReward;
                            break;
                        case Outcome.TIE:
                            Scores[Players[i]] += TieReward;
                            Scores[Players[j]] += TieReward;
                            break;
                    }
                }
            }
        }

        public string GetScores()
        {
            StringBuilder sb = new();
            var scoresList = Scores.OrderByDescending(x => x.Value);
            foreach(var score in scoresList)
            {
                sb.AppendLine($"{score.Key.GetType().Name}: {score.Value}");
            }
            return sb.ToString();
        }

        void ResetScores()
        {
            Scores.Clear();
            for (int i = 0; i < Players.Count; i++)
            {
                Scores.Add(Players[i], 0);
            }
        }
    }
}
