using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.LeftWork
{
    public interface ILeftWorkApplication
    {
        OperationResult Create(CreateLeftWork command);
        OperationResult Edit(EditLeftWork command);
        EditLeftWork GetDetails(long id);

        List<LeftWorkViewModel> search(LeftWorkSearchModel searchModel);
        string StartWork(long employeeId, long workshopId, string leftWork);
        OperationResult RemoveLeftWork(long id);

    }
}
