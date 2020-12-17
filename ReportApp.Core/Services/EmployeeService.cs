using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Repositories;
using ReportApp.DAL.Tools;

namespace ReportApp.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(ReportAppContext context)
        {
            _repository = new EmployeeRepository(context);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employeeEntities = await _repository.GetAllAsync();
            return employeeEntities
                .Select(employeeEntity => EmployeeMapper.GetInstance().Map<EmployeeDto>(employeeEntity))
                .ToList();
            }

        public async Task<EmployeeDto> GetEmployeeAsync(Int32 id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return EmployeeMapper.GetInstance().Map<EmployeeDto>(employee);
        }

        public async Task CreateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = EmployeeMapper.GetInstance().Map<EmployeeEntity>(employee);
            await _repository.InsertAsync(employeeEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = EmployeeMapper.GetInstance().Map<EmployeeEntity>(employee);
            await _repository.UpdateAsync(employeeEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteEmployeeAsync(Int32 id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }
    }
}