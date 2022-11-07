using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.PenaltyTitle;


namespace Company.Domain.PenaltyTitle
{
    public interface IPenaltyTitleRepository : IRepository<long, PenaltyTitle>
    {
        List<EditPenaltyTitle> Search(long petitionId);
        void RemovePenaltyTitles(List<EditPenaltyTitle> penaltyTitles);
    }
}
