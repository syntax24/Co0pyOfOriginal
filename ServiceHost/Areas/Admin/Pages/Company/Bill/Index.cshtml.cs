using System.Collections.Generic;
using CompanyManagment.App.Contracts.Bill;
using CompanyManagment.App.Contracts.Contact2;
using CompanyManagment.App.Contracts.TextManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Company.Bill
{
    public class IndexModel : PageModel
    {
        public string BillSearch = "false";
        public BillSearchModel searchModel;
        public List<BillViewModel> Bills;
        private readonly IBillApplication _billApplication;
        private readonly IContactApplication2 _contactApplication;
        public string Message { get; set; }
        public IndexModel(IBillApplication billApplication, IContactApplication2 contactApplication)
        {
            _billApplication = billApplication;
            _contactApplication = contactApplication;
        }
        public void OnGet(BillSearchModel searchModel)
        {
            Bills = _billApplication.Search(searchModel);

            if (Bills != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Appointed))
                {
                    BillSearch = "true";
                }
            }
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public IActionResult OnPostCreate(CreateBill command)
        {
            var result = _billApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
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
            return Partial("Edit", billEdit);
        }
        public IActionResult OnGetEditBill1(long id)
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
            return Partial("Edit", billEdit);
        }
        public JsonResult OnPostEdit(EditBill command)
        {
            var result = _billApplication.Edit(command);
            return new JsonResult(result);
        }
      
        public IActionResult OnGetDeActive(long id, string url)
        {



            var result = _billApplication.DeActive(id);

            if (result.IsSuccedded)
                 return new JsonResult(url);
            Message = result.Message;
            return RedirectToPage(url);

        }

        public IActionResult OnGetIsActive(long id, string url)
        {


            var result = _billApplication.Active(id);
            if (result.IsSuccedded)
                 return new JsonResult(url);
            Message = result.Message;
            return RedirectToPage(url);
        }



        public IActionResult OnGetGroupDeActive(List<long> ids)
        {
            foreach (var item in ids)
            {
                var result = _billApplication.DeActive(item);
            }
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetGroupReActive(List<long> ids)
        {
            foreach (var item in ids)
            {
                var result = _billApplication.Active(item);
            }
            //if (result.IsSuccedded)
            //    return RedirectToPage("./Index");
            return RedirectToPage("./Index");
        }

        //public IActionResult OnGetGroupSelectModule(List<long> ids, string module, int AD)
        //{
        //    long moduleId = _billApplication.GetAllModule().Where(x => x.NameSubModule == module).Select(x => x.Id).FirstOrDefault();
        //    foreach (var item in ids)
        //    {
        //        var result = _billApplication.SelectModule(item, moduleId, AD);

        //    }
        //    return RedirectToPage("./Index");

        //}



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

