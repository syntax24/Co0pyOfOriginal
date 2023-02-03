using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;
using Company.Domain.WorkingHoursItemsAgg;

namespace Company.Domain.WorkingHoursAgg
{
    public class WorkingHours : EntityBase
    {
        public WorkingHours(string shiftWork, string contractNo,
            string numberOfWorkingDays, string numberOfFriday, string totalHoursesH, string totalHoursesM, string overTimeWorkH, string overTimeWorkM,
            string overNightWorkH, string overNightWorkM, string weeklyWorkingTime, long contractId)
        {
            ShiftWork = shiftWork;
            ContractNo = contractNo;
            NumberOfWorkingDays = numberOfWorkingDays;
            NumberOfFriday = numberOfFriday;
            TotalHoursesH = totalHoursesH;
            TotalHoursesM = totalHoursesM;
            OverTimeWorkH = overTimeWorkH;
            OverTimeWorkM = overTimeWorkM;
            OverNightWorkH = overNightWorkH;
            OverNightWorkM = overNightWorkM;
            WeeklyWorkingTime = weeklyWorkingTime;
            ContractId = contractId;
        }

        public string ShiftWork { get; private set; }
        public string ContractNo { get; private set; }
        public string NumberOfWorkingDays { get; private set; }
        public string NumberOfFriday { get; private set; }
        public string TotalHoursesH { get; private set; }
        public string TotalHoursesM { get; private set; }
        public string OverTimeWorkH { get; private set; }
        public string OverTimeWorkM { get; private set; }
        public string OverNightWorkH { get; private set; }
        public string OverNightWorkM { get; private set; }
        public string WeeklyWorkingTime { get; private set; }
        public long ContractId { get; private set; }

        public Contract Contracts { get; set; }

        public List<WorkingHoursItems> WorkingHoursItemsList { get; private set; }

        public WorkingHours()
        {
            WorkingHoursItemsList = new List<WorkingHoursItems>();
        }

        public void Edit(string shiftWork, string contractNo,
            string numberOfWorkingDays, string numberOfFriday, string totalHoursesH, string totalHoursesM, string overTimeWorkH, string overTimeWorkM,
            string overNightWorkH, string overNightWorkM, string weeklyWorkingTime, long contractId)
        {
            ShiftWork = shiftWork;
            ContractNo = contractNo;
            NumberOfWorkingDays = numberOfWorkingDays;
            NumberOfFriday = numberOfFriday;
            TotalHoursesH = totalHoursesH;
            TotalHoursesM = totalHoursesM;
            OverTimeWorkH = overTimeWorkH;
            OverTimeWorkM = overTimeWorkM;
            OverNightWorkH = overNightWorkH;
            OverNightWorkM = overNightWorkM;
            WeeklyWorkingTime = weeklyWorkingTime;
            ContractId = contractId;
        }

    }
}
