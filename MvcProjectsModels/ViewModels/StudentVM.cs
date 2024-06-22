using MyMvcProject.MvcProjectsModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectsModels.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public List<Student> students { get; set; }
       public List<Title> titles { get; set; }
    }
}
