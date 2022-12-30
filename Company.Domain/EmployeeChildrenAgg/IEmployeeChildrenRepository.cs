using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.EmployeeChildren;
using CompanyManagment.App.Contracts.Employer;

namespace Company.Domain.EmployeeChildrenAgg
{
    public interface IEmployeeChildrenRepository : IRepository<long, EmployeeChildren>
    {
        List<EmployeeChildernViewModel> GetChildren(string parentalCode);
        EditEmployeeChildren GetDetails(long id);
        List<EmployeeChildernViewModel> Search(EmployeeChildrenSearchModel searchModel);


    }
}
