using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.YearlySalaryTitles
{
    public interface IYearlySalaryTitleApplication
    {
        OperationResult Create(CreateTitle command);

  
        OperationResult Edit(EditTitle command);
        EditTitle GetDetails(long id);
       
        List<TitleViewModel> Search(TitleSearchModel searchModel);
    }
}
