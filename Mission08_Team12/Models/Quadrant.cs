using System.ComponentModel.DataAnnotations;

namespace Mission08_Team12.Models
{
    public class Quadrant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string QuadrantName { get; set; }
    }
}
