using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class PlayerProfile
    {
        public PlayerProfile()
        {
            MatchResult = new HashSet<MatchResult>();
            MatchScoreCard = new HashSet<MatchScoreCard>();
            PlayerForTeam = new HashSet<PlayerForTeam>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public ICollection<MatchResult> MatchResult { get; set; }
        public ICollection<MatchScoreCard> MatchScoreCard { get; set; }
        public ICollection<PlayerForTeam> PlayerForTeam { get; set; }
    }
}
