using Microsoft.AspNetCore.Mvc;

namespace MyMvcProject.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
            public IActionResult ProjectDetails()
        {
            return View();
        }
    }
}
