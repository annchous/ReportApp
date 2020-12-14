using System;

namespace ReportApp.DAL.Entities
{
    public class TaskChangeEntity
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public String Comment { get; set; }
    }
}