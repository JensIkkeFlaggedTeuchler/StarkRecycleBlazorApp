using Microsoft.AspNetCore.Mvc;

namespace StarkRecycleAPI.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
