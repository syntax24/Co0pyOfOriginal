using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.MandantoryHours
{
    public interface IMandatoryHoursApplication
    {
        OperationResult Create(CreateMandatoryHours command);
        OperationResult Edit(EditMandatoryHours command);
        EditMandatoryHours GetDetails(long id);
        List<MandatoryHoursViewModel> GetMandatoryHours();  
        List<MandatoryHoursViewModel> Search(MandatoryHoursSearchModel searchModel);
    }
}
