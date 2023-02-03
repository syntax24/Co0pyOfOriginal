using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.EmployeeChildren
{
    public interface IEmployeeChildrenApplication
    {
        OperationResult Create(CreateEmployeChildren command);
        OperationResult Edit(EditEmployeeChildren command);
        EditEmployeeChildren GetDetails(long id);
        List<EmployeeChildernViewModel> GetChildren(string parentalCode);
        List<EmployeeChildernViewModel> Search(EmployeeChildrenSearchModel searchModel);
    }
}
