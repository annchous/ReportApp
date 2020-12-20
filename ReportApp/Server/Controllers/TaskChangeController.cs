using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;

namespace ReportApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskChangeController : ControllerBase
    {
        private readonly ITaskChangeService _taskChangeService;

        public TaskChangeController(ITaskChangeService taskChangeService)
        {
            _taskChangeService = taskChangeService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<TaskChangeDto>>> GetAllTasksChangesAsync()
        {
            var result = await _taskChangeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("get-taskId/{taskId}")]
        public async Task<ActionResult<List<TaskChangeDto>>> GetTaskByIdAsync(Int32 taskId)
        {
            var result = await _taskChangeService.GetAllForTaskByIdAsync(taskId);
            return Ok(result);
        }
        
        [HttpPost("add")]
        public async Task<ActionResult> CreateTaskChangeAsync(TaskChangeDto taskChange)
        {
            await _taskChangeService.CreateTaskChangeAsync(taskChange);
            return Ok();
        }
    }
}
