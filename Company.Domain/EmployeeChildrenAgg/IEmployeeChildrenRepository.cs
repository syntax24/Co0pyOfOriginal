using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.EmployeeChildren;

namespace Company.Domain.EmployeeChildrenAgg
{
    public interface IEmployeeChildrenRepository : IRepository<long, EmployeeChildren>
    {
        List<EmployeeChildernViewModel> GetChildren(string parentalCode);
        EditEmployeeChildren GetDetails(long id);
        List<EmployeeChildernViewModel> Search(EmployeeChildrenSearchModel searchModel);


    }
}
