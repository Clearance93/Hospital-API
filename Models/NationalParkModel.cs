using System.ComponentModel.DataAnnotations;

namespace ParkyApplication.Models
{
    public class NationalParkModel
    {
        [Key]
        public int nationslParkId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime created { get; set; }
        public DateTime Established { get; set; }
    }
}
