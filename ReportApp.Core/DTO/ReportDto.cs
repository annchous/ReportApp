using System;
using AutoMapper;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.DTO
{
    public class ReportDto
    {
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public DateTime? CreationDate { get; set; }
        public EmployeeDto Employee { get; set; }
    }

    public static class ReportMapper
    {
        private static Mapper _instance;
        public static Mapper GetInstance() => _instance ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<ReportEntity, ReportDto>()));
    }
}