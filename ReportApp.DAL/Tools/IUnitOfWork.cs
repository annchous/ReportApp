using System;
using System.Threading.Tasks;

namespace ReportApp.DAL.Tools
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}