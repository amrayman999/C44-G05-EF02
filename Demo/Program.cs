using Demo.Contexts;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // using key word release the resource automatically after use
            //using CompanyDbContext context = new CompanyDbContext();

            // ef by default track the entities that you get from the database


            #region Add
            //Employee employee = new Employee
            //{
            //    Name = "Amr Ayman",
            //    Address = "Cairo",
            //    Age = 25,
            //    Email = "amr@email.com",
            //    Test = 10,

            //};

            ////context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; 


            //Console.WriteLine(context.Entry(employee).State); 

            ////context.Add(employee);
            ////context.Add<Employee>(employee);
            ////context.Employees.Add(employee);
            ////context.Set<Employee>().Add(employee);
            ////context.Entry<Employee>(employee).State = EntityState.Added;

            //Console.WriteLine(context.Entry(employee).State); //Added

            //Console.WriteLine($"Employee Id is : {employee.Id} Before Saving");
            //context.SaveChanges();

            //Console.WriteLine(context.Entry(employee).State); // UnChanged
            //Console.WriteLine($"Employee Id is : {employee.Id} After Saving");


            #endregion

            #region Retrieve
            //var employee = context.Employees.FirstOrDefault(e => e.Id == 1);
            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // => Disable Tracking

            //var employee = context.Employees.AsNoTracking().FirstOrDefault(e => e.Id == 1); // Disable Tracking for this query only


            //if (employee != null)
            //{
            //    Console.WriteLine(context.Entry(employee).State); // UnChanged
            //    Console.WriteLine($"Employee Name is : {employee.Name}");
            //}




            #endregion

            #region Update
            //var employee = context.Employees.FirstOrDefault(e => e.Id == 1);
            //if (employee != null)
            //{
            //    Console.WriteLine(context.Entry(employee).State); // Detached
            //    Console.WriteLine($"Employee Name is : {employee.Name}");
            //    employee.Name = "hassan";
            //    Console.WriteLine(context.Entry(employee).State); // Detached

            //    context.SaveChanges();
            //    Console.WriteLine(context.Entry(employee).State); //


            //}
            #endregion

            #region Delete
            //var employee = context.Employees.FirstOrDefault(e => e.Id == 1);
            //if (employee != null)
            //{
            //    Console.WriteLine(context.Entry(employee).State); // Detached

            //    context.Remove(employee);
            //    context.Remove<Employee>(employee);
            //    context.Employees.Remove(employee);
            //    context.Set<Employee>().Remove(employee);
            //    context.Entry<Employee>(employee).State = EntityState.Deleted;
            //    Console.WriteLine(context.Entry(employee).State); // Deleted

            //    context.SaveChanges();
            //    Console.WriteLine(context.Entry(employee).State); // 


            //}

            #endregion

        }
    }
}
