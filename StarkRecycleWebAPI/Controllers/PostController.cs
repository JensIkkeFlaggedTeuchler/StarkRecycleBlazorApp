using ClassLibraryProducts;
using Microsoft.AspNetCore.Mvc;
using StarkRecycleBlazorApp.Data;


namespace StarkRecycleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private IPostService postService;
        public PostController(ILogger<PostController> logger,
                              IPostService service)
        {
            _logger = logger;
            postService = service;
        }

        [HttpGet(Name = "GetPosts")]
        public async Task<IList<Post>> GetPostsAsync()
        {
            IList<Post> posts = await postService.GetPostsAsync();
            return posts;
        }

        [HttpPost]
        public async void AddPost([FromBody] Post post)
        {
            try
            {
                await postService.AddPostAsync(post);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async void DeleteTodo([FromRoute] int id)
        {
            try
            {
                await postService.RemovePostAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        [HttpPatch]
        [Route("{id:int}")]
        public async void EditPaint([FromBody] Post post)
        {
            try
            {
                await postService.EditPostAsync(post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
