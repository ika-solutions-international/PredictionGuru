using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class Country
    {
        public Country()
        {
            Ground = new HashSet<Ground>();
            PlayerProfile = new HashSet<PlayerProfile>();
            Team = new HashSet<Team>();
        }

        public int Id { get; set; }
        public int ContinentId { get; set; }
        public string Name { get; set; }

        public Continent Continent { get; set; }
        public ICollection<Ground> Ground { get; set; }
        public ICollection<PlayerProfile> PlayerProfile { get; set; }
        public ICollection<Team> Team { get; set; }
    }
}
