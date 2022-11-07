using System.Collections.Generic;
using CompanyManagment.App.Contracts.OriginalTitle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Company.OriginalTitle
{
    public class IndexModel : PageModel
    {
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

    }
}
