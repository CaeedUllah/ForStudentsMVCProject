using Microsoft.AspNetCore.Mvc;

namespace MyMvcProject.Controllers
{
    public class ContactssController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
