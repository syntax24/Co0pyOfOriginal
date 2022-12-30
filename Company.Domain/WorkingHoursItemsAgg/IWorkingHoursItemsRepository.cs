using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.WorkingHoursItems;

namespace Company.Domain.WorkingHoursItemsAgg
{
    public interface IWorkingHoursItemsRepository : IRepository<long, WorkingHoursItems>
    {
        EditWorkingHoursItems GetDetails(long id);
        List<WorkingHoursItemsViewModel> GetWorkingHoursItems();
        WorkingHoursItemsViewModel GetByWorkingHoursId(long id);
    }
}
