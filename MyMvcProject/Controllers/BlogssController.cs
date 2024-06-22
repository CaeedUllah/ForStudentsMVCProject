using Microsoft.AspNetCore.Mvc;

namespace MyMvcProject.Controllers
{
    public class BlogssController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogDetails()
        {
            return View();
        }
    }
}
