using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public enum Grade
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5
    }
    // Data Annotation
    //[Table("EmployeeTable")] // Table Name
    // By Convention
    public class Employee
    {
        public int Id { get; set; } // Id. EmployeeId => Primary Key by Convention , Identity(1,1) Auto Increment

        // By Data Annotations
        [Column(TypeName = "varchar")]
        [MaxLength(10)]
        [MinLength(5)]
        [StringLength(10, MinimumLength = 5, ErrorMessage ="")]
        [Length(5,10)] 
        public string? Name { get; set; } // nvarchar(max)
        [Required]
        [DataType(DataType.Currency)]
        [DefaultValue(5000)]
        public decimal Salary { get; set; }
        [Range(18, 60)]
        [AllowedValues(24,25,26,27)]
        [DeniedValues(29,30)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [NotMapped]
        public int Test { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Grade Grade { get; set; }
        public string Address { get; set; }
    }
}
