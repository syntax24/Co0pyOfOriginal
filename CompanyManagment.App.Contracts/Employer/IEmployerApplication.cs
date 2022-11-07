using System.Collections.Generic;
using _0_Framework.Application;


namespace CompanyManagment.App.Contracts.Employer
{
    public interface IEmployerApplication
    {
        OperationResult Create(CreateEmployer command);
        OperationResult Edit(EditEmployer command);

        OperationResult EditEmployerNo(EditEmployer command);
        OperationResult CreateLegals(CreateEmployer command);
        OperationResult EditLegal(EditEmployer command);

        EditEmployer GetDetails(long id);

        OperationResult Active(long id);
        OperationResult DeActive(long id);

        List<EmployerViewModel> GetEmployers();
        List<EmployerViewModel> Search(EmployerSearchModel searchModel);
    }
}
