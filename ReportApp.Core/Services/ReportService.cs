using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reportEntities = await _dataBase.ReportRepository.GetAllAsync();
            return reportEntities
                .Select(reportEntity => ReportMapper.GetInstance().Map<ReportDto>(reportEntity))
                .ToList();
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