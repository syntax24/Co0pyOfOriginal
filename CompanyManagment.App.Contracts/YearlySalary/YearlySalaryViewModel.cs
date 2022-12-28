using System;

namespace CompanyManagment.App.Contracts.YearlySalary
{
    public class YearlySalaryViewModel
    {
        public long Id { get; set; }
        public string StartDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public string Year { get; set; }
        public string EndDate { get; set; }
        public int ConnectionId { get; set; }

    }
}