using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Core.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<TaskDto> GetTaskAsync(Int32 id);
        Task CreateTaskAsync(TaskDto task);
        Task UpdateTaskAsync(TaskDto task);
        Task DeleteTaskAsync(Int32 id);
    }
}