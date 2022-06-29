using MiniORM.App.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main()
        {
            var connectionString = @"Server=.; Database=MiniORM;User Id=sa;Password=Ilievi84;Encrypt=false;";

            var context = new MiniORMAppDbContextClass(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
