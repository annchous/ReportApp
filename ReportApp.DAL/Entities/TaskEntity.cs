﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ReportApp.DAL.Tools;

namespace ReportApp.DAL.Entities
{
    public class TaskEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public TaskState State { get; set; }
        public Int32 EmployeeId { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}