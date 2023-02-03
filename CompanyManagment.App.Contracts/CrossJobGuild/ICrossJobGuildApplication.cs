using System.Collections.Generic;
using _0_Framework.Application;
using CompanyManagment.App.Contracts.CrossJobGuild;

namespace CompanyManagment.App.Contracts.CrossJobGuild
{
    public interface ICrossJobGuildApplication
    {
        OperationResult Create(CreateCrossJobGuild command);
        OperationResult Edit(EditCrossJobGuild command);
        OperationResult Validation(CreateCrossJobGuild command);
        OperationResult ValidationEdit(EditCrossJobGuild command);
        EditCrossJobGuild GetDetails(long id);
        OperationResult Remove(long id);
        List<CrossJobGuildViewModel> GetCrossJobGuild();
        List<CrossJobGuildViewModel> Search(CrossJobGuildSearchModel searchModel);
    }
}
