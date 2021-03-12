using Microsoft.AspNetCore.Mvc;

namespace PayTransact.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
