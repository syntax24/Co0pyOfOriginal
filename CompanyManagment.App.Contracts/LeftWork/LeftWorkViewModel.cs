using System;

namespace CompanyManagment.App.Contracts.LeftWork
{
    public class LeftWorkViewModel
    {
        public long Id { get; set; }
        public string LeftWorkDate { get; set; }
        public string StartWorkDate { get; set; }
        public DateTime LeftWorkDateGr { get; set; }
        public DateTime StartWorkDateGr { get; set; }
        public long WorkshopId { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public string WorkshopName { get; set; }
    }
}