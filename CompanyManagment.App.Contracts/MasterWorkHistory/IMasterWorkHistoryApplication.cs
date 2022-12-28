using System.Collections.Generic;
using _0_Framework.Application;


namespace CompanyManagment.App.Contracts.MasterWorkHistory
{
    public interface IMasterWorkHistoryApplication
    {
        OperationResult Create(CreateMasterWorkHistory command);
        OperationResult Edit(EditMasterWorkHistory command);
        List<EditMasterWorkHistory> Search(long masterPetitionId);
        OperationResult CreateMasterWorkHistories(List<EditMasterWorkHistory> masterWorkHistories, long masterPetitionId);
        void RemoveMasterWorkHistories(long masterPetitionId);
    }
}
