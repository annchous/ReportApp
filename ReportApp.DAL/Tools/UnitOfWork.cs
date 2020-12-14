﻿using System;
using System.Threading.Tasks;
using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Repositories;

namespace ReportApp.DAL.Tools
{
    public class UnitOfWork : ReportAppContext, IUnitOfWork
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public UnitOfWork()
        {
            _taskRepository = new TaskRepository(this);
            _reportRepository = new ReportRepository(this);
            _employeeRepository = new EmployeeRepository(this);
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}