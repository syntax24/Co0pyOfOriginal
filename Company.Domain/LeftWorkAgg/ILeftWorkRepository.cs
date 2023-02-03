using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.LeftWork;

namespace Company.Domain.LeftWorkAgg
{
    public interface ILeftWorkRepository : IRepository<long, LeftWork>
    {
        EditLeftWork GetDetails(long id);

        string StartWork(long employeeId, long workshopId, string leftWork);

        List<LeftWorkViewModel> search(LeftWorkSearchModel searchModel);

        OperationResult RemoveLeftWork(long id);
    }
}
