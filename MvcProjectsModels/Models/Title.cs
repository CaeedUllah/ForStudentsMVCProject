using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.MvcProjectsModels.Models
{
    public class Title
    {
        
        public int Id { get; set; }
       
        [Required]
        [MaxLength(20)]
        [DisplayName("Title Name")]
        public string Name { get; set; }
    }
}
