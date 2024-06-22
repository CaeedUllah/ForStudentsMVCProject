using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectsModels.MvcProjectsModels.Views
{
    public class VStudent
    {
        [Key]
        public int TitleId { get; set; } // Assuming 'TitleId' as the key

        // Columns from Students table
        public string Title { get; set; }
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Columns from Titles table
        public string TitleName { get; set; }
    }
}
