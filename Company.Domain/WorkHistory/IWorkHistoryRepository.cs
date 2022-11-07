using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.WorkHistory;

namespace Company.Domain.WorkHistory
{
    public interface IWorkHistoryRepository : IRepository<long, WorkHistory>
    {
        List<EditWorkHistory> Search(long petitionId);
        void RemoveWorkHistories(List<EditWorkHistory> workHistories);
    }
}
