using System;

namespace CompanyManagment.App.Contracts.Leave
{
    public class LeaveViewModel
    {
        public long Id { get; set; }
        public string StartLeave { get; set; }
        public string EndLeave { get; set; }
        public DateTime StartLeaveGr { get; set; }
        public DateTime EndLeaveGr { get; set; }
        public string LeaveHourses { get; set; }
        public long WorkshopId { get; set; }
        public long EmployeeId { get; set; }
        public string PaidLeaveType { get; set; }
        public string LeaveType { get; set; }
        public string EmployeeFullName { get; set; }
        public string WorkshopName { get; set; }
    }
}