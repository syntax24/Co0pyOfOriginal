using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.WorkingHours
{
    public interface IWorkingHoursApplication
    {
        OperationResult Create(CreateWorkingHours command);

        OperationResult Edit(EditWorkingHours command);

        EditWorkingHours GetDetails(long id);
        List<WorkingHoursViewModel> GetWorkingHours();
        WorkingHoursViewModel GetByContractId(long id);
    }
}
