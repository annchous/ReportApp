using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Services;

namespace ReportApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<TaskDto>>> GetAllTasksAsync()
        {
            var result = await _taskService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<TaskDto>> GetTaskByIdAsync(Int32 id)
        {
            var result = await _taskService.GetTaskAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTaskAsync(TaskDto task)
        {
            await _taskService.CreateTaskAsync(task);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateTaskAsync(TaskDto task)
        {
            await _taskService.UpdateTaskAsync(task);
            return Ok();
        }
    }
}
