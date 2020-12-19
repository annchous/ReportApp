using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ReportApp.Core.DTO;
using ReportApp.DAL.Entities;

namespace ReportApp.Core.Mappers
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<TaskEntity, TaskDto>();
            CreateMap<TaskDto, TaskEntity>();
        }
    }
}
