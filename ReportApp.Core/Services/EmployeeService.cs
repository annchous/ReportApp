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
        // TODO: add tasks and employees (+boss) to the employee dto
        public async Task<EmployeeDto> GetEmployeeAsync(Int32 id)
        {
            var employee = await _dataBase.EmployeeRepository.GetByIdAsync(id);
            return new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name
            };
        }
        // TODO: add tasks and employees (+boss) to the employee dto
        public async Task CreateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = new EmployeeEntity()
            {
                Id = employee.Id,
                Name = employee.Name
            };
            await _dataBase.EmployeeRepository.InsertAsync(employeeEntity);
            await _dataBase.CommitAsync();
        }
        // TODO: add tasks and employees (+boss) to the employee dto
        public async Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = new EmployeeEntity()
            {
                Id = employee.Id,
                Name = employee.Name
            };
            await _dataBase.EmployeeRepository.UpdateAsync(employeeEntity);
            await _dataBase.CommitAsync();
        }

        public async Task DeleteEmployeeAsync(Int32 id)
        {
            await _dataBase.EmployeeRepository.DeleteAsync(id);
            await _dataBase.CommitAsync();
        }
    }
}