namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using static TeisterMask.Data.XmlHelper;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var projectsDto = XmlConverter.Deserializer<ImportProjectDto>(xmlString, "Projects");

            var projects = new List<Project>();

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var opendateProject = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                DateTime dueDateProject;
                var validDueDate = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateProject) ? (DateTime?)dueDateProject : null;

                var p = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = opendateProject,
                    DueDate = validDueDate
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var openDateTask = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    var dueDateTask = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    if (openDateTask < opendateProject || (dueDateProject != DateTime.MinValue && dueDateTask > dueDateProject))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var execType = (ExecutionType)taskDto.ExecutionType;

                    var labelType = (LabelType)taskDto.LabelType;

                    p.Tasks.Add(new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = execType,
                        LabelType = labelType,
                    });
                }

                projects.Add(p);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, p.Name, p.Tasks.Count));
            }

            context.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employee = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var e = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskDto in employeeDto.Tasks)
                {
                    var existTask = context.Tasks.FirstOrDefault(t => t.Id == taskDto);

                    if (existTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    e.EmployeesTasks.Add(new EmployeeTask
                    {
                        TaskId = taskDto,
                        Employee = e
                    });
                }

                employee.Add(e);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, e.Username, e.EmployeesTasks.Count));
            }

            context.AddRange(employee);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}