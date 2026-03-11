using Microsoft.AspNetCore.Mvc;

namespace COREWebAPI.Controllers
{
    public class NewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
