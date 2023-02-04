using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.CrossJobGuild;

namespace Company.Domain.CrossJobGuildAgg
{
    public interface ICrossJobGuildRepository : IRepository<long, CrossJobGuild>
    {
        List<CrossJobGuildViewModel> GetCrossJobGuild();
        EditCrossJobGuild GetDetails(long id);
        List<CrossJobGuildViewModel> Search(CrossJobGuildSearchModel searchModel);
        void Remove(long id);

    }
}