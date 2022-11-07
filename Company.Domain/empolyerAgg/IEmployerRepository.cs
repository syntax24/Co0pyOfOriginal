using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Employer;

namespace Company.Domain.empolyerAgg
{
    public interface IEmployerRepository : IRepository<long, Employer>
    {
        List<EmployerViewModel> GetEmployers();
        List<EmployerViewModel> GetEmployers(List<long> id);
        EditEmployer GetDetails(long id);
        List<EmployerViewModel> Search(EmployerSearchModel searchModel);
    }
}