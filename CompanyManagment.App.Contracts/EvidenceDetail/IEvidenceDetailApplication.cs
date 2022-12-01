using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.EvidenceDetail
{
    public interface IEvidenceDetailApplication
    {
        OperationResult Create(CreateEvidenceDetail command);
        OperationResult Edit(EditEvidenceDetail command);
        List<EditEvidenceDetail> Search(long evidenceId);
        OperationResult CreateEvidenceDetail(List<EditEvidenceDetail> evidenceDetails, long evidenceId);
        void RemoveEvidenceDetails(long evidenceId);
    }
}
