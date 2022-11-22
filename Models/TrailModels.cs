using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkyApplication.Models
{
    public class TrailModels
    {
        [Key]
        public int trailId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Distance { get; set; }
        public enum DifficultyType
        {
            Easy, Moderate, Difficult, Expert
        }
        public DifficultyType difficulty { get; set; }
        public int nationslParkId { get; set; }
        [ForeignKey("nationslParkId")]
        public NationalParkModel NationalPark { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
