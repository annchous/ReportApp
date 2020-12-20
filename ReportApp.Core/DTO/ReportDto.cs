using System;
using AutoMapper;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Tools;

namespace ReportApp.Core.DTO
{
    public class ReportDto
    {
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public ReportType Type { get; set; }
        public Int32 TaskId { get; set; }
        public Int32 EmployeeId { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public DateTime? LastChangeDate { get; set; } = DateTime.Now;
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