using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Tools;

namespace ReportApp.Core.DTO
{
    public class TaskDto
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public TaskState State { get; set; }
        public Int32? EmployeeId { get; set; }
        public String Description { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? FinishDate { get; set; } = DateTime.MaxValue;
    }
}