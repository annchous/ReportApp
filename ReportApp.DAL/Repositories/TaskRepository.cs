using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ReportAppContext _context;

        public TaskRepository(ReportAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskEntity> GetByIdAsync(Int32 id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task InsertAsync(TaskEntity task)
        {
            await _context.AddAsync(task);
        }

        public async Task UpdateAsync(TaskEntity task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Int32 id)
        {
            await _context.Tasks.DeleteTaskAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public static class TaskRepositoryExtensions
    {
        public static async Task DeleteTaskAsync(this DbSet<TaskEntity> tasks, Int32 id)
        {
            var task = await tasks.FindAsync(id);
            await Task.Run(() => tasks.Remove(task));
        }
    }
}