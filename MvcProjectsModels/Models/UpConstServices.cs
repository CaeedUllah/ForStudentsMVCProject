using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyMvcProject.MvcProjectsModels.Models
{
    public class UpConstServices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicesId { get; set; }
        [Required]
        public String? Icon { get; set; }
        public String? Title { get; set; }
        public String? Description { get; set; }
        public String? learnmore { get; set; }
    }
}
