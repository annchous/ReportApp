using System;
using AutoMapper;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.DTO
{
    public class ReportDto
    {
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public Int32 EmployeeId { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        //public EmployeeDto Employee { get; set; } = new EmployeeDto();
    }

    public static class ReportMapper
    {
        private static Mapper _toDtoMapper;
        private static Mapper _fromDtoMapper;
        public static Mapper GetToDtoMapper() => _toDtoMapper ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<ReportEntity, ReportDto>()));

        public static Mapper GetFromDtoMapper() => _fromDtoMapper ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<ReportDto, ReportEntity>()));
    }
}