using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.MasterPetition;


namespace Company.Domain.MasterPetition
{
    public interface IMasterPetitionRepository : IRepository<long, MasterPetition>
    {
        EditMasterPetition GetDetails(long id);
        EditMasterPetition GetDetails(long fileId, int boardTypeId);
        List<EditMasterPetition> Search(MasterPetitionSearchModel searchModel);
        void Remove(long id);

    }
}
