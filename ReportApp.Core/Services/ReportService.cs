using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Repositories;
using ReportApp.DAL.Tools;

namespace ReportApp.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(ReportAppContext context)
        {
            _repository = new ReportRepository(context);
        }

        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reportEntities = await _repository.GetAllAsync();
            return reportEntities
                .Select(reportEntity => ReportMapper.GetToDtoMapper().Map<ReportDto>(reportEntity))
                .ToList();
        }

        public async Task<ReportDto> GetReportAsync(Int32 id)
        {
            var report = await _repository.GetByIdAsync(id);
            return ReportMapper.GetToDtoMapper().Map<ReportDto>(report);
        }

        public async Task CreateReportAsync(ReportDto report)
        {
            var reportEntity = ReportMapper.GetFromDtoMapper().Map<ReportEntity>(report);
            await _repository.InsertAsync(reportEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateReportAsync(ReportDto report)
        {
            var reportEntity = ReportMapper.GetFromDtoMapper().Map<ReportEntity>(report);
            await _repository.UpdateAsync(reportEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteReportAsync(Int32 id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }
    }
}