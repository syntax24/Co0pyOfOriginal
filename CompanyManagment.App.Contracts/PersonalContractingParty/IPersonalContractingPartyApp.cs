using _0_Framework.Application;
using System.Collections.Generic;


namespace CompanyManagment.App.Contracts.PersonalContractingParty
{
    public interface IPersonalContractingPartyApp
    {
        OperationResult Create(CreatePersonalContractingParty command);
        OperationResult Edit(EditPersonalContractingParty command);

        OperationResult Edit2(EditPersonalContractingParty command);

        OperationResult CreateLegals(CreatePersonalContractingParty command);
        OperationResult EditLegal(EditPersonalContractingParty command);

        EditPersonalContractingParty GetDetails(long id);
        List<PersonalContractingPartyViewModel> GetPersonalContractingParties();

        List<PersonalContractingPartyViewModel> Search(PersonalContractingPartySearchModel searchModel2);
       
    }
}
