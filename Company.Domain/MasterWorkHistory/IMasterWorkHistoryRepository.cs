using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.MasterWorkHistory;

namespace Company.Domain.MasterWorkHistory
{
    public interface IMasterWorkHistoryRepository : IRepository<long, MasterWorkHistory>
    {
        List<EditMasterWorkHistory> Search(long petitionId);
        void RemoveMasterWorkHistories(IEnumerable<EditMasterWorkHistory> MasterWorkHistories);
    }
}
