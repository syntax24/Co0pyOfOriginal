using System;
using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.HolidayItem
{
    public interface IHolidayItemApplication 
    {
        OperationResult Create(CreateHolidayItem command);
        OperationResult Edit(EditHolidayItem command);
        EditHolidayItem GetDetails(long id);
        List<string> GetHolidayItem(string year);
        bool GetHoliday(DateTime holidayCheck);
        List<HolidayItemViewModel> Search(HolidayItemSearchModel searchModel);
    }
}
