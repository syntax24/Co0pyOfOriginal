using CompanyManagment.App.Contracts.PersonalContractingParty;
using System.Collections.Generic;
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
