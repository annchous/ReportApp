using System;
using System.Collections.Generic;
using AutoMapper;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.DTO
{
    public class TaskDto
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public EmployeeDto Employee { get; set; }
        public IEnumerable<TaskChangeDto> Changes { get; set; }
    }

    public static class TaskMapper
    {
        private static Mapper _instance;
        public static Mapper GetInstance() => _instance ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<TaskEntity, TaskDto>()));
    }
}