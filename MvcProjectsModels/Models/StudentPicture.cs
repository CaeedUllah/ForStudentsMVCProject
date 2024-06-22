using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.MvcProjectsModels.Models
{
    public class StudentPicture
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string PicturePath { get; set; }
        public virtual Student Student { get; set; }
    }

}
