using System;

namespace ReportApp.DAL.Entities
{
    public class TaskEntity
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}