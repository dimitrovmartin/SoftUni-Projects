using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }

        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        [InverseProperty("Country")]
        public ICollection<Town> Towns { get; set; }
    }
}