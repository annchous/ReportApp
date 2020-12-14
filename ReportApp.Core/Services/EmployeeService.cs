using System;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Tools;

namespace ReportApp.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UnitOfWork _dataBase;

        public EmployeeService(UnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<EmployeeDto> GetEmployee(Int32 id)
        {
            var employee = await _dataBase.Employees.GetByIdAsync(id);
            return new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name
            };
        }

        public async Task CreateEmployee(EmployeeDto employee)
        {
            var employeeEntity = new EmployeeEntity()
            {
                Id = employee.Id,
                Name = employee.Name
            };
            await _dataBase.Employees.InsertAsync(employeeEntity);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmployeeDto employee)
        {
            var employeeEntity = new EmployeeEntity()
            {
                Id = employee.Id,
                Name = employee.Name
            };
            await _dataBase.Employees.UpdateAsync(employeeEntity);
            await _dataBase.CommitAsync();
        }

        public async Task DeleteEmployee(Int32 id)
        {
            await _dataBase.Employees.DeleteAsync(id);
            await _dataBase.CommitAsync();
        }
    }
}