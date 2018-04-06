using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class TeamType
    {
        public TeamType()
        {
            Team = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Team> Team { get; set; }
    }
}
