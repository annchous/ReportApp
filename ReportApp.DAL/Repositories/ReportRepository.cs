using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Tools;
using Task = System.Threading.Tasks.Task;

namespace ReportApp.DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportAppContext _context;

        public ReportRepository(ReportAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReportEntity>> GetAllAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<ReportEntity> GetByIdAsync(Int32 id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task InsertAsync(ReportEntity report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Int32 id)
        {
            await _context.Reports.DeleteReportAsync(id);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReportEntity report)
        {
            _context.Entry(report).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Boolean> HasSprintReportAsync()
        {
            return await _context.Reports.AnyAsync(r => r.Type == ReportType.Sprint);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    public static class ReportRepositoryExtensions
    {
        public static async Task DeleteReportAsync(this DbSet<ReportEntity> reports, Int32 id)
        {
            var report = await reports.FindAsync(id);
            await Task.Run(() => reports.Remove(report));
        }
    }
}