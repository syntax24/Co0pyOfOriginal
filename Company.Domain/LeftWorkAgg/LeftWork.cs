using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.EmployeeAgg;
using Company.Domain.WorkshopAgg;

namespace Company.Domain.LeftWorkAgg
{
    public class LeftWork : EntityBase
    {
        public LeftWork(DateTime leftWorkDate, DateTime startWorkDate, long workshopId, long employeeId, string employeeFullName, string workshopName)
        {
            LeftWorkDate = leftWorkDate;
            StartWorkDate = startWorkDate;
            WorkshopId = workshopId;
            EmployeeId = employeeId;
            this.EmployeeFullName = employeeFullName;
            this.WorkshopName = workshopName;
        }

        public DateTime LeftWorkDate { get; private set; }
        public DateTime StartWorkDate { get; private set; }
        public long WorkshopId { get; private set; }
        public long EmployeeId { get; private set; }
        public string EmployeeFullName { get; private set; }
        public string WorkshopName { get; private set; }
        public Employee Employee { get; set; }
        public Workshop Workshop { get; set; }
        public void Edit(DateTime leftWorkDate, DateTime startWorkDate, long workshopId, long employeeId)
        {
            LeftWorkDate = leftWorkDate;
            StartWorkDate = startWorkDate;
            WorkshopId = workshopId;
            EmployeeId = employeeId;
    
        }
    }
}
