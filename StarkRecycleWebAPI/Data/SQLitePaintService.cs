using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StarkRecycleBlazorApp.Data;
using StarkRecycleBlazorApp.Model;

namespace StarkRecycleWebAPI.Data
{
    public class SQLitePaintService: IPaintService
    {
        private PaintContext ctx;

        public SQLitePaintService(PaintContext ctx)
        {
            this.ctx = ctx;

            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            ctx.Database.EnsureCreated();

            if (ctx.paints.Any())
            {
                // Database already seeded
                return;
            }

        }

        public async Task<IList<Paint>> GetPaintsAsync()
        {
            return await ctx.paints.ToListAsync();
        }

        public async Task AddPaintAsync(Paint paint)
        {
            EntityEntry<Paint> newlyAdded = await ctx.paints.AddAsync(paint);
            await ctx.SaveChangesAsync();
            // return newlyAdded.Entity;
        }

        public async Task RemovePaintAsync(int Id)
        {
            Paint toDelete = await ctx.paints.FirstOrDefaultAsync(t => t.PaintId == Id);
            if (toDelete != null)
            {
                ctx.paints.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task EditPaintAsync(Paint paint)
        {
            try
            {
                Paint toUpdate = await ctx.paints.FirstAsync(t => t.PaintId == paint.PaintId);
                ctx.Update(toUpdate);
                await ctx.SaveChangesAsync();
                // return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find todo with id{paint.PaintId}");
            }
        }
        public Task<Paint> getAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

