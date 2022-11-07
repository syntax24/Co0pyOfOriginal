using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.PenaltyTitle
{
    public interface IPenaltyTitleApplication
    {
        OperationResult Create(CreatePenaltyTitle command);
        OperationResult Edit(EditPenaltyTitle command);
        List<EditPenaltyTitle> Search(long petitionId);
        OperationResult2 CreatePenaltyTitles(List<EditPenaltyTitle> penaltyTitles, long petitionId);
        void RemovePenaltyTitles(long petitionId);
    }
}
