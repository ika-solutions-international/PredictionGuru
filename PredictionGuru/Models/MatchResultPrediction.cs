using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class MatchResultPrediction
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? WinningTeamId { get; set; }
        public int? LosingTeamId { get; set; }
        public bool IsDrawn { get; set; }
        public int PredictorUserId { get; set; }

        public Team LosingTeam { get; set; }
        public Match Match { get; set; }
        public UserProfile PredictorUser { get; set; }
        public Team WinningTeam { get; set; }
    }
}
