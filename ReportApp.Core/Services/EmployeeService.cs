using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<EmployeeDto> GetEmployeeAsync(Int32 id)
        {
            var employee = await _dataBase.EmployeeRepository.GetByIdAsync(id);
            return EmployeeMapper.GetInstance().Map<EmployeeDto>(employee);
        }

        public async Task CreateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = EmployeeMapper.GetInstance().Map<EmployeeEntity>(employee);
            await _dataBase.EmployeeRepository.InsertAsync(employeeEntity);
            await _dataBase.CommitAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = EmployeeMapper.GetInstance().Map<EmployeeEntity>(employee);
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