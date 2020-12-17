using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ITaskRepository _repository;

        public TaskService(ReportAppContext context)
        {
            _repository = new TaskRepository(context);
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            var taskEntities = await _repository.GetAllAsync();
            return taskEntities
                .Select(taskEntity => TaskMapper.GetToDtoMapper().Map<TaskDto>(taskEntity))
                .ToList();
        }

        public async Task<TaskDto> GetTaskAsync(Int32 id)
        {
            var task = await _repository.GetByIdAsync(id);
            return TaskMapper.GetToDtoMapper().Map<TaskDto>(task);
        }

        public async Task CreateTaskAsync(TaskDto task)
        {
            var taskEntity = TaskMapper.GetFromDtoMapper().Map<TaskEntity>(task);
            await _repository.InsertAsync(taskEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateTaskAsync(TaskDto task)
        {
            var taskEntity = TaskMapper.GetFromDtoMapper().Map<TaskEntity>(task);
            await _repository.UpdateAsync(taskEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteTaskAsync(Int32 id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }
    }
}