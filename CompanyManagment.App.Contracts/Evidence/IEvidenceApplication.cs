using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.Evidence
{
    public interface IEvidenceApplication
    {
        OperationResult Create(CreateEvidence command);
        OperationResult Edit(EditEvidence command);
        OperationResult Remove(long id);
        EditEvidence GetDetails(long id);
        EditEvidence GetDetails(long fileId, int boardTypeId);
        List<EditEvidence> Search(EvidenceSearchModel searchModel);
    }
}
