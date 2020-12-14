using System;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Core.Interfaces
{
    public interface IReportService
    {
        Task<ReportDto> GetReportAsync(Int32 id);
        Task CreateReportAsync(ReportDto report);
        Task UpdateReportAsync(ReportDto report);
        Task DeleteReportAsync(Int32 id);
    }
}