using System.Collections.Generic;
using System.Linq;
using CompanyManagment.App.Contracts.Chapter;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.Subtitle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Company.Chapter
{

    public class IndexModel : PageModel
    {
        public string ChapterSearch = "false";
        public string Message { get; set; }
        public ChapterSearchModel searchModel;
        public SelectList SelectListOriginalTitle;

        public SelectList SelectListSubtitles;

        public List<ChapterViewModel> Chapters;
        public SelectList categoryListItems;

        private readonly ISubtitleApplication _subtitleApplication;
        private readonly IOriginalTitleApplication _originalTitleApplication;
        private readonly IChapterApplication _chapterApplication;

        public IndexModel(IChapterApplication chapterApplication, ISubtitleApplication subtitleApplication, IOriginalTitleApplication originalTitleApplication)
        {
            _subtitleApplication = subtitleApplication;
            _originalTitleApplication = originalTitleApplication;

            _chapterApplication = chapterApplication;
        }

        public void OnGet(ChapterSearchModel searchModel)
        {
            Chapters = _chapterApplication.Search(searchModel);
            SelectListOriginalTitle = new SelectList(_originalTitleApplication.GetAllOriginalTitle(), "Id", "Title");
            SelectListSubtitles = new SelectList(_subtitleApplication.GetAllSubtitle(), "Id", "Subtitle");

            if (Chapters != null)
            {
                if (searchModel.Subtitle_Id != 0)
                {
                    ChapterSearch = "true";
                }

            }


        }
        public IActionResult OnGetCreate()
        {
            var allCategory = new CreateChapter
            {
                OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle().ToList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList(),
                SubtitleViewModels = _subtitleApplication.GetAllSubtitle().ToList().Select(x => new SelectListItem { Text = x.Subtitle, Value = x.Id.ToString() }).ToList()
            };
            return Partial("./Create", allCategory);
        }
        public IActionResult OnPostCreate(CreateChapter command)
        {
            var result = _chapterApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Chapter = _chapterApplication.GetDetails(id);
            var ChapterEdit = new EditChapter
            {
                Id = id,

                Chapter = Chapter.Chapter,
                Subtitle_Id = Chapter.Subtitle_Id,
                OriginalTitle_Id = _subtitleApplication.GetAllSubtitle().ToList().Where(s => s.Id == Chapter.Subtitle_Id).SingleOrDefault().OriginalTitle_Id,
                OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle().ToList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList(),
                SubtitleViewModels = _subtitleApplication.GetAllSubtitle().ToList().Select(x => new SelectListItem { Text = x.Subtitle, Value = x.Id.ToString() }).ToList()

            };
            return Partial("Edit", ChapterEdit);
        }
        public JsonResult OnPostEdit(EditChapter command)
        {
            var result = _chapterApplication.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnPostDelete(EditChapter command)
        {
            var result = _chapterApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDetails(long id)
        {
            var editchapter = _chapterApplication.GetDetails(id);
            return Partial("Details", editchapter);
        }
        public IActionResult OnGetGroupDeActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _chapterApplication.DeActive(item);
            }
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetGroupReActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _chapterApplication.Active(item);
            }
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDeActive(long id, string url)
        {
            var result = _chapterApplication.DeActive(id);
            if (result.IsSuccedded)
                 return new JsonResult(url);
            Message = result.Message;
            return RedirectToPage(url);
        }
        public IActionResult OnGetIsActive(long id, string url)
        {
            var result = _chapterApplication.Active(id);
            if (result.IsSuccedded)
                 return new JsonResult(url);
            Message = result.Message;
            return RedirectToPage(url);
        }
    }


}
