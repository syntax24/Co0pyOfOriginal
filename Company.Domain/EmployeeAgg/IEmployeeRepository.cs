using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Employee;

namespace Company.Domain.EmployeeAgg
{
    public interface IEmployeeRepository : IRepository<long, Employee>
    {
        List<EmployeeViewModel> GetEmployee();
        EditEmployee GetDetails(long id);
        List<EmployeeViewModel> Search(EmployeeSearchModel searchModel);
    }
}
