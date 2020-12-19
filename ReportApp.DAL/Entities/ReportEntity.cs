using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities
{
    public class ReportEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public DateTime CreationDate { get; set; }
        public Int32 EmployeeId { get; set; }
        //public EmployeeEntity Employee { get; set; }
    }
}