using System.Text.Json;
using System.Text;
using StarkRecycleBlazorApp.Model;

namespace StarkRecycleBlazorApp.Data
{
    public class PaintCloudService: IPaintService
    {
        private string uri = "https://localhost:7285";
        private readonly HttpClient client;

        public PaintCloudService()
        {
            client = new HttpClient();
        }

        public async Task AddPaintAsync(Paint paint)
        {
            string paintsAsJson = JsonSerializer.Serialize(paint);
            HttpContent content = new StringContent(paintsAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri + "/paint", content);

            //HttpClient client = new HttpClient();
            //string todoAsJson = JsonSerializer.Serialize(todo);
            //StringContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("https://localhost:7285/Paint", content);

            //if (!response.IsSuccessStatusCode)
            //   throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            //Console.WriteLine(response.ToString());
        }


        public async Task<IList<Paint>> GetPaintsAsync()
        {
            // Example 1
            // Get the data from the WEB API implemented in this solution

            // HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7285/Paint");
            Task<string> stringAsync = client.GetStringAsync(uri + "/paint");
            string message = await stringAsync;
            List<Paint> result = JsonSerializer.Deserialize<List<Paint>>(message, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
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


        public async Task RemovePaintAsync(int paintId)
        {
            await client.DeleteAsync($"{uri}/paint/{paintId}");

            //string Url = "https://localhost:7285/Todo/";
            //Url += todoId;
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.DeleteAsync( Url );
            //if (!response.IsSuccessStatusCode)
            //   throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task EditPaintAsync(Paint paint)
        {
            string todoAsJson = JsonSerializer.Serialize(paint);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");

            await client.PatchAsync($"{uri}/paint/{paint.PaintId}", content);

        }

        public async Task<Paint> getAsync(int id)
        {
            HttpClient client = new HttpClient();

            // HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7285/paint");
            Task<string> stringAsync = client.GetStringAsync(uri + "/paint");
            string message = await stringAsync;
            List<Paint> result = JsonSerializer.Deserialize<List<Paint>>(message, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return result.FirstOrDefault(t => t.PaintId == id);
        }
   
    }
}

