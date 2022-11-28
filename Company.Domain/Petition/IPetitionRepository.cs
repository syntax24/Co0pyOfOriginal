using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework_b.Domain;
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
