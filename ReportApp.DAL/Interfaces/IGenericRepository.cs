using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportApp.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Int32 id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Int32 id);
        IEnumerable<TEntity> GetAll();
        Task SaveAsync();
    }
}