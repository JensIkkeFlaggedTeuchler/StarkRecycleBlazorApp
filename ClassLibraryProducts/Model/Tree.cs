using System.ComponentModel.DataAnnotations;

namespace ClassLibraryProducts
{
    public class Tree
    {
        [Key]
        public int TreeId { get; set; }

        [MaxLength(50)]
        public string TreeName { get; set; }

        [Range(1, 100,ErrorMessage = "Skal have et antal på mindst 1 og maks 100styk")]
        public int Amount { get; set; }
        
        // Mål i centimeter
        [Range(5, 30, ErrorMessage ="Skal have en højde på mindst 5 og maks 30cm")]
        public double Height { get; set; }

        // Mål i centimeter

        [Range(5, 30, ErrorMessage = "Skal have en Bredde på mindst 5 og maks 30cm")]
        public double Width { get; set; }

        // Mål i centimeter
        [Range(20, 500, ErrorMessage = "Skal have en Længde på mindst 20 og maks 500cm")]
        public double Length { get; set; }

        public string Condition { get; set; }
    }
}
