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
                IsActiveString = x.IsActiveString,
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

      

        List<ModuleViewModel> IModuleRepozitory.Search(ModuleSearchModel searchModel)
        {
            var query = _context.EntityModules.Select(x => new ModuleViewModel
            {
                Id = x.id,
                NameSubModule = x.NameSubModule,
                IsActiveString = x.IsActiveString,
            });
            if (!string.IsNullOrWhiteSpace(searchModel.NameSubModule))
                query = query.Where(x => x.NameSubModule.Contains(searchModel.NameSubModule));
            if (string.IsNullOrWhiteSpace(searchModel.IsActiveString) || searchModel.IsActiveString == null || searchModel.IsActiveString == "null")
                query = query.Where(x => x.IsActiveString == "true");
            if (searchModel.IsActiveString == "false")
                query = query.Where(x => x.IsActiveString == "false");
            if (searchModel.IsActiveString == "true")
                query = query.Where(x => x.IsActiveString == "true");
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
