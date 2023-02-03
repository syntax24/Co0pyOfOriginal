using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Employee
{
    public interface IEmployeeApplication
    {
        OperationResult Create(CreateEmployee command);
        OperationResult Edit(EditEmployee command);
        EditEmployee GetDetails(long id);
        OperationResult Active(long id);
        OperationResult DeActive(long id);

        List<EmployeeViewModel> GetEmployee();
        List<EmployeeViewModel> Search(EmployeeSearchModel searchModel);
    }
}
