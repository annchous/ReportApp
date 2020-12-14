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

        public async Task<ReportDto> GetReportAsync(Int32 id)
        {
            var report = await _dataBase.ReportRepository.GetByIdAsync(id);
            return ReportMapper.GetInstance().Map<ReportDto>(report);
        }

        public async Task CreateReportAsync(ReportDto report)
        {
            var reportEntity = ReportMapper.GetInstance().Map<ReportEntity>(report);
            await _dataBase.ReportRepository.InsertAsync(reportEntity);
            await _dataBase.CommitAsync();
        }

        public async Task UpdateReportAsync(ReportDto report)
        {
            var reportEntity = ReportMapper.GetInstance().Map<ReportEntity>(report);
            await _dataBase.ReportRepository.UpdateAsync(reportEntity);
            await _dataBase.CommitAsync();
        }

        public async Task DeleteReportAsync(Int32 id)
        {
            await _dataBase.ReportRepository.DeleteAsync(id);
            await _dataBase.CommitAsync();
        }
    }
}