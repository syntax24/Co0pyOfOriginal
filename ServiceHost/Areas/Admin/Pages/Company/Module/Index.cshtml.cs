using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagment.App.Contracts.Module;
using CompanyManagment.EFCore;



namespace ServiceHost.Areas.Admin.Pages.Company.Module
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public string ModulesSearch = "false";
        public ModuleViewModel searchModel;
        public List<ModuleViewModel> Modules;
        private CompanyContext db;

        private readonly IModuleApplication _ModuleApplication;

        public IndexModel(IModuleApplication ModuleApplication)
        {
            _ModuleApplication = ModuleApplication;
         
        }
        public void OnGet(ModuleSearchModel searchModel)
        {
            Modules = _ModuleApplication.Search(searchModel);
            if (Modules != null)
            {

                    ModulesSearch = "true";

            }

        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
       public IActionResult OnPostCreate(CreateModule command)
        {
            var result = _ModuleApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var Module = _ModuleApplication.GetDetails(id);
            return Partial("Edit", Module);
        }
        public JsonResult OnPostEdit(EditModule command)
        {
            var result = _ModuleApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetDetails(long id)
        {
            var editJob = _ModuleApplication.GetDetails(id);
            return Partial("Details", editJob);
        }

        public IActionResult OnGetSearch(string term)
        {
            var names = db.EntityModules.Where(p => p.NameSubModule.Contains(term)).Select(p => p.NameSubModule).ToList();
            return new JsonResult(names);
        }

        public IActionResult OnGetGroupDeActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _ModuleApplication.DeActive(item);
            }
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetGroupReActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _ModuleApplication.Active(item);
            }
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDeActive(long id)
        {


            var result = _ModuleApplication.DeActive(id);

            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetIsActive(long id)
        {


            var result = _ModuleApplication.Active(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }



    }
}
