using System;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeAsync(Int32 id);
        Task CreateEmployeeAsync(EmployeeDto employee);
        Task UpdateEmployeeAsync(EmployeeDto employee);
        Task DeleteEmployeeAsync(Int32 id);
    }
}