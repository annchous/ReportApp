using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;
using ReportApp.Core.Services;

namespace ReportApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<TaskDto>>> GetAllTasksAsync()
        {
            var result = await _taskService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("get-id/{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskByIdAsync(Int32 id)
        {
            var result = await _taskService.GetTaskAsync(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateTaskAsync(TaskDto task)
        {
            await _taskService.CreateTaskAsync(task);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateTaskAsync(TaskDto task)
        {
            await _taskService.UpdateTaskAsync(task);
            return Ok();
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeleteTaskAsync(Int32 id)
        {
            await _taskService.DeleteTaskAsync(id);
            return Ok();
        }
    }
}
