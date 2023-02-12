using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.HolidayItemAgg;

namespace Company.Domain.HolidayAgg
{
    public class Holiday : EntityBase
    {
        public Holiday(string year)
        {
            Year = year;
           
        }

        public string Year { get; private set; }
        public List<HolidayItem> HolidayItems { get; set; }

        public Holiday()
        {
            HolidayItems = new List<HolidayItem>();
        }
        public void Edit(string year)
        {
            Year = year;
        }
    }
}
