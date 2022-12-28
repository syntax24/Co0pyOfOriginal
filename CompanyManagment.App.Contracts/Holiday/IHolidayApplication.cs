using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Holiday
{
    public interface IHolidayApplication
    {
        OperationResult Create(CreateHoliday command);
        OperationResult Edit(EditHoliday command);
        EditHoliday GetDetails(long id);
        List<HolidayViewModel> GetHoliday();
        List<HolidayViewModel> Search(HolidaySearchModel searchModel);
    }
}
