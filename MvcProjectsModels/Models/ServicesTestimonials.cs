using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectsModels.Models
{
    public class ServicesTestimonials
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestimonialId { get; set; }
        [Required]
        public String? ImgSource { get; set; }
        public String? Name { get; set; }
        public String? TestimonialDesignation { get; set; }
        public String? TestimonialDescription { get; set; }
    }
}
