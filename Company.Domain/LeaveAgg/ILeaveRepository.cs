using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Leave;

namespace Company.Domain.LeaveAgg
{
    public interface ILeaveRepository : IRepository<long, Leave>
    {
        EditLeave GetDetails(long id);
        List<LeaveViewModel> search(LeaveSearchModel searchModel);
        OperationResult RemoveLeave(long id);
        bool CheckContractExist(DateTime myDate,long employeeId, long workshopId);
    }
}
