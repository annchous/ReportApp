using AutoMapper;
using ReportApp.Core.DTO;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.Mappers
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<ReportEntity, ReportDto>();
            CreateMap<ReportDto, ReportEntity>();
        }
    }
}