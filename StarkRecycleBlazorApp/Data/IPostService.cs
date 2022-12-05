using ClassLibraryProducts;

namespace StarkRecycleBlazorApp.Data
{
    public interface IPostService
    {
        Task<IList<Post>> GetPostsAsync();

        Task AddPostAsync(Post post);

        Task RemovePostAsync(int Id);

        Task EditPostAsync(Post post);

        Task<Post> GetPostByIdAsync(int Id);
    }
}
