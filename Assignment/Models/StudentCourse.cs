using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    [Table("Stud_Course")]
    [PrimaryKey(nameof(Stud_ID), nameof(Course_ID))]
    public class StudentCourse
    {
        // Foreign Key for Student
        [ForeignKey("Student")]
        public int Stud_ID { get; set; }
        // Foreign Key for Course
        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        // Student Many - Many Course
        public Student Student { get; set; }
        // Course Many - Many Student
        public Course Course { get; set; }
        public int  Grade { get; set; }

    }
}
