using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Leave
{
    public interface ILeaveApplication
    {
        OperationResult Create(CreateLeave command);
        OperationResult Edit(EditLeave command);
        EditLeave GetDetails(long id);
        List<LeaveViewModel> search(LeaveSearchModel searchModel);
        OperationResult RemoveLeave(long id);
    }
}
