using _0_Framework.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.ModuleAgg;
using CompanyManagment.App.Contracts.Module;


namespace CompanyManagment.EFCore.Repository
{
    public class ModuleRepository : RepositoryBase<long, EntityModule>, IModuleRepozitory
    {
        private readonly CompanyContext _context;
        public ModuleRepository(CompanyContext context):base(context)
        {
            _context = context;
        }

    
        public List<ModuleViewModel> GetAllModule()
        {
            return _context.EntityModules.Select(x => new ModuleViewModel
            {
                Id = x.id,
                NameSubModule = x.NameSubModule,
       
            }).ToList();
        }

        public EditModule GetDetails(long id)
        {

            return _context.EntityModules.Select(x => new EditModule
            {
                   Id = x.id,
                NameSubModule = x.NameSubModule
                    
              
            }).FirstOrDefault(x => x.Id == id);
        }

      

        List<ModuleViewModel> IModuleRepozitory.Search(ModuleSearchModel SearchModel)
        {
            var query = _context.EntityModules.Select(x => new ModuleViewModel
            {
                Id = x.id,
                NameSubModule = x.NameSubModule,
         


            });
            if (!string.IsNullOrWhiteSpace(SearchModel.NameSubModule))
                query = query.Where(x => x.NameSubModule.Contains(SearchModel.NameSubModule));
     

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
