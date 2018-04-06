using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class MatchScoreCard
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public DateTime ScoreUtcTime { get; set; }

        public Match Match { get; set; }
        public PlayerProfile Player { get; set; }
        public Team Team { get; set; }
    }
}
