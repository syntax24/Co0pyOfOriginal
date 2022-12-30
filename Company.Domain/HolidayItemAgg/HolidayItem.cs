using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.HolidayAgg;

namespace Company.Domain.HolidayItemAgg
{
    public class HolidayItem : EntityBase
    {
        public HolidayItem(DateTime holidaydate, long holidayId, string holidayYear)
        {
            Holidaydate = holidaydate;
            HolidayId = holidayId;
            HolidayYear = holidayYear;
        }

        public DateTime Holidaydate { get; private set; }
        public long HolidayId { get; private set; }
        public string HolidayYear { get; private set; }

        public Holiday Holidayss { get; set; }

        public void Edit(DateTime holidaydate, long holidayId, string holidayYear)
        {
            Holidaydate = holidaydate;
            HolidayId = holidayId;
            HolidayYear = holidayYear;

        }
    }
}
