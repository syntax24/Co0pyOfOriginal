using System.Collections.Generic;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.Subtitle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Company.Subtitle
{
  
        public class IndexModel : PageModel
        {
        public string Message { get; set; }
        public string OriginalTitleSearch = "false";
        public string SubtitleSearch = "false";
        public SubtitleSearchModel searchModel;
        public SelectList SelectListOriginalTitle;
        public List<SubtitleViewModel> Subtitles;
        public SelectList categoryListItems;

            private readonly ISubtitleApplication _subtitleApplication;
            private readonly IOriginalTitleApplication _originalTitleApplication;


        public IndexModel(ISubtitleApplication subtitleApplication, IOriginalTitleApplication originalTitleApplication)
            {
                _subtitleApplication = subtitleApplication;
                _originalTitleApplication = originalTitleApplication;
                 
            }

            public void OnGet(SubtitleSearchModel searchModel)
            {

            SelectListOriginalTitle = new SelectList(_originalTitleApplication.GetAllOriginalTitle(), "Id", "Title");
            Subtitles = _subtitleApplication.Search(searchModel);

            if (Subtitles != null)
            {
                if (searchModel.OriginalTitle_Id != 0)
                {
                    SubtitleSearch = "true";
                }

            }
        }
            public IActionResult OnGetCreate()
            {
                var allCategory = new CreateSubtitle
                {
                    OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle()
                };
                return Partial("./Create", allCategory);
            }
            public IActionResult OnPostCreate(CreateSubtitle command)
            {
                var result = _subtitleApplication.Create(command);
                return new JsonResult(result);
            }

            public IActionResult OnGetEdit(long id)
            {
                var Subtitle = _subtitleApplication.GetDetails(id);
                var SubtitleEdit = new EditSubtitle
                {
                    Id = id,
                    Subtitle = Subtitle.Subtitle,
                    OriginalTitle_Id = Subtitle.OriginalTitle_Id,
                    OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle()

                };
                return Partial("Edit", SubtitleEdit);
            }
            public JsonResult OnPostEdit(EditSubtitle command)
            {
                var result = _subtitleApplication.Edit(command);
                return new JsonResult(result);
            }
        public JsonResult OnPostDelete(EditSubtitle command)
        {
            var result = _subtitleApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDetails(long id)
            {
                var editJob = _subtitleApplication.GetDetails(id);
                return Partial("Details", editJob);
            }



        public IActionResult OnGetGroupDeActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _subtitleApplication.DeActive(item);
            }
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetGroupReActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _subtitleApplication.Active(item);
            }
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDeActive(long id, string url)
        {
            var result = _subtitleApplication.DeActive(id);
            if (result.IsSuccedded)
                 return new JsonResult(url);
            Message = result.Message;
            return RedirectToPage(url);
        }
        public IActionResult OnGetIsActive(long id, string url)
        {
            var result = _subtitleApplication.Active(id);
            if (result.IsSuccedded)
                 return new JsonResult(url);
            Message = result.Message;
            return RedirectToPage(url);
        }
    }


}
