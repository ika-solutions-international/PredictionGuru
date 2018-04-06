using System;
using System.Collections.Generic;

namespace PredictionGuru.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            MatchResultPrediction = new HashSet<MatchResultPrediction>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinUtcDate { get; set; }
        public string Gender { get; set; }

        public ICollection<MatchResultPrediction> MatchResultPrediction { get; set; }
    }
}
