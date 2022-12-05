using Microsoft.EntityFrameworkCore;
using ClassLibraryProducts;

namespace StarkRecycleWebAPI.Data
{
    public class PaintContext: DbContext
    {
        public PaintContext(DbContextOptions<PaintContext>opt) : base(opt)
        {

        }

        public DbSet<Paint> paints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite("Data Source = Paint.db");
        }
    }
}
