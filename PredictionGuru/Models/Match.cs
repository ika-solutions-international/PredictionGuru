using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class Match
    {
        public Match()
        {
            MatchResult = new HashSet<MatchResult>();
            MatchResultPrediction = new HashSet<MatchResultPrediction>();
            MatchScoreCard = new HashSet<MatchScoreCard>();
        }

        public int Id { get; set; }
        public int GroundId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime StartUtcDate { get; set; }
        public DateTime EndUtcDate { get; set; }

        public Team AwayTeam { get; set; }
        public Ground Ground { get; set; }
        public Team HomeTeam { get; set; }
        public ICollection<MatchResult> MatchResult { get; set; }
        public ICollection<MatchResultPrediction> MatchResultPrediction { get; set; }
        public ICollection<MatchScoreCard> MatchScoreCard { get; set; }
    }
}
