using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.Evidence;


namespace Company.Domain.Evidence
{
    public interface IEvidenceRepository : IRepository<long, Evidence>
    {
        EditEvidence GetDetails(long id);
        void Remove(long id);
        EditEvidence GetDetails(long fileId, int boardTypeId);
        List<EditEvidence> Search(EvidenceSearchModel searchModel);
    }
}
