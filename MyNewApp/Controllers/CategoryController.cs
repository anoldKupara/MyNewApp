using Microsoft.AspNetCore.Mvc;

namespace MyNewApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
