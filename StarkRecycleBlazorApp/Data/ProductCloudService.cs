using System.Text.Json;
using System.Text;
using ClassLibraryProducts;

namespace StarkRecycleBlazorApp.Data
{

    //Request URL https://localhost:7091/Post 
    public class ProductCloudService: IPostService
    {
        private string uri = "https://localhost:7091";
        private readonly HttpClient client;

        public ProductCloudService()
        {
            client = new HttpClient();
        }


        public async Task AddPostAsync(Post post)
        {
            string postsAsJson = JsonSerializer.Serialize(post);
            HttpContent content = new StringContent(postsAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri + "/Post", content);

            //HttpClient client = new HttpClient();
            //string todoAsJson = JsonSerializer.Serialize(todo);
            //StringContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("https://localhost:7285/Todo", content);

            //if (!response.IsSuccessStatusCode)
            //   throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            //Console.WriteLine(response.ToString());
        }


        public async Task<IList<Post>> GetPostsAsync()
        {
            // Example 1
            // Get the data from the WEB API implemented in this solution

            // HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7091/Todo");
            Task<string> stringAsync = client.GetStringAsync(uri + "/Post");
            string message = await stringAsync;
            List<Post> result = JsonSerializer.Deserialize<List<Post>>(message, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return result;



            // Example 2 
            // Get data from the public internet API at
            // https://jsonplaceholder.typicode.com/Todos
            //

            //HttpClient client = new HttpClient();
            //HttpResponseMessage responseMessage = await client.GetAsync("https://jsonplaceholder.typicode.com/Todos");

            //if (!responseMessage.IsSuccessStatusCode)
            //   throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            //string result = await responseMessage.Content.ReadAsStringAsync();
            //List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(result, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            //return todos;

        }


        public async Task RemovePostAsync(int postId)
        {
            await client.DeleteAsync($"{uri}/Post/{postId}");

            //string Url = "https://localhost:7285/Todo/";
            //Url += todoId;
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.DeleteAsync( Url );
            //if (!response.IsSuccessStatusCode)
            //   throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task EditPostAsync(Post post)
        {
            string postsAsJson = JsonSerializer.Serialize(post);
            HttpContent content = new StringContent(postsAsJson,
                Encoding.UTF8,
                "application/json");

            await client.PatchAsync($"{uri}/Post/{post.PostID}", content);

        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            HttpClient client = new HttpClient();

            // HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7285/Todo");
            Task<string> stringAsync = client.GetStringAsync(uri + "/Post");
            string message = await stringAsync;
            List<Post> result = JsonSerializer.Deserialize<List<Post>>(message, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return result.FirstOrDefault(t => t.PostID == id);
        }
    }
}

