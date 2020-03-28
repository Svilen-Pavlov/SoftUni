namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using System.Text;
    using System.IO;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Linq;
    using TeisterMask.Data.Models.Enums;
    using System.Globalization;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {

            StringBuilder result = new StringBuilder();

            var xmlSer = new XmlSerializer(typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));
            var dtos = (ImportProjectDto[])xmlSer.Deserialize(new StringReader(xmlString));

            List<Project> projects = new List<Project>();
            List<Task> tasks = new List<Task>();
            int tasksCount = 0;
            foreach (var dto in dtos)
            {
                List<Task> currentTasks = new List<Task>();

                if (IsValid(dto) == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                var projName = dto.Name;
                var pOpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime? pDueDate = string.IsNullOrEmpty(dto.DueDate) ? new DateTime?() : DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                foreach (var taskDto in dto.Tasks)
                {
                    if (IsValid(taskDto) == false)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var executionType = (ExecutionType)Enum.ToObject(typeof(ExecutionType), taskDto.ExecutionType);
                    var labelType = (LabelType)Enum.ToObject(typeof(LabelType), taskDto.LabelType);
                    var openDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var dueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (openDate < pOpenDate || dueDate > pDueDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = tasks.FirstOrDefault(t => t.Name == taskDto.Name);

                    if (task == null)
                    {
                        task = new Task
                        {
                            Name = taskDto.Name,
                            OpenDate = openDate,
                            DueDate = dueDate,
                            ExecutionType = executionType,
                            LabelType = labelType
                        };
                        tasks.Add(task);
                    }
                    currentTasks.Add(task);
                    tasksCount++;
                }


                //ReleaseDate = dto.ReleaseDate == null ? new DateTime?() : DateTime.ParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),

                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = pOpenDate,
                    DueDate = pDueDate,
                    Tasks = currentTasks
                };

                projects.Add(project);
                result.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
            return result.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            var result = new StringBuilder();

            var employees = new List<Employee>();
            var allTasks = new List<Task>();
            foreach (var dto in dtos)
            {
                if (IsValid(dto) == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currTasks = new List<Task>();

                foreach (var taskId in dto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);
                    if (task == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    currTasks.Add(task);
                    allTasks.Add(task);
                }

                var employee = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    EmployeesTasks = currTasks.Select(currTask => new EmployeeTask
                    {
                        Task = currTask
                    }).ToList()
                };
                employees.Add(employee);
                result.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();




            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }



    }
}