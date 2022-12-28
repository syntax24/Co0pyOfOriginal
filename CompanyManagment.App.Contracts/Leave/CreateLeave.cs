using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagment.App.Contracts.Leave
{
    public class CreateLeave
    {
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string StartLeave { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string EndLeave { get; set; }
        public string LeaveHourses { get; set; }
        public long WorkshopId { get; set; }
        public long EmployeeId { get; set; }
        public string PaidLeaveType { get; set; }
        public string LeaveType { get; set; }
        public string EmployeeFullName { get; set; }
        public string WorkshopName { get; set; }
        public List<LeaveViewModel> LeaveSearch { get; set; }
    }
}
