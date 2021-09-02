using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            PrimaryKitTeams = new HashSet<Team>();
            SecondaryKitTeams = new HashSet<Team>();
        }

        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }

        [InverseProperty("PrimaryKitColor")]
        public ICollection<Team> PrimaryKitTeams{ get; set; }


        [InverseProperty("SecondaryKitColor")]
        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}