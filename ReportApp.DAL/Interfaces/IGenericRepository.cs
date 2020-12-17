using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportApp.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Int32 id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Int32 id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task SaveAsync();
    }
}