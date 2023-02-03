using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.WorkHistory;

namespace Company.Domain.WorkHistory
{
    public interface IWorkHistoryRepository : IRepository<long, WorkHistory>
    {
        List<EditWorkHistory> Search(long petitionId);
        void RemoveWorkHistories(List<EditWorkHistory> workHistories);
    }
}
