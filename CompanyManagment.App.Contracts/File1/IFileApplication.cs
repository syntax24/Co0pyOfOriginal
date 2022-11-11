using System.Collections.Generic;
using _0_Framework.Application;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;

namespace CompanyManagment.App.Contracts.File1
{
    public interface IFileApplication
    {
        OperationResult Create(CreateFile command);
        OperationResult Edit(EditFile command);
        EditFile GetDetails(long id);
        List<FileViewModel> Search(FileSearchModel searchModel);

        FileViewModel GetLastArchiveNumber(FileSearchModel searchModel);
        long FindLastArchiveNumber();
        string GetEmployeeFullNameById(long id);
        string GetEmployerFullNameById(long id);
        List<EmployeeViewModel> GetAllEmploees();
        List<EmployerViewModel> GetAllEmployers();
    }
}
