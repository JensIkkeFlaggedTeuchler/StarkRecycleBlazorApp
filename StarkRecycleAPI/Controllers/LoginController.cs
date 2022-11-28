using Microsoft.AspNetCore.Mvc;

namespace StarkRecycleAPI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
