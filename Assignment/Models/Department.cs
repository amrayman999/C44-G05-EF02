using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Department
    {   // by convention
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly HiringDate { get; set; }

        [ForeignKey("Manager")]
        [Column(name:"Ins_Id")]
        public int? InstructorId { get; set; }

        public  ICollection<Student> Students { get; set; }
        public Instructor Manager { get; set; }

        public ICollection<Instructor> Instructors { get; set; }

    }
}
