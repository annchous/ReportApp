using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Core.Interfaces
{
    public interface ITaskChangeService
    {
        Task CreateTaskChangeAsync(TaskChangeDto taskChange);
        Task<IEnumerable<TaskChangeDto>> GetAllAsync();
        Task<IEnumerable<TaskChangeDto>> GetAllForTaskByIdAsync(Int32 taskId);
    }
}