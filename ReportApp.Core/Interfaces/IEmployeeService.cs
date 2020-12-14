using System;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployee(Int32 id);
        Task CreateEmployee(EmployeeDto employee);
        Task UpdateEmployee(EmployeeDto employee);
        Task DeleteEmployee(Int32 id);
    }
}