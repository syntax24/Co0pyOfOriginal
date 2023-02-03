using _0_Framework.Domain;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Module;


namespace Company.Domain.ModuleAgg
{
 public interface IModuleRepozitory : IRepository<long, EntityModule>
    {
        EditModule GetDetails( long id);
        List<ModuleViewModel> Search(ModuleSearchModel SearchModel);
        List<ModuleViewModel> GetAllModule();
    }
}
