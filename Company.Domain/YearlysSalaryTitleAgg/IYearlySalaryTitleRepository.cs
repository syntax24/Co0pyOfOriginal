using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.YearlySalaryTitles;

namespace Company.Domain.YearlysSalaryTitleAgg
{
    public interface IYearlySalaryTitleRepository : IRepository<long, YearlySalaryTitle>
    {
        EditTitle GetDetails(long id);
        List<string> GetLast(); 
        List<TitleViewModel> Search(TitleSearchModel searchModel);
    }

}
