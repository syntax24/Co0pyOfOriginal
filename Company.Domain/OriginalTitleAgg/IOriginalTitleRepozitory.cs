using _0_Framework.Domain;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.OriginalTitle;


namespace Company.Domain.OriginalTitleAgg
{
    public interface IOriginalTitleRepozitory : IRepository<long, EntityOriginalTitle>
    {
        EditOriginalTitle GetDetails(long id);
        List<OriginalTitleViewModel> Search(OriginalTitleSearchModel SearchModel);
        List<OriginalTitleViewModel> GetAllOriginalTitle();
    }
}
