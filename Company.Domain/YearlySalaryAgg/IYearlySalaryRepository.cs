using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.LeftWork;
using CompanyManagment.App.Contracts.YearlySalary;
using CompanyManagment.App.Contracts.YearlySalaryItems;

namespace Company.Domain.YearlySalaryAgg
{
    public interface IYearlySalaryRepository : IRepository<long, YearlySalary>
    {
        List<YearlySalaryViewModel> GetYearlySalary();
        string DayliFeeComputing(DateTime startDateW,DateTime contractStart, DateTime endDateW, long employeeId, long workshopId,List<LeftWorkViewModel> leftWorkList);
        string ConsumableItems(DateTime endDateW);
        string HousingAllowance(DateTime endDateW);
        string FamilyAllowance(long personelID, DateTime EndCantract);
        EditYearlySalary GetDetails(long id);
        List<YearlySalaryViewModel> Search(YearlySalarySearchModel searchModel);
        int FindConnection();
    }
}
