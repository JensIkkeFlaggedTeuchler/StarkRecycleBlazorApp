using System.ComponentModel.DataAnnotations;

namespace StarkRecycleBlazorApp.Model
{
    public class Paint
    {
        [Key]
        public int PaintId { get; set; }
        
        [MaxLength(50)]
        public string PaintName { get; set; }

        public string Color { get; set; }

        // Mål i liter
        [Range(0.5, 10)]
        public double Weight { get; set; }

        public string Condition { get; set; }
        [Range(1,20)]
        public int Amount { get; set; }

    }
}
