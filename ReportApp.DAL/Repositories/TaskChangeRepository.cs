using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.Repositories
{
    public class TaskChangeRepository : ITaskChangeRepository
    {
        private readonly ReportAppContext _context;

        public TaskChangeRepository(ReportAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskChangeEntity>> GetAllAsync()
        {
            return await _context.TaskChanges.ToListAsync();
        }

        public async Task<TaskChangeEntity> GetByIdAsync(Int32 id)
        {
            return await _context.TaskChanges.FindAsync(id);
        }

        public async Task InsertAsync(TaskChangeEntity taskChange)
        {
            await _context.AddAsync(taskChange);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskChangeEntity taskChange)
        {
            _context.Entry(taskChange).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Int32 id)
        {
            await _context.TaskChanges.DeleteTaskAsync(id);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    public static class TaskChangeRepositoryExtensions
    {
        public static async Task DeleteTaskAsync(this DbSet<TaskChangeEntity> taskChanges, Int32 id)
        {
            var taskChange = await taskChanges.FindAsync(id);
            await Task.Run(() => taskChanges.Remove(taskChange));
        }
    }
}