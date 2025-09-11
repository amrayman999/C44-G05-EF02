using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    [Table("Course_Inst")]
    [PrimaryKey(nameof(Ins_ID), nameof(Course_ID))]

    public class CourseInstructor
    {
        [ForeignKey("Instructor")]
        public int Ins_ID { get; set; }

        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        public string? Evaluation { get; set; }

        // Instructor Many - Many Course
        public virtual Instructor Instructor { get; set; }
        // Course Many - Many Instructor
        public virtual Course Course { get; set; }
    }
}
