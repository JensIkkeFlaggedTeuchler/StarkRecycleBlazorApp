using System.ComponentModel.DataAnnotations;

namespace StarkRecycleBlazorApp.Model
{
    public class Tree
    {
        [Key]
        public int Id { get; set; }

        
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Amount { get; set; }
        
        // Mål i centimeter
        [Range(1, 15)]
        public double Height { get; set; }

        // Mål i centimeter

        [Range(1, 50)]
        public double Width { get; set; }

        // Mål i meter
        [Range(1, 5)]
        public int Length { get; set; }

        public string Condition { get; set; }
        public List<Tree> Trees { get; set; }
    }
}
