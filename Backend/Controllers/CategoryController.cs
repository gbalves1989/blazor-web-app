using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
