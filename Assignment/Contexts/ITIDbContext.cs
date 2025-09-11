using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contexts
{
    public class ITIDbContext : DbContext
    {
        public ITIDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITIDb;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // 1. One-to-Many: A Department has many Instructors
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.Dept_ID)
                .OnDelete(DeleteBehavior.Restrict); 

            // 2. One-to-One: A Department has one Manager (Instructor)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithOne(i => i.ManagedDepartment)
                .HasForeignKey<Department>(d => d.InstructorId)
                .OnDelete(DeleteBehavior.NoAction); 
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        }
}
