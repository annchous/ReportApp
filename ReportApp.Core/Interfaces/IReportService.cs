using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Core.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetAllAsync();
        Task<ReportDto> GetReportAsync(Int32 id);
        Task CreateReportAsync(ReportDto report);
        Task UpdateReportAsync(ReportDto report);
        Task DeleteReportAsync(Int32 id);
        Task<Boolean> HasSprintReportAsync();
        Task<ReportDto> GetSprintReportAsync();
    }
}