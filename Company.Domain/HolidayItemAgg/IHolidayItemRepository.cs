using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.HolidayItem;

namespace Company.Domain.HolidayItemAgg
{
    public interface IHolidayItemRepository : IRepository<long, HolidayItem>
    {
        List<string> GetHolidayItem(string year);
        void RemoveItems(string year);
        bool GetHoliday(DateTime holidayCheck);
        EditHolidayItem GetDetails(long id);
        List<HolidayItemViewModel> Search(HolidayItemSearchModel searchModel);
    }
}
