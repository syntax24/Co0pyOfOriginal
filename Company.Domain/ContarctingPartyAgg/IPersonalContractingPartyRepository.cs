using CompanyManagment.App.Contracts.PersonalContractingParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace Company.Domain.ContarctingPartyAgg
{
    public interface IPersonalContractingPartyRepository :IRepository<long, PersonalContractingParty>
    {
        List<PersonalContractingPartyViewModel> GetPersonalContractingParties();
        EditPersonalContractingParty GetDetails(long id);
        List<PersonalContractingPartyViewModel> Search(PersonalContractingPartySearchModel searchModel2);
      
    }
}
