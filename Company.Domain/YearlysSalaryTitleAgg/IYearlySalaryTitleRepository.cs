using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
