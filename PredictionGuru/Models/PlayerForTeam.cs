using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class PlayerForTeam
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public string JerseyNumber { get; set; }
        public string Picture { get; set; }

        public PlayerProfile Player { get; set; }
        public PlayingPosition Position { get; set; }
        public Team Team { get; set; }
    }
}
