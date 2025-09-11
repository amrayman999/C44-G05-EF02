using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public decimal HourRate { get; set; }
        // Foreign Key for the Department the instructor belongs to
        [ForeignKey("Department")]
        public int Dept_ID { get; set; }
        // Navigation Property: Instructor belongs to one Department
        public virtual Department Department { get; set; }

        // Navigation Property for the 1-to-1 relationship where an instructor manages a department
        public virtual Department ManagedDepartment { get; set; }

        // Instructor Many - Many Course
        public ICollection<CourseInstructor> TaughtCourses { get; set; }
    }
}
