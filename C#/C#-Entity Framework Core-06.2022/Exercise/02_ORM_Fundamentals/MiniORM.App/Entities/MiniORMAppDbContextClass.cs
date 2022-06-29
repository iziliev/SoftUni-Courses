using System;
using System.Collections.Generic;
using System.Text;

namespace MiniORM.App.Entities
{
    public class MiniORMAppDbContextClass : DbContext
    {
        public MiniORMAppDbContextClass(string connectionString) 
            : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; }

        public DbSet<EmployeeProject> EmployeesProjects { get; }

        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }
    }
}
