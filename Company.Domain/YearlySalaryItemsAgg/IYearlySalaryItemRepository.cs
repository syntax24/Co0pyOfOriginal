using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.YearlySalaryItems;

namespace Company.Domain.YearlySalaryItemsAgg
{
    public interface IYearlySalaryItemRepository : IRepository<long, YearlySalaryItem>
    {
        EditYearlySalaryItem GetDetails(long id);
        List<YearlysalaryItemViewModel> GetItems(int parentalConnectionId);
        List<YearlysalaryItemViewModel> Search(YearlySalaryItemSearchModel searchModel2);
    }
}
