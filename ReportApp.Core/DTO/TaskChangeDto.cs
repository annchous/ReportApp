using System;

namespace ReportApp.Core.DTO
{
    public class TaskChangeDto
    {
        public Int32 Id { get; set; }
        public Int32 TaskId { get; set; }
        public DateTime? Date { get; set; }
        public String Comment { get; set; }
    }
}