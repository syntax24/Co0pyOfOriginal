using _0_Framework.Application;
using CompanyManagment.App.Contracts.CrossJobGuild;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.CrossJob
{
    public interface ICrossJobApplication
    {
        OperationResult Create(CreateCrossJob command);
        OperationResult Edit(EditCrossJob command);
        EditCrossJob GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult RemoveRange(long id);
        List<CrossJobViewModel> GetCrossJob(long idGuild);
        List<CrossJobViewModel> Search(CrossJobSearchModel searchModel);
    }
}