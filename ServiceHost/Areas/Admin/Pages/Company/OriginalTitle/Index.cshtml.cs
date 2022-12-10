using System.Collections.Generic;
using CompanyManagment.App.Contracts.OriginalTitle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Company.OriginalTitle
{
    public class IndexModel : PageModel
    {
        public string OriginalTitleSearch = "false";
        public string Message { get; set; }
        public OriginalTitleViewModel searchModel;
        public List<OriginalTitleViewModel> OriginalTitles;
          private readonly IOriginalTitleApplication _originalTitleApplication;

        public IndexModel(IOriginalTitleApplication originalTitleApplication)
        {
            _originalTitleApplication = originalTitleApplication;

        }
        public void OnGet(OriginalTitleSearchModel searchModel)
        {
            OriginalTitles = _originalTitleApplication.Search(searchModel);
            if (OriginalTitles != null)
            {
                
                    OriginalTitleSearch = "true";
                
            }

        } 
        public IActionResult OnGetCreate()
        {

            return Partial("./Create");
        }
        public IActionResult OnPostCreate(CreateOriginalTitle command)
        {
            var result = _originalTitleApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var OriginalTitle = _originalTitleApplication.GetDetails(id);


            return Partial("Edit", OriginalTitle);
        }

        public JsonResult OnPostEdit(EditOriginalTitle command)
        {
            var result = _originalTitleApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetDetails(long id)
        {
            var editJob = _originalTitleApplication.GetDetails(id);
            return Partial("Details", editJob);
        }


        public IActionResult OnGetDeActive(long id, string url)
        {
            var result = _originalTitleApplication.DeActive(id);

            if (result.IsSuccedded)
                return Redirect(url);
            Message = result.Message;
            return RedirectToPage(url);

        }
        public IActionResult OnGetIsActive(long id, string url)
        {


            var result = _originalTitleApplication.Active(id);
            if (result.IsSuccedded)
                return Redirect(url);
            Message = result.Message;
            return RedirectToPage(url);
        }

        public IActionResult OnGetGroupDeActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _originalTitleApplication.DeActive(item);
            }
            return RedirectToPage("./Index");

        }


        public IActionResult OnGetGroupReActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _originalTitleApplication.Active(item);
            }


            //if (result.IsSuccedded)
            //    return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }
    }
}
