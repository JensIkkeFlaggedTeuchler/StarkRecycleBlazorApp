using StarkRecycleBlazorApp.Model;
namespace StarkRecycleBlazorApp.Data
{
    public interface IPaintService
    { 
        Task<IList<Paint>> GetPaintsAsync();

        Task AddPaintAsync(Paint paint);

        Task RemovePaintAsync(int Id); 

        Task EditPaintAsync(Paint paint);

        Task<Paint> getAsync(int Id);


    }
}
