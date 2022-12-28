using _0_Framework.Application;
using System.Collections.Generic;


namespace CompanyManagment.App.Contracts.OriginalTitle
{
    public interface IOriginalTitleApplication
    {
        OperationResult Create(CreateOriginalTitle command);
        OperationResult Edit(EditOriginalTitle command);
        EditOriginalTitle GetDetails( long id);
        List<OriginalTitleViewModel> Search(OriginalTitleSearchModel SearchModel);
        List<OriginalTitleViewModel> GetAllOriginalTitle();
        OperationResult Active(long id);
        OperationResult DeActive(long id);
    }
}
