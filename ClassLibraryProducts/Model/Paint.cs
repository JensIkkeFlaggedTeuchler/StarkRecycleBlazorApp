using System.ComponentModel.DataAnnotations;

namespace ClassLibraryProducts
{
    public class Paint
    {
        [Key]
        public int PaintId { get; set; }
        
        [MaxLength(50)]
        public string PaintName { get; set; }

        public string Color { get; set; }

        // Mål i liter
        [Range(0.5, 10, ErrorMessage = "Skal have en vægt på mindst 0.5Liter og maks 10 liter")]
        public double Weight { get; set; }

        public string Condition { get; set; }
        [Range(1,100, ErrorMessage = "Skal have et antal på mindst 1 og maks 100 styk")]
        public int Amount { get; set; }

    }
}
