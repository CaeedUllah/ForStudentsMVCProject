using Microsoft.AspNetCore.Mvc;
using MvcProjectsModels.Models;
using MvcProjectsModels.ViewModels;
using MyMvcProject.MvcProjectsModels.Models;
using MyMvcProject.Repositories;

namespace MyMvcProject.Controllers
{
    public class ServicessController : Controller
    {
        private readonly IRepository<UpConstServices> ServicesRepository;
        private readonly IRepository<ServicesTestimonials> TestimonialsServicesRepository;
        public ServicessController(IRepository<UpConstServices> servicesRepository, IRepository<ServicesTestimonials> testimonialsServicesRepository)
        {
            ServicesRepository = servicesRepository;
            TestimonialsServicesRepository = testimonialsServicesRepository;
        }
        public IActionResult Index()
        {
            /*List<UpConstServices> ServicesList = (List<UpConstServices>)ServicesRepository.GetAll();
            return View(ServicesList);*/
            ServicesViewModel servicesViewModel = new ServicesViewModel();
            servicesViewModel.upConstServices = (List<UpConstServices>)ServicesRepository.GetAll();
            servicesViewModel.servicesTestimonials = (List<ServicesTestimonials>)TestimonialsServicesRepository.GetAll();
            return View(servicesViewModel);

        }
        public IActionResult serviceDetails()
        {
            return View();
        }
    }
}
