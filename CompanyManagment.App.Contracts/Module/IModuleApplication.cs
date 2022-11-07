using _0_Framework.Application;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Module
{
    public interface IModuleApplication
    {
        OperationResult Create(CreateModule command);
        OperationResult Edit(EditModule command);
        EditModule GetDetails( long id);
        List<ModuleViewModel> Search(ModuleSearchModel SearchModel);
        List<ModuleViewModel> GetAllModule();

       
    }
}
