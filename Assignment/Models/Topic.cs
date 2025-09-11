using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Topic
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }

        // Topic one - many Course
        public ICollection<Course> Courses { get; set; }

    }
}
