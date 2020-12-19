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
using ReportApp.DAL.Tools;

namespace ReportApp.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TaskService(ReportAppContext context, IMapper mapper)
        {
            _taskRepository = new TaskRepository(context);
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            var taskEntities = await _taskRepository.GetAllAsync();
            return taskEntities
                .Select(taskEntity => _mapper.Map<TaskDto>(taskEntity))
                .ToList();
        }

        public async Task<TaskDto> GetTaskAsync(Int32 id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return _mapper.Map<TaskDto>(task);
        }

        public async Task CreateTaskAsync(TaskDto task)
        {
            var taskEntity = _mapper.Map<TaskEntity>(task);
            await _taskRepository.InsertAsync(taskEntity);
            await _taskRepository.SaveAsync();
        }

        public async Task UpdateTaskAsync(TaskDto task)
        {
            var taskEntity = _mapper.Map<TaskEntity>(task);
            await _taskRepository.UpdateAsync(taskEntity);
            await _taskRepository.SaveAsync();
        }

        public async Task DeleteTaskAsync(Int32 id)
        {
            await _taskRepository.DeleteAsync(id);
            await _taskRepository.SaveAsync();
        }
    }
}