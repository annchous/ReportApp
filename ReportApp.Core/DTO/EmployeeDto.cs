using System;

namespace ReportApp.Core.DTO
{
    public class EmployeeDto
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public EmployeeDto Leader { get; set; }
    }
}