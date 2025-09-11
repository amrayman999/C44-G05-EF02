using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    
    public class Student
    {
        // Data Annotation
        [Key]
        public int ID { get; set; }
        [Column(TypeName ="varchar")]
        [MaxLength(20)]
        public string? FName { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string? LName { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string? Address { get; set; }
        public int Age { get; set; }

        // Student Many - One Department
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public Department Department { get; set; }

        // Student Many - Many Course   
        public ICollection<StudentCourse> StudCourses { get; set; }
    }
}
