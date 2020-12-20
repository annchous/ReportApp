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
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<ReportDto>>> GetAllReportsAsync()
        {
            var result = await _reportService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("get-id/{id}")]
        public async Task<ActionResult<ReportDto>> GetReportByIdAsync(Int32 id)
        {
            var result = await _reportService.GetReportAsync(id);
            return Ok(result);
        }

        [HttpGet("get-sprint")]
        public async Task<ActionResult<ReportDto>> GetSprintReportAsync(Int32 id)
        {
            var result = await _reportService.GetSprintReportAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateReportAsync(ReportDto report)
        {
            await _reportService.CreateReportAsync(report);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateReportAsync(ReportDto report)
        {
            await _reportService.UpdateReportAsync(report);
            return Ok();
        }

        [HttpGet("has-sprint")]
        public async Task<ActionResult<Boolean>> HasSprintReportAsync()
        {
            var result = await _reportService.HasSprintReportAsync();
            return Ok(result);
        }
    }
}
