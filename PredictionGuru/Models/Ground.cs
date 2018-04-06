using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class Ground
    {
        public Ground()
        {
            Match = new HashSet<Match>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public Country Country { get; set; }
        public ICollection<Match> Match { get; set; }
    }
}
