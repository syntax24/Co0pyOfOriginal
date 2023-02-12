using _0_Framework.Application;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.CrossJobItems
{
    public interface ICrossJobItemsApplication
    {
        OperationResult Create(CreateCrossJobItems command);
        CrossJobItemsViewModel GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult RemoveRange(long idcrossJob);

        List<CrossJobItemsViewModel> GetCrossJobItems(long idGuild);
        List<CrossJobItemsViewModel> Search(CrossJobItemsSearchModel searchModel);

    }
}