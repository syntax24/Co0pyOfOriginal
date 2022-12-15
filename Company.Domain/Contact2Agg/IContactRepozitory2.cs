using _0_Framework.Domain;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Contact2;
using _0_Framework.Application;

namespace Company.Domain.Contact2Agg
{
 public interface IContactRepozitory2 : IRepository<long, EntityContact>
    {
        EditContact2 GetDetails( long id);
        List<Contact2ViewModel> PrintAll(List<long> ids);
        List<Contact2ViewModel> Search(Contact2SearchModel SearchModel);
        List<Contact2ViewModel> GetAllContact();
        OperationResult Sign(long id);
        OperationResult UnSign(long id);
    }
}
