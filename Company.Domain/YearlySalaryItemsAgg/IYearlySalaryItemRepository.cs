using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.YearlySalaryAgg;
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
