using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportApp.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace ReportApp.DAL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeEntity>
    {
    }
}