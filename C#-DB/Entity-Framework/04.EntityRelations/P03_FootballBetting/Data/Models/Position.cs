using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public int PositionId { get; set; }

        [Required]
        public string Name { get; set; }

        [InverseProperty("Position")]
        public ICollection<Player> Players { get; set; }
    }
}