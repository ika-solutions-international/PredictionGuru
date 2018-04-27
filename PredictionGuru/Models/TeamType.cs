using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PredictionGuru.Models
{
    public partial class TeamType
    {
        public TeamType()
        {
            Team = new HashSet<Team>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Team> Team { get; set; }
    }
}
