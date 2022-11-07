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
   
    }
}
