using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.MasterPenaltyTitle
{
    public interface IMasterPenaltyTitleApplication
    {
        OperationResult Create(CreateMasterPenaltyTitle command);
        OperationResult Edit(EditMasterPenaltyTitle command);
        List<EditMasterPenaltyTitle> Search(long MasterPetitionId);
        OperationResult CreateMasterPenaltyTitles(List<EditMasterPenaltyTitle> MasterPenaltyTitles, long MasterPetitionId);
        void RemoveMasterPenaltyTitles(long MasterPetitionId);
    }
}
