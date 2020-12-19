using AutoMapper;
using ReportApp.Core.DTO;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.Mappers
{
    public class TaskChangeMappingProfile : Profile
    {
        public TaskChangeMappingProfile()
        {
            CreateMap<TaskChangeEntity, TaskChangeDto>();
            CreateMap<TaskChangeDto, TaskChangeEntity>();
        }
    }
}