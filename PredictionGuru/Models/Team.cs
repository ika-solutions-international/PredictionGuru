using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class Team
    {
        public Team()
        {
            MatchAwayTeam = new HashSet<Match>();
            MatchHomeTeam = new HashSet<Match>();
            MatchResultLosingTeam = new HashSet<MatchResult>();
            MatchResultPredictionLosingTeam = new HashSet<MatchResultPrediction>();
            MatchResultPredictionWinningTeam = new HashSet<MatchResultPrediction>();
            MatchResultWinningTeam = new HashSet<MatchResult>();
            MatchScoreCard = new HashSet<MatchScoreCard>();
            PlayerForTeam = new HashSet<PlayerForTeam>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public Country Country { get; set; }
        public TeamType Type { get; set; }
        public ICollection<Match> MatchAwayTeam { get; set; }
        public ICollection<Match> MatchHomeTeam { get; set; }
        public ICollection<MatchResult> MatchResultLosingTeam { get; set; }
        public ICollection<MatchResultPrediction> MatchResultPredictionLosingTeam { get; set; }
        public ICollection<MatchResultPrediction> MatchResultPredictionWinningTeam { get; set; }
        public ICollection<MatchResult> MatchResultWinningTeam { get; set; }
        public ICollection<MatchScoreCard> MatchScoreCard { get; set; }
        public ICollection<PlayerForTeam> PlayerForTeam { get; set; }
    }
}
