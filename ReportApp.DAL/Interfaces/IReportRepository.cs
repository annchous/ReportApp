using System;
using System.Threading.Tasks;
using ReportApp.DAL.Entities;

namespace ReportApp.DAL.Interfaces
{
    public interface IReportRepository : IGenericRepository<ReportEntity>
    {
        Task<Boolean> HasSprintReportAsync();
    }
}