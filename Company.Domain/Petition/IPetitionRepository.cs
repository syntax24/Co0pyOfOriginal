using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Petition;


namespace Company.Domain.Petition
{
    public interface IPetitionRepository : IRepository<long, Petition>
    {
        EditPetition GetDetails(long id);
        EditPetition GetDetails(long fileId, int boardTypeId);
        List<EditPetition> Search(PetitionSearchModel searchModel);
    }
}
