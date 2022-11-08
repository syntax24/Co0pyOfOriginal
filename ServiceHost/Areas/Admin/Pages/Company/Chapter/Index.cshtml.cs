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

            SelectListOriginalTitle = new SelectList(_originalTitleApplication.GetAllOriginalTitle(), "Id", "Title");
            SelectListSubtitles = new SelectList(_subtitleApplication.GetAllSubtitle(), "Id", "Subtitle");

            Chapters = _chapterApplication.Search(searchModel);
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
                    OriginalTitle_Id= _subtitleApplication.GetAllSubtitle().ToList().Where(s=>s.Id== Chapter.Subtitle_Id).SingleOrDefault().OriginalTitle_Id,
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

        }

}
