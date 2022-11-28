using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.MasterPenaltyTitle;


namespace Company.Domain.MasterPenaltyTitle
{
    public interface IMasterPenaltyTitleRepository : IRepository<long, MasterPenaltyTitle>
    {
        List<EditMasterPenaltyTitle> Search(long petitionId);
        void RemoveMasterPenaltyTitles(List<EditMasterPenaltyTitle> MasterPenaltyTitles);
    }
}
