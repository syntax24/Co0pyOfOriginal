using System;
using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.YearlySalary;

namespace Company.Domain.YearlySalaryAgg
{
    public interface IYearlySalaryRepository : IRepository<long, YearlySalary>
    {
        List<YearlySalaryViewModel> GetYearlySalary();
        string DayliFeeComputing(DateTime startDateW, DateTime endDateW);
        string ConsumableItems(DateTime endDateW);
        string HousingAllowance(DateTime endDateW);
        string FamilyAllowance(long personelID, DateTime EndCantract);
        EditYearlySalary GetDetails(long id);
        List<YearlySalaryViewModel> Search(YearlySalarySearchModel searchModel);
        int FindConnection();
    }
}
