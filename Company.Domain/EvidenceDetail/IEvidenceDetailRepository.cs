using System;
using System.Collections.Generic;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.EvidenceDetail;


namespace Company.Domain.EvidenceDetail
{
    public interface IEvidenceDetailRepository : IRepository<long, EvidenceDetail>
    {
        List<EditEvidenceDetail> Search(long petitionId);
        void RemoveEvidenceDetails(List<EditEvidenceDetail> evidenceDetails);
    }
}
