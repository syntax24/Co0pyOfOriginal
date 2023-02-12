using System.Collections.Generic;
using _0_Framework.Domain;
using Company.Domain.CrossJobGuildAgg;
using Company.Domain.EmployeeAgg;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobItems;

namespace Company.Domain.CrossJobItemsAgg
{
    public interface ICrossJobItemsRepository : IRepository<long, CrossJobItems>
    {
        List<CrossJobItemsViewModel> GetCrossJobItems(long idGuild);
        CrossJobItemsViewModel GetDetails(long id);
        List<CrossJobItemsViewModel> Search(CrossJobItemsSearchModel searchModel);
        void Remove(long id);
        void RemoveRange(long idcrossJob);

    }
}