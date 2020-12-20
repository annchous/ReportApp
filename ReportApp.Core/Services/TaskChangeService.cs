using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Repositories;

namespace ReportApp.Core.Services
{
    public class TaskChangeService : ITaskChangeService
    {
        private readonly IMapper _mapper;
        private readonly ITaskChangeRepository _taskChangeRepository;

        public TaskChangeService(ReportAppContext context, IMapper mapper)
        {
            _taskChangeRepository = new TaskChangeRepository(context);
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskChangeDto>> GetAllAsync()
        {
            var taskChangeEntities = await _taskChangeRepository.GetAllAsync();
            return taskChangeEntities
                .Select(taskChangeEntity => _mapper.Map<TaskChangeDto>(taskChangeEntity))
                .ToList(); ;
        }

        public async Task<IEnumerable<TaskChangeDto>> GetAllForTaskByIdAsync(Int32 taskId)
        {
            var taskChangeEntities = await _taskChangeRepository.GetAllAsync();
            return taskChangeEntities
                .Where(t => t.TaskId == taskId)
                .Select(taskChangeEntity => _mapper.Map<TaskChangeDto>(taskChangeEntity))
                .ToList(); ;
        }

        public async Task CreateTaskChangeAsync(TaskChangeDto taskChange)
        {
            var taskChangeEntity = _mapper.Map<TaskChangeEntity>(taskChange);
            await _taskChangeRepository.InsertAsync(taskChangeEntity);
            await _taskChangeRepository.SaveAsync();
        }
    }
}