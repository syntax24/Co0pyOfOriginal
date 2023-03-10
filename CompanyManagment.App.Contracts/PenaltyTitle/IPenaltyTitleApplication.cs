using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.PenaltyTitle
{
    public interface IPenaltyTitleApplication
    {
        OperationResult Create(CreatePenaltyTitle command);
        OperationResult Edit(EditPenaltyTitle command);
        List<EditPenaltyTitle> Search(long petitionId);
        OperationResult CreatePenaltyTitles(List<EditPenaltyTitle> penaltyTitles, long petitionId);
        void RemovePenaltyTitles(long petitionId);
    }
}
