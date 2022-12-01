using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.MasterPetition
{
    public interface IMasterPetitionApplication
    {
        OperationResult Create(CreateMasterPetition command);
        OperationResult Edit(EditMasterPetition command);
        OperationResult Remove(long id);
        EditMasterPetition GetDetails(long id);
        EditMasterPetition GetDetails(long fileId, int boardTypeId);
        List<EditMasterPetition> Search(MasterPetitionSearchModel searchModel);
    }
}
