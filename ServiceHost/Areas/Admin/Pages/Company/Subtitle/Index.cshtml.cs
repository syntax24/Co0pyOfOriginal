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

        }

}
