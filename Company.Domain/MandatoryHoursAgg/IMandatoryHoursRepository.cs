using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.MandantoryHours;

namespace Company.Domain.MandatoryHoursAgg
{
    public interface IMandatoryHoursRepository :IRepository<long, MandatoryHours>
    {
        List<MandatoryHoursViewModel> GetMandatoryHours();
        EditMandatoryHours GetDetails(long id);
        List<MandatoryHoursViewModel> Search(MandatoryHoursSearchModel searchModel);
    }
}
