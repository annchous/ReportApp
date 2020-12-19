using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.DTO
{
    public class TaskDto
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 EmployeeId { get; set; }
        public String Description { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? FinishDate { get; set; } = DateTime.MaxValue;
        //public EmployeeDto Employee { get; set; } = new EmployeeDto();
        //public IEnumerable<TaskChangeDto> Changes { get; set; } = new List<TaskChangeDto>();
    }

    public static class TaskMapper
    {
        private static Mapper _toDtoMapper;
        private static Mapper _fromDtoMapper;
        public static Mapper GetToDtoMapper() => _toDtoMapper ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<TaskEntity, TaskDto>()));

        public static Mapper GetFromDtoMapper() => _fromDtoMapper ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<TaskDto, TaskEntity>()));
    }
}