using MvcProjectsModels.Models;
using MyMvcProject.MvcProjectsModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectsModels.ViewModels
{
    public class ServicesViewModel
    {
        public int Id { get; set; }
        public List<UpConstServices> upConstServices { get; set; }
        public List<ServicesTestimonials> servicesTestimonials { get; set; }
    }
}
