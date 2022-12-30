using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.WorkingHoursAgg;

namespace Company.Domain.WorkingHoursItemsAgg
{
    public class WorkingHoursItems : EntityBase
    {
        public WorkingHoursItems(string dayOfWork, string start1, string end1, string restTime,
            string start2, string end2, string start3, string end3, string complexStart, string complexEnd,
            long workingHoursId)
        {
            DayOfWork = dayOfWork;
            Start1 = start1;
            End1 = end1;
            RestTime = restTime;
            Start2 = start2;
            End2 = end2;
            Start3 = start3;
            End3 = end3;
            ComplexStart = complexStart;
            ComplexEnd = complexEnd;
            WorkingHoursId = workingHoursId;
        }

        public string DayOfWork { get; private set; }
        public string Start1 { get; private set; }
        public string End1 { get; private set; }
        public string RestTime { get; private set; }
        public string Start2 { get; private set; }
        public string End2 { get; private set; }
        public string Start3 { get; private set; }
        public string End3 { get; private set; }
        public string ComplexStart { get; private set; }
        public string ComplexEnd { get; private set; }
        public long WorkingHoursId { get; private set; }

        public WorkingHours WorkingHourses { get; set; }

        public void Edit(string dayOfWork, string start1, string end1, string restTime, string start2, 
            string end2, string start3, string end3,
            string complexStart, string complexEnd, long workingHoursId)
        {
            DayOfWork = dayOfWork;
            Start1 = start1;
            End1 = end1;
            RestTime = restTime;
            Start2 = start2;
            End2 = end2;
            Start3 = start3;
            End3 = end3;
            ComplexStart = complexStart;
            ComplexEnd = complexEnd;
            WorkingHoursId = workingHoursId;
        }
    }
   
}