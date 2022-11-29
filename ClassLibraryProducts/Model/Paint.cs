using System.ComponentModel.DataAnnotations;

namespace StarkRecycleBlazorApp.Model
{
    public class Paint
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
        
       
        public string Color { get; set; }

        // Mål i liter
        [Range(0.5, 10)]
        public double Weigth { get; set; }

        public string Condition { get; set; }

        public List<Paint> Paints { get; set; }
    }
}
