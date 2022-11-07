using _0_Framework.Domain;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Contact2;


namespace Company.Domain.Contact2Agg
{
 public interface IContactRepozitory2 : IRepository<long, EntityContact>
    {
        EditContact2 GetDetails( long id);
        List<Contact2ViewModel> Search(Contact2SearchModel SearchModel);
        List<Contact2ViewModel> GetAllContact();
    }
}
