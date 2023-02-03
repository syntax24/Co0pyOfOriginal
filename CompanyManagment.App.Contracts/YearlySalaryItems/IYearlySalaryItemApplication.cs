using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.YearlySalaryItems
{
    public interface IYearlySalaryItemApplication
    {
        OperationResult Create(CreateYearlySalaryItem command);
        OperationResult Edit(EditYearlySalaryItem command);
        EditYearlySalaryItem GetDetails(long id);
        List<YearlysalaryItemViewModel> GetItems(int parentalConnectionId);
        List<YearlysalaryItemViewModel> Search(YearlySalaryItemSearchModel searchModel2);
    }
}
