using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.Petition
{
    public interface IPetitionApplication
    {
        OperationResult Create(CreatePetition command);
        OperationResult Edit(EditPetition command);
        EditPetition GetDetails(long id);
        EditPetition GetDetails(long fileId, int boardTypeId);
        List<EditPetition> Search(PetitionSearchModel searchModel);
    }
}
