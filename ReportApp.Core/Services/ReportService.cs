using System;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Tools;

namespace ReportApp.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly UnitOfWork _dataBase;

        public ReportService(UnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }
        // TODO: add employee and task for the report
        public async Task<ReportDto> GetReportAsync(Int32 id)
        {
            var report = await _dataBase.Reports.GetByIdAsync(id);
            return new ReportDto()
            {
                Id = report.Id,
                Body = report.Body,
                CreationDate = report.CreationDate
            };
        }
        // TODO: add employee and task for the report
        public async Task CreateReportAsync(ReportDto report)
        {
            var reportEntity = new ReportEntity()
            {
                Id = report.Id,
                Body = report.Body,
                CreationDate = report.CreationDate ?? DateTime.MinValue,

            };
            await _dataBase.Reports.InsertAsync(reportEntity);
            await _dataBase.CommitAsync();
        }
        // TODO: add employee and task for the report
        public async Task UpdateReportAsync(ReportDto report)
        {
            var reportEntity = new ReportEntity()
            {
                Id = report.Id,
                Body = report.Body,
                CreationDate = report.CreationDate ?? DateTime.MinValue
            };
            await _dataBase.Reports.UpdateAsync(reportEntity);
            await _dataBase.CommitAsync();
        }

        public async Task DeleteReportAsync(Int32 id)
        {
            await _dataBase.Reports.DeleteAsync(id);
            await _dataBase.CommitAsync();
        }
    }
}