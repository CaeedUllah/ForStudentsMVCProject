using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcProject.MvcProjectsModels.Models
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        public String? EmpName { get; set; }
        [Required]
        public String? EmpAddress { get; set; }
        public String? EmpDesignation { get; set; }
        public String? EmpContact { get; set; }
    }
}
