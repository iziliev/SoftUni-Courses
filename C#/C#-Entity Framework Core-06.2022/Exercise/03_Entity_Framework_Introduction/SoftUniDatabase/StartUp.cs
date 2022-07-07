using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            //Problem_03_Employees_Full_Information
            //Console.WriteLine(GetEmployeesFullInformation(context));

            //Problem_04_Employees_with_Salary_Over_50000
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //Problem_05_Employees_from_Research_and_Development
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //Problem_06_Adding_a_New_Address_and_Updating_Employee
            //Console.WriteLine(AddNewAddressToEmployee(context));

            //Problem_07_Employees_and_Projects
            //Console.WriteLine(GetEmployeesInPeriod(context));

            //Problem_08_Addresses_by_Town
            //Console.WriteLine(GetAddressesByTown(context));

            //Problem_09_Employee_147
            //Console.WriteLine(GetEmployee147(context));

            //Problem_10_Departments_with_More_Than_5_Employees
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            //Problem_11_Find_Latest_10_Projects
            //Console.WriteLine(GetLatestProjects(context));

            //Problem_12_Increase_Salaries
            //Console.WriteLine(IncreaseSalaries(context));

            //Problem_13_Find_Employees_by_First_Name_Starting_with_Sa
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            //Problem_14_Delete_Project_by_Id
            //Console.WriteLine(DeleteProjectById(context));

            //Problem_15_Remove_Town
            //Console.WriteLine(RemoveTown(context));
        }

        //Problem_03_Employees_Full_Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName= e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {(decimal)employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem_04_Employees_with_Salary_Over_50000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesOver50000 = context.Employees
                .Where(s => s.Salary > 50000)
                .OrderBy(n => n.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var employee in employeesOver50000)
            {
                sb.AppendLine($"{employee.FirstName} - {(decimal)employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem_05_Employees_from_Research_and_Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesFromDepartment = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var employee in employeesFromDepartment)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${(decimal)employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem_06_Adding_a_New_Address_and_Updating_Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            var nakovEmployee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(a => new
                {
                    a.Address.AddressText
                })
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}");
            }

            return sb.ToString().Trim();
        }

        //Problem_07_Employees_and_Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStart = p.Project.StartDate,
                        ProjectEnd = p.Project.EndDate
                    })
                }).Take(10);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var currentStart = project.ProjectStart.ToString("M/d/yyyy h:mm:ss tt");
                    var currentEnd = project.ProjectEnd.HasValue ? project.ProjectEnd.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";
                    sb.AppendLine($"--{project.ProjectName} - {currentStart} - {currentEnd}");
                }
            }

            return sb.ToString().Trim();
        }

        //Problem_08_Addresses_by_Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .Take(10)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    Employees = a.Employees.Count
                }).ToArray();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Employees} employees");
            }
            
            return sb.ToString().Trim();
        }

        //Problem_09_Employee_147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147Info = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FullName = string.Concat(e.FirstName, " ", e.LastName),
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep=>ep.Project.Name)
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var employee in employee147Info)
            {
                sb.AppendLine($"{employee.FullName} - {employee.JobTitle}");

                foreach (var project in employee.Projects.OrderBy(x=>x))
                {
                    sb.AppendLine($"{project}");
                }
            }

            return sb.ToString().Trim();
        }

        //Problem_10_Departments_with_More_Than_5_Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFullName = string.Concat(d.Manager.FirstName, " ", d.Manager.LastName),
                    Employee = d.Employees.Select(x => new
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        JobTitle = x.JobTitle
                    }).ToArray()
                }).ToArray();

            var sb = new StringBuilder();

            foreach (var department in departments.OrderBy(x=>x.Employee.Count()))
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");

                foreach (var employee in department.Employee.OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        //Problem_11_Find_Latest_10_Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p=>p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    StartDate = p.StartDate,
                    Description = p.Description
                })
                .OrderBy(p => p.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture);
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{startDate}");
            }

            return sb.ToString().Trim();
        }

        //Problem_12_Increase_Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employessInRangeOfDepartment = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .OrderBy(x=>x.FirstName)
                .ThenBy(x=>x.LastName);

            foreach (var employee in employessInRangeOfDepartment)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var employee in employessInRangeOfDepartment)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${(decimal)employee.Salary:F2})");
            }

            return sb.ToString().Trim();
        }

        //Problem_13_Find_Employees_by_First_Name_Starting_with_Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    FullName = string.Concat(e.FirstName," ",e.LastName),
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                }).ToArray();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - {employee.JobTitle} - (${(decimal)employee.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        //Problem_14_Delete_Project_by_Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);

            var employeeProjects = context.EmployeesProjects
                .Where(ep=>ep.ProjectId ==project.ProjectId)
                .ToArray();

            context.EmployeesProjects.RemoveRange(employeeProjects);

            context.Projects.Remove(project);

            context.SaveChanges();

            var returnedProjects = context.Projects
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var returnedProject in returnedProjects)
            {
                sb.AppendLine(returnedProject.Name);
            }

            return sb.ToString().Trim();
        }

        //Problem_15_Remove_Town
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context.Towns
                .First(t => t.Name == "Seattle");

            var addressesToDelete = context.Addresses
                .Where(a => a.TownId == townToDelete.TownId);

            int addressesCount = addressesToDelete.Count();

            var employeesToDelete = context.Employees
                .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employeesToDelete)
            {
                employee.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }            

            context.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
