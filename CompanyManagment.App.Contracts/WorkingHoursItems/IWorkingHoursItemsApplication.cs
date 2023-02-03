using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.WorkingHoursItems
{
    public interface IWorkingHoursItemsApplication
    {
        OperationResult Create(CreateWorkingHoursItems command);

        OperationResult Edit(EditWorkingHoursItems command);

        EditWorkingHoursItems GetDetails(long id);
        List<WorkingHoursItemsViewModel> GetWorkingHoursItems();
        WorkingHoursItemsViewModel GetByWorkingHoursId(long id);
    }
}
