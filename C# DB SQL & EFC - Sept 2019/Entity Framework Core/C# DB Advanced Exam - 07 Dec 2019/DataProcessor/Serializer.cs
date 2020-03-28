namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using static TeisterMask.DataProcessor.ExportDto.ExportProjectDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        //ExportMostBusiestEmployees
        //ExportProjectWithTheirTasks
        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var query = context.Employees
                .Where(e => e.EmployeesTasks
                    .Any(et => et.Task.OpenDate >= date))
                .Select(e => new ExportEmployeeDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(t => t.Task.OpenDate >= date)
                        .OrderByDescending(t => t.Task.DueDate)
                        .ThenBy(t => t.Task.Name)
                        .Select(et => new ExportEmployeeDto.ExportTaskDto
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        }).ToArray()
                })
                .OrderByDescending(e=>e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();


            string json = JsonConvert.SerializeObject(query, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return json;
        }

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var query = context.Projects
                .Where(p => p.Tasks.Count > 0)
                .Select(p => new ExportProjectDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ExportTaskDto2
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();



            var xmlSer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            xmlSer.Serialize(new StringWriter(sb), query, namespaces);

            int count = sb.ToString().Length;

            return sb.ToString().TrimEnd();
        }
    }
}