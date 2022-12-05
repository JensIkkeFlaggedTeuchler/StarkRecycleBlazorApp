using Microsoft.AspNetCore.Mvc;
using StarkRecycleBlazorApp.Data;
using StarkRecycleBlazorApp.Model;


namespace StarkRecycleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaintController : ControllerBase
    {
        private readonly ILogger<PaintController> _logger;
        private IPaintService paintService;
        public PaintController(ILogger<PaintController> logger,
                              IPaintService service)
        {
            _logger = logger;
            paintService = service;
        }

        [HttpGet(Name = "GetPaints")]
        public async Task<IList<Paint>> GetPaintsAsync()
        {
            IList<Paint> paints = await paintService.GetPaintsAsync();
            return paints;
        }

        [HttpPost]
        public async void AddPaint([FromBody] Paint paint)
        {
            try
            {
                await paintService.AddPaintAsync(paint);

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
                await paintService.RemovePaintAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        [HttpPatch]
        [Route("{id:int}")]
        public async void EditPaint([FromBody] Paint paint)
        {
            try
            {
                await paintService.EditPaintAsync(paint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
