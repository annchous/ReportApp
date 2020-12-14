using System;

namespace ReportApp.Core.DTO
{
    public class ReportDto
    {
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public DateTime? CreationDate { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}