using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.WorkingHours;

namespace Company.Domain.WorkingHoursAgg
{
    public interface IWorkingHoursRepository: IRepository<long, WorkingHours>
    {
        EditWorkingHours GetDetails(long id);
        List<WorkingHoursViewModel> GetWorkingHours();
        WorkingHoursViewModel GetByContractId(long id);
    }
}
