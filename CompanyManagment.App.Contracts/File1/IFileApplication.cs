using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;

namespace CompanyManagment.App.Contracts.File1
{
    public interface IFileApplication
    {
        OperationResult Create(CreateFile command);
        OperationResult Edit(EditFile command);
        EditFile GetDetails(long id);
        FileSummary GetFileSummary(long id);
        FileViewModel GetFileDetails(FileViewModel file);
        FileViewModel GetFileDetailsByBoardId(long boardId);
        List<FileViewModel> Search(FileSearchModel searchModel);
        FileViewModel GetLastArchiveNumber(FileSearchModel searchModel);
        bool FilterFileDetails(FileViewModel tempViewModel, FileSearchModel fileSearchModel);
        long FindLastArchiveNumber();
        string GetEmployeeFullNameById(long id);
        string GetEmployerFullNameById(long id);
        List<EmployeeViewModel> GetAllEmploees(bool filter = true);
        List<EmployerViewModel> GetAllEmployers(bool filter = true);
        //bool CheckValue(string viewModel, string searchModel);
    }
}
