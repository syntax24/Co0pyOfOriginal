using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Holiday;

namespace Company.Domain.HolidayAgg
{
    public interface IHolidayRepository : IRepository<long, Holiday>
    {
        List<HolidayViewModel> GetHoliday();
        EditHoliday GetDetails(long id);
        List<HolidayViewModel> Search(HolidaySearchModel searchModel);
    }
}
