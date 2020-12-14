using System;
using System.Collections.Generic;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.DTO
{
    public class EmployeeDto
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public EmployeeDto Leader { get; set; }
        public IEnumerable<TaskDto> Tasks { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}