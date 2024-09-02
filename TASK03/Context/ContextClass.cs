using Microsoft.EntityFrameworkCore;
using TASK03.Models;

namespace TASK03.Context
{
    public class ContextClass:DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DTG4NSB;Database=TASK03;Trusted_Connection=True;Encrypt=false");
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            // Seading
            var _Departments = new List<Department>
            {
                new Department { Id = 1, DeptName = ".NET" },
                new Department { Id = 2, DeptName = "Flask" },
                new Department { Id = 3, DeptName = "Django" },
                new Department { Id = 4, DeptName = "node" }
            };

            var _Students = new List<Student>
            {
                new Student { Id = 1, Name = "stu1", Age = 22, Address = "cairoA", DepartmentId = 1 },
                new Student { Id = 2, Name = "stu2", Age = 32, Address = "CairoB",DepartmentId = 2 },
                new Student { Id = 3, Name = "stu3", Age = 42, Address = "CairoC",DepartmentId = 3 },
                new Student { Id = 4, Name = "stud4", Age = 52, Address = "CairoD",DepartmentId = 4 },
                new Student { Id = 5, Name = "stu5",Age = 2,Address = "CairoE",DepartmentId = 1 },
                new Student { Id = 6, Name = "Ahmed", Age = 38,Address = "CairoF", DepartmentId = 2 },
                new Student { Id = 7, Name = "Sara", Age = 48, Address = "CairoG",DepartmentId = 3 },
                new Student { Id = 8, Name = "Osama", Age = 26,Address = "CairoH", DepartmentId = 4 },
                new Student { Id = 9, Name = "Mohamed", Age =3,Address = "CairoI", DepartmentId = 1 },
                new Student { Id = 10, Name = "Nour", Age = 46,Address = "CairoJ", DepartmentId = 2 },
                new Student { Id = 11, Name = "Mohamed",Age =22,Address = "CairoK", DepartmentId = 3 },
                new Student { Id = 12, Name = "Nour", Age = 46,Address = "CairoL", DepartmentId = 4 }
            };

            modelBuilder.Entity<Department>().HasData(_Departments);
            modelBuilder.Entity<Student>().HasData(_Students);
           
        }
   
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
       
    }
}
