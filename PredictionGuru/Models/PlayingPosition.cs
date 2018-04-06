using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class PlayingPosition
    {
        public PlayingPosition()
        {
            PlayerForTeam = new HashSet<PlayerForTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PlayerForTeam> PlayerForTeam { get; set; }
    }
}
