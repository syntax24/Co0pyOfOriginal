using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
