using StarkRecycleBlazorApp.Model;
namespace StarkRecycleBlazorApp.Data
{
    public interface ITreeService
    {
        Task<IList<Tree>> GetTreesAsync();

        Task AddTreeAsync(Tree tree);

        Task RemoveTreeAsync(int Id);

        Task EditTreeAsync(Tree tree);

        Task<Tree> GetTreeByIdAsync(int Id);
    }
}
