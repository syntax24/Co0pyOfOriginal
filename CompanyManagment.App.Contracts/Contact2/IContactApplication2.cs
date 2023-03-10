using _0_Framework.Application;
using System.Collections.Generic;



namespace CompanyManagment.App.Contracts.Contact2
{
    public interface IContactApplication2
    {
        OperationResult Create(CreateContact2 command);
        OperationResult Edit(EditContact2 command);
        EditContact2 GetDetails( long id);
        List<Contact2ViewModel> Search(Contact2SearchModel SearchModel);
        List<Contact2ViewModel> GetAllContact();
        List<Contact2ViewModel> PrintAll(List<long> ids);

        OperationResult Active(long id);
        OperationResult DeActive(long id);
        OperationResult Sign(long id);
        OperationResult UnSign(long id);
        
   
    }
}
