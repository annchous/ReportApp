using System;
using System.Collections.Generic;

namespace ReportApp.DAL.Entities
{
    public class EmployeeEntity
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public EmployeeEntity Leader { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}