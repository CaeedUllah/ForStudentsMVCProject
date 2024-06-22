using Microsoft.EntityFrameworkCore;
using MvcProjectsModels.Models;
using MvcProjectsModels.MvcProjectsModels.Views;
using MyMvcProject.MvcProjectsModels.Models;

namespace MyMvcProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<UpConstServices> Services { get; set; }
        public DbSet<ServicesTestimonials> Testimonials { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<a> A { get; set; }
        public DbSet<b> B { get; set; }
        public DbSet<VStudent> VStudents { get; set; } // Add this line
        /*public DbSet<StudentPicture> StudentPictures { get; set; }*/
        // to test
        // to test branch

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VStudent>()
            .ToView("V_Student") // Specify the name of the view
            .HasNoKey(); // Views generally don't have a primary key

            modelBuilder.Entity<VCombined>()
                .ToView("VCombined")
                .HasNoKey();

            modelBuilder.Entity<Employees>().HasData(
                new Employees { EmployeeId = 1, EmpName = "Ali", EmpAddress = "Madyan Swat", EmpDesignation = "Principal", EmpContact = "030133322" },
                 new Employees { EmployeeId = 2, EmpName = "Arshad", EmpAddress = "Damana Swat", EmpDesignation = "Clerk", EmpContact = "0301555555" },
                 new Employees { EmployeeId= 3, EmpName = "Akhtar", EmpAddress = "Qandil Swat", EmpDesignation = "Vice Principal", EmpContact = "0301333333" },
                 new Employees { EmployeeId = 4, EmpName = "Muhib", EmpAddress = "Darmai Swat", EmpDesignation = "Teacher", EmpContact = "03014545" }

                ) ;
        }
    }
}
