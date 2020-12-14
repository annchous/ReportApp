﻿using Microsoft.EntityFrameworkCore;
using ReportApp.DAL.Entities;

namespace ReportApp.DAL.Context
{
    public class ReportAppContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }

        public ReportAppContext()
        {
        }

        public ReportAppContext(DbContextOptions<ReportAppContext> options) : base(options)
        {
        }
    }
}