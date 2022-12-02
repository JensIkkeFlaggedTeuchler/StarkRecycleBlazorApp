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
        [Range(5, 15)]
        public double Height { get; set; }

        // Mål i centimeter

        [Range(5, 30)]
        public double Width { get; set; }

        // Mål i centimeter
        [Range(20, 500)]
        public double Length { get; set; }

        public string Condition { get; set; }
        public List<Tree> Trees { get; set; }
    }
}
