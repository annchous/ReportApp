using System;
using System.Collections.Generic;

namespace ReportApp.DAL.Entities
{
    public class TaskEntity
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public EmployeeEntity Employee { get; set; }
        public IEnumerable<TaskChangeEntity> Changes { get; set; }
    }
}