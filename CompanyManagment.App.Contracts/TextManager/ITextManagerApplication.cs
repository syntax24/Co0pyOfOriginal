using _0_Framework.Application;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.TextManager
{
    public interface ITextManagerApplication
    {
        OperationResult Create(CreateTextManager command);
        OperationResult Edit(EditTextManager command);
        EditTextManager GetDetails( long id);
        List<TextManagerViewModel> Search(TextManagerSearchModel SearchModel);
        List<TextManagerViewModel> GetAllTextManager();
        List<TextManagerViewModel> PrintAll(List<long> ids);

        OperationResult Active(long id);
        OperationResult DeActive(long id);
         OperationResult SelectModule(long id, long moduleId,int ad);
    }
}
