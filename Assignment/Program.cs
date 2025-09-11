using Assignment.Contexts;
using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting CRUD operations ...");
            using var context = new ITIDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // 1. Topics
            Console.WriteLine("--- Managing Topics ---");
            var topic1 = new Topic { Name = "Programming" };
            var topic2 = new Topic { Name = "Database Management" };
            context.Topics.Add(topic1);
            context.Topics.Add(topic2);
            context.SaveChanges();
            Console.WriteLine("Added 2 Topics separately.");

            var topicToUpdate = context.Topics.First(t => t.Name == "Database Management");
            topicToUpdate.Name = "Databases";
            context.SaveChanges();
            Console.WriteLine("Updated 1 Topic.");

            var topicToDelete = context.Topics.First(t => t.Name == "Databases");
            context.Topics.Remove(topicToDelete);
            context.SaveChanges();
            Console.WriteLine("Deleted 1 Topic.");

            var remainingTopic = context.Topics.First();
            Console.WriteLine($"Retrieve: The remaining topic is '{remainingTopic.Name}'.\n");

            // 2. Departments
            Console.WriteLine("--- Managing Departments ---");
            var dept1 = new Department { Name = "Information Technology", HiringDate = new DateOnly(2010, 9, 1) };
            var dept2 = new Department { Name = "Computer Science", HiringDate = new DateOnly(2012, 8, 15) };
            context.Departments.Add(dept1);
            context.Departments.Add(dept2);
            context.SaveChanges();
            Console.WriteLine("Added 2 Departments separately.");

            var deptToUpdate = context.Departments.First(d => d.Name == "Computer Science");
            deptToUpdate.Name = "CS Department";
            context.SaveChanges();
            Console.WriteLine("Updated 1 Department.");

            var deptToDelete = context.Departments.First(d => d.Name == "CS Department");
            context.Departments.Remove(deptToDelete);
            context.SaveChanges();
            Console.WriteLine("Deleted 1 Department.");

            var remainingDept = context.Departments.First();
            Console.WriteLine($"Retrieve: The remaining department is '{remainingDept.Name}'.\n");

            // 3. Instructors
            Console.WriteLine("--- Managing Instructors ---");
            var inst1 = new Instructor { Name = "Ahmed Ali", Salary = 12000, Address = "123 Nasr St, Cairo", HourRate = 200, Dept_ID = dept1.Id };
            var inst2 = new Instructor { Name = "Fatima Zahra", Salary = 15000, Address = "456 Heliopolis St, Cairo", HourRate = 250, Dept_ID = dept1.Id };
            context.Instructors.Add(inst1);
            context.Instructors.Add(inst2);
            context.SaveChanges();
            Console.WriteLine("Added 2 Instructors separately.");

            var instToUpdate = context.Instructors.First(i => i.Name == "Fatima Zahra");
            instToUpdate.Salary = 16500;
            context.SaveChanges();
            Console.WriteLine("Updated 1 Instructor's salary.");

            dept1.Manager = inst1;
            context.SaveChanges();
            Console.WriteLine("Assigned a manager to a Department.");

            var instToDelete = context.Instructors.First(i => i.Name == "Fatima Zahra");
            context.Instructors.Remove(instToDelete);
            context.SaveChanges();
            Console.WriteLine("Deleted 1 Instructor.");

            var remainingInstructor = context.Instructors.First();
            Console.WriteLine($"Retrieve: The remaining instructor is '{remainingInstructor.Name}'.\n");

            // 4. Courses
            Console.WriteLine("--- Managing Courses ---");
            var course1 = new Course { Name = "C# Fundamentals", Duration = TimeSpan.FromHours(12), Description = "Basics of C# programming.", Top_ID = topic1.ID };
            var course2 = new Course { Name = "Advanced SQL", Duration = TimeSpan.FromHours(14), Description = "Deep dive into SQL queries.", Top_ID = topic1.ID };
            context.Courses.Add(course1);
            context.Courses.Add(course2);
            context.SaveChanges();
            Console.WriteLine("Added 2 Courses separately.");

            var courseToUpdate = context.Courses.First(c => c.Name == "Advanced SQL");
            courseToUpdate.Duration = TimeSpan.FromHours(12);
            context.SaveChanges();
            Console.WriteLine("Updated 1 Course.");

            var courseToDelete = context.Courses.First(c => c.Name == "Advanced SQL");
            context.Courses.Remove(courseToDelete);
            context.SaveChanges();
            Console.WriteLine("Deleted 1 Course.");

            var remainingCourse = context.Courses.Include(c => c.Topic).First();
            Console.WriteLine($"Retrieve: The remaining course is '{remainingCourse.Name}' under the topic '{remainingCourse.Topic.Name}'.\n");

            // 5. Students
            Console.WriteLine("--- Managing Students ---");
            var student1 = new Student { FName = "Mona", LName = "Salah", Address = "789 Maadi Ave, Cairo", Age = 21, Dept_Id = dept1.Id };
            var student2 = new Student { FName = "Karim", LName = "Mahmoud", Address = "321 Zamalek Rd, Cairo", Age = 22, Dept_Id = dept1.Id };
            context.Students.Add(student1);
            context.Students.Add(student2);
            context.SaveChanges();
            Console.WriteLine("Added 2 Students separately.");

            var studentToUpdate = context.Students.First(s => s.FName == "Karim");
            studentToUpdate.Address = "555 Tagamoa St, New Cairo";
            context.SaveChanges();
            Console.WriteLine("Updated 1 Student.");

            var studentToDelete = context.Students.First(s => s.FName == "Karim");
            context.Students.Remove(studentToDelete);
            context.SaveChanges();
            Console.WriteLine("Deleted 1 Student.");

            var remainingStudent = context.Students.First();
            Console.WriteLine($"Retrieve: The remaining student is '{remainingStudent.FName} {remainingStudent.LName}'.\n");

            // 6. Course-Instructor Links
            Console.WriteLine("--- Managing Course-Instructor Links ---");
            var link1 = new CourseInstructor { Ins_ID = inst1.Id, Course_ID = course1.Id, Evaluation = "Excellent" };
            context.CourseInstructors.Add(link1);
            context.SaveChanges();
            Console.WriteLine("Added 1 Course-Instructor link");

            var linkToUpdate = context.CourseInstructors.First(ci => ci.Evaluation == "Excellent");
            linkToUpdate.Evaluation = "Very Good";
            context.SaveChanges();
            Console.WriteLine("Updated 1 link.");

            var linkToDelete = context.CourseInstructors.First(ci => ci.Evaluation == "Very Good");
            context.CourseInstructors.Remove(linkToDelete);
            context.SaveChanges();
            Console.WriteLine("Deleted 1 link.");

            // 7. Student-Course 
            Console.WriteLine("--- Managing Student Enrollments ---");
            var enrollment1 = new StudentCourse { Stud_ID = student1.ID, Course_ID = course1.Id, Grade = 85 };
            var tempCourse = new Course { Name = "Temp Course for Enrollment", Top_ID = topic1.ID, Duration = TimeSpan.FromHours(12) };
            context.Courses.Add(tempCourse);
            context.SaveChanges();
            var enrollment2 = new StudentCourse { Stud_ID = student1.ID, Course_ID = tempCourse.Id, Grade = 92 };
            context.StudentCourses.Add(enrollment1);
            context.StudentCourses.Add(enrollment2);
            context.SaveChanges();
            Console.WriteLine("Added 2 student enrollments separately.");

            var enrollmentToUpdate = context.StudentCourses.First(sc => sc.Grade == 92);
            enrollmentToUpdate.Grade = 95;
            context.SaveChanges();
            Console.WriteLine("Updated 1 enrollment.");

            var enrollmentToDelete = context.StudentCourses.First(sc => sc.Grade == 95);
            context.StudentCourses.Remove(enrollmentToDelete);
            context.SaveChanges();
            Console.WriteLine("Deleted 1 enrollment.");

            var remainingEnrollment = context.StudentCourses.Include(sc => sc.Student).Include(sc => sc.Course).First();
            Console.WriteLine($"Retrieve: Student '{remainingEnrollment.Student.FName}' has a grade of {remainingEnrollment.Grade} in '{remainingEnrollment.Course.Name}'.\n");

            Console.WriteLine(" CRUD operations completed successfully!");
        }
    }
}
