using System;

namespace ReportApp.DAL.Entities
{
    public class ReportEntity
    {
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}