using System.ComponentModel.DataAnnotations.Schema;

namespace TASK03.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        // Navigation Prop
        public virtual Department? Department { get; set; }
    }
}
