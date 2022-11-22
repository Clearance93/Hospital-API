using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ParkyApplication.Models.TrailModels;

namespace ParkyApplication.Models.Dtos
{
    public class TrailDto
    {
        public int trailId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Distance { get; set; }
        public DifficultyType difficulty { get; set; }
        public int nationslParkId { get; set; }
        public NationalParkModel NationalPark { get; set; }
    }
}
