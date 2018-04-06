using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class MatchResult
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? WinningTeamId { get; set; }
        public int? LosingTeamId { get; set; }
        public bool IsDrawn { get; set; }
        public int MomplayerId { get; set; }

        public Team LosingTeam { get; set; }
        public Match Match { get; set; }
        public PlayerProfile Momplayer { get; set; }
        public Team WinningTeam { get; set; }
    }
}
