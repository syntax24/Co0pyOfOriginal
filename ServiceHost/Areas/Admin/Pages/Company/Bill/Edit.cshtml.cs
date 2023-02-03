
using System.Collections.Generic;
using System.Linq;
using CompanyManagment.App.Contracts.Bill;
using CompanyManagment.App.Contracts.Contact2;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.Subtitle;
using CompanyManagment.App.Contracts.TextManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ServiceHost.Areas.Admin.Pages.Company.Bill
{
  
    public class EditModel : PageModel
    {
        public List<BillViewModel> Bills;
        private readonly IBillApplication _billApplication;
        private readonly IContactApplication2 _contactApplication;
        private readonly ISubtitleApplication _subtitleApplication;
        private readonly IOriginalTitleApplication _originalTitleApplication;
        private ITextManagerApplication _textManagerApplication;

        public EditModel(IBillApplication billApplication, ITextManagerApplication textManagerApplication, ISubtitleApplication subtitleApplication, IOriginalTitleApplication originalTitleApplication, IContactApplication2 contactApplication)
        {
            _subtitleApplication = subtitleApplication;
            _originalTitleApplication = originalTitleApplication;
            _textManagerApplication = textManagerApplication;
            _billApplication = billApplication;
            _contactApplication = contactApplication;
        }
        [BindProperty]
        public EditBill EditBill { get; set; }

        public void OnGet(long id)
        {
            List<Appointed> ObjList = ListAppointed();
            List<ProcessingStage> ObjProcessingStage = ListProcessingStage();
            var bill = _billApplication.GetDetails(id);
            var billEdit = new EditBill
            {
                Id = id,
                SubjectBill = bill.SubjectBill,
                Description = bill.Description,
                Status = bill.Status,
                Appointed = bill.Appointed,
                Contact = bill.Contact,
                ProcessingStage = bill.ProcessingStage,
            };
            EditBill = billEdit;
        }
        //public JsonResult OnPostEdit(EditBill command)
        //{
        //    var result = _billApplication.Edit(command);
        //    return new JsonResult(result);
        //}
        public IActionResult OnGetSearch()
        {
            var viewSearchTextManager = new ViewSearchTextManager
            {
                SelectListOriginalTitle = _originalTitleApplication.GetAllOriginalTitle().ToList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList(),
                SelectListSubtitle = _subtitleApplication.GetAllSubtitle().ToList().Select(x => new SelectListItem { Text = x.Subtitle, Value = x.Id.ToString() }).ToList(),
            };
            return Partial("./Search", viewSearchTextManager);
        }
        public IActionResult OnPostEdit(EditBill command)
        {
            var result = _billApplication.Edit(command = EditBill);
            var ggg = new JsonResult(result);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetOriginalTitleViewModels(string q)
        {
            var query = _originalTitleApplication.GetAllOriginalTitle().Where(x => x.Title.Contains(q)).Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();

            return new JsonResult(new { items = query });
        }
        public IActionResult OnGetDescriptionTextManager(string term, string cid)
        {
            var a = HttpContext.Request.Query["originalTitle"].ToString();
            var names = _textManagerApplication.GetAllTextManager().Where(p => p.Description.Contains(term)).Select(p => p.Description).ToList();
            return new JsonResult(names);
        }
        public IActionResult OnGetDescriptionTextManager1(string term, int parentId)
        {
            var names = _textManagerApplication.GetAllTextManager().Where(p => p.Description.Contains(term)).Select(p => p.Description).ToList();
            return new JsonResult(names);
        }
        public IActionResult OnGetContact(string term)
        {
            var names = _contactApplication.GetAllContact().Where(p => p.NameContact.Contains(term)).Select(p => p.NameContact).ToList();
            return new JsonResult(names);
        }
        public IActionResult OnGetAppointed(string term)
        {
            var names = ListAppointed().Where(p => p.Name.Contains(term)).Select(p => p.Name).ToList();
            return new JsonResult(names);
        }
        public IActionResult OnGetProcessingStage(string term)
        {
            var names = ListProcessingStage().Where(p => p.Name.Contains(term)).Select(p => p.Name).ToList();
            return new JsonResult(names);
        }
        private static List<Appointed> ListAppointed()
        {
            return new List<Appointed>()
            {
                new Appointed {Id=1,Name="موکل1" },
                new Appointed {Id=2,Name="موکل2" },
                new Appointed {Id=3,Name="موکل3" },
                new Appointed {Id=4,Name="موکل4" },
                new Appointed {Id=5,Name="موکل4" },
                new Appointed {Id=6,Name="موکل5" },
                new Appointed {Id=7,Name="موکل6" }
        };
        }
        private static List<ProcessingStage> ListProcessingStage()
        {
            return new List<ProcessingStage>()
            {
                new ProcessingStage {Id=1,Name="رسیدگی1" },
                new ProcessingStage {Id=2,Name="رسیدگی2" },
                new ProcessingStage {Id=3,Name="رسیدگی3" },
                new ProcessingStage {Id=4,Name="رسیدگی4" },
                new ProcessingStage {Id=5,Name="رسیدگی4" },
                new ProcessingStage {Id=6,Name="رسیدگی5" },
                new ProcessingStage {Id=7,Name="رسیدگی6" }
        };
        }
        private class Appointed
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }
        private class ProcessingStage
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
