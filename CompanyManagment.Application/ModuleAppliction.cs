using _0_Framework.Application;
using System.Collections.Generic;
using Company.Domain.ModuleAgg;
using CompanyManagment.App.Contracts.Module;

namespace CompanyManagment.Application
{
    public class ModuleAppliction : IModuleApplication
    {
        private readonly IModuleRepozitory _ModuleRepozitory;

        public ModuleAppliction(IModuleRepozitory ModuleRepozitory)
        {
            _ModuleRepozitory = ModuleRepozitory;
        }
        public OperationResult Create(CreateModule command)
        {
            var oprtaion = new OperationResult();
            if (_ModuleRepozitory.Exists(x => x.NameSubModule == command.NameSubModule))
                oprtaion.Failed("عنوان تکراری است");
            var Module = new EntityModule(command.NameSubModule);

            _ModuleRepozitory.Create(Module);
            _ModuleRepozitory.SaveChanges();
            return oprtaion.Succcedded();
        }
        public OperationResult Edit(EditModule command)
        {
            var oprtaion = new OperationResult();

            var ModuleEdit = _ModuleRepozitory.Get(command.Id);

            if (_ModuleRepozitory.Exists(x => x.NameSubModule == command.NameSubModule && x.id != command.Id))
                return oprtaion.Failed("  این نام ماژول قبلا ثبت شده است");
            if (string.IsNullOrWhiteSpace(command.NameSubModule))
                return oprtaion.Failed("ثبت  ماژول الزامیست");
         

            ModuleEdit.Edit(command.NameSubModule); ;
            _ModuleRepozitory.SaveChanges();
            return oprtaion.Succcedded();
        }

        public List<ModuleViewModel> GetAllModule()
        {
            return _ModuleRepozitory.GetAllModule();
        }

        public EditModule GetDetails(long id)
        {
            return _ModuleRepozitory.GetDetails(id);
        }

        public List<ModuleViewModel> Search(ModuleSearchModel SearchModel)
        {
            return _ModuleRepozitory.Search(SearchModel);
        }

        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var module = _ModuleRepozitory.Get(id);
            if (module == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");
             module.Active();
            _ModuleRepozitory.SaveChanges();
            return opration.Succcedded();
        }
        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var module = _ModuleRepozitory.Get(id);
            if (module == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");
            module.DeActive();
            _ModuleRepozitory.SaveChanges();
            return opration.Succcedded();
        }
    }
}
