using AutoMapper;
using ReportApp.Core.DTO;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDto>();
            CreateMap<EmployeeDto, EmployeeEntity>();
        }
    }
}