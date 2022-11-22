using static ParkyApplication.Models.TrailModels;
using System.ComponentModel.DataAnnotations;

namespace ParkyApplication.Models.Dtos
{
    public class UpdatetrailDto
    {
        public int trailId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Distance { get; set; }
        public DifficultyType difficulty { get; set; }
        public int nationslParkId { get; set; }
    }
}
