using System.Collections.Generic;
using _0_Framework.Domain;
using Company.Domain.CrossJobGuildAgg;
using Company.Domain.EmployeeAgg;
using CompanyManagment.App.Contracts.CrossJob;

namespace Company.Domain.CrossJobAgg
{
    public interface ICrossJobRepository : IRepository<long, CrossJob>
    {
        List<CrossJobViewModel> GetCrossJob(long idGuild);
        EditCrossJob GetDetails(long id);
        List<CrossJobViewModel> Search(CrossJobSearchModel searchModel);
        void Remove(long id);
        void RemoveRange(long id);

    }
}