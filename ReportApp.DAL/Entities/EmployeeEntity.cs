using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities
{
    public class EmployeeEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String Name { get; set; }

        public Int32? LeaderId { get; set; }
        //public EmployeeEntity Leader { get; set; }
        //public ICollection<TaskEntity> Tasks { get; set; }
        //public ICollection<EmployeeEntity> Employees { get; set; }
    }
}