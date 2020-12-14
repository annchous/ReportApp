using System;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Tools;

namespace ReportApp.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly UnitOfWork _dataBase;

        public TaskService(UnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }
        // TODO: add changes for the dto task
        public async Task<TaskDto> GetTaskAsync(Int32 id)
        {
            var task = await _dataBase.TaskRepository.GetByIdAsync(id);
            return new TaskDto()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate,
                FinishDate = task.FinishDate
            };
        }
        // TODO: add changes for the dto task
        public async Task CreateTaskAsync(TaskDto task)
        {
            var taskEntity = new TaskEntity()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate ?? DateTime.MinValue,
                FinishDate = task.FinishDate ?? DateTime.MinValue
            };
            await _dataBase.TaskRepository.InsertAsync(taskEntity);
            await _dataBase.CommitAsync();
        }
        // TODO: add changes for the dto task
        public async Task UpdateTaskAsync(TaskDto task)
        {
            var taskEntity = new TaskEntity()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate ?? DateTime.MinValue,
                FinishDate = task.FinishDate ?? DateTime.MinValue
            };
            await _dataBase.TaskRepository.UpdateAsync(taskEntity);
            await _dataBase.CommitAsync();
        }

        public async Task DeleteTaskAsync(Int32 id)
        {
            await _dataBase.TaskRepository.DeleteAsync(id);
            await _dataBase.CommitAsync();
        }
    }
}