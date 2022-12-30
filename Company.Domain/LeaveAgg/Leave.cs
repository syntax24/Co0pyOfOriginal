using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace Company.Domain.LeaveAgg
{
    public class Leave: EntityBase
    {
        public Leave(DateTime startLeave, DateTime endLeave,
            string leaveHourses, long workshopId, long employeeId,
            string paidLeaveType, string leaveType, string employeeFullName, string workshopName)
        {
            StartLeave = startLeave;
            EndLeave = endLeave;
            LeaveHourses = leaveHourses;
            WorkshopId = workshopId;
            EmployeeId = employeeId;
            PaidLeaveType = paidLeaveType;
            LeaveType = leaveType;
            EmployeeFullName = employeeFullName;
            WorkshopName = workshopName;
        }

        public DateTime StartLeave { get; private set; }
        public DateTime EndLeave { get; private set; }
        public string LeaveHourses { get; private set; }
        public long WorkshopId { get; private set; }
        public long EmployeeId { get; private set; }
        public string PaidLeaveType { get; private set; }
        public string LeaveType { get; private set; }
        public string EmployeeFullName { get; private set; }
        public string WorkshopName { get; private set; }

        public void Edit(DateTime startLeave, DateTime endLeave,
            string leaveHourses, long workshopId, long employeeId,
            string paidLeaveType, string leaveType, string employeeFullName, string workshopName)
        {
            StartLeave = startLeave;
            EndLeave = endLeave;
            LeaveHourses = leaveHourses;
            WorkshopId = workshopId;
            EmployeeId = employeeId;
            PaidLeaveType = paidLeaveType;
            LeaveType = leaveType;
            EmployeeFullName = employeeFullName;
            WorkshopName = workshopName;
        }
    }
}
