using ClassLibraryProducts;
using StarkRecycleBlazorApp.Data;
using System.Text.Json;

namespace StarkRecycleBlazorApp.Data
{
    public class PostService : IPostService
    {
        private string postFile = "Post.json";
        private IList<Post> postList;

        public PostService()
        {
            if (!File.Exists(postFile))
            {
                WritePostFile();
            }
            else
            {
                string content = File.ReadAllText(postFile);
                postList = JsonSerializer.Deserialize<List<Post>>(content);
            }
        }

        public async Task<IList<Post>> GetPostsAsync()
        {
            List<Post> tmp = new List<Post>(postList);
            return tmp;
        }
        public async Task AddPostAsync(Post post)
        {
            int max = postList.Max(Post => Post.PostID);
            post.PostID = (++max);
            postList.Add(post);
            WritePostFile();
        }

        public async Task EditPostAsync(Post post)
        {
            Post toUpdate = postList.First(t => t.PostID == post.PostID);
            post.Title = toUpdate.Title;
            post.Description = toUpdate.Description;
            post.AuthorFirstname = toUpdate.AuthorFirstname;
            post.AuthorLastname = toUpdate.AuthorLastname;
            WritePostFile();
        }

        public async Task<Post> GetPostByIdAsync(int Id)
        {
            return postList.FirstOrDefault(t => t.PostID == Id);
        }



        public async Task RemovePostAsync(int Id)
        {
            Post toRemove = postList.First(t => t.PostID == Id);
            postList.Remove(toRemove);
            WritePostFile();
        }

        private void WritePostFile()
        {
            string postAsJson = JsonSerializer.Serialize(postList);
            File.WriteAllText(postFile, postAsJson);
        }
    }
}
