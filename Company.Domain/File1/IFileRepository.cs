using System;
using System.Collections.Generic;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.File1;


namespace Company.Domain.File1
{
    public interface IFileRepository : IRepository<long, File1>
    {
        EditFile GetDetails(long id);
        List<FileViewModel> Search(FileSearchModel searchModel);
        long FindLastArchiveNumber();
        string GetEmployeeFullNameById(long id);
        string GetEmployerFullNameById(long id);
        List<EmployeeViewModel> GetAllEmploees();
        List<EmployerViewModel> GetAllEmployers();
    }
}
