using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.YearlySalary
{
    public interface IYearlySalaryApplication
    {
        OperationResult Create(CreateYearlySalary command);
        OperationResult Edit(EditYearlySalary command);
        OperationResult Err();
        EditYearlySalary GetDetails(long id);
        List<YearlySalaryViewModel> GetYearlySalary();
        List<YearlySalaryViewModel> Search(YearlySalarySearchModel searchModel);
    }
}
