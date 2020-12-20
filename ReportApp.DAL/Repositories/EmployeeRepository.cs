using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ReportApp.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ReportAppContext _context;

        public EmployeeRepository(ReportAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetByIdAsync(Int32 id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task InsertAsync(EmployeeEntity employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Int32 id)
        {
            await _context.Employees.DeleteEmployeeAsync(id);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeEntity employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
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

    public static class EmployeeRepositoryExtensions
    {
        public static async Task DeleteEmployeeAsync(this DbSet<EmployeeEntity> employees, Int32 id)
        {
            var employee = await employees.FindAsync(id);
            await Task.Run(() =>  employees.Remove(employee));
        }
    }
}