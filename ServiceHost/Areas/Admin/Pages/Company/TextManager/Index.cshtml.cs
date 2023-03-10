using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P_TextManager.Domin.TextManagerAgg;
using _0_Framework.Application;
using CompanyManagment.App.Contracts.Module;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.Subtitle;
using CompanyManagment.App.Contracts.TextManager;
using CompanyManagment.App.Contracts.Chapter;

namespace ServiceHost.Areas.Admin.Pages.Company.TextManager
{
    public class IndexModel : PageModel
    {
        public string TextManagerSearch = "false";
        public string Message { get; set; }
        public TextManagerViewModel searchModel;
        public List<SubtitleViewModel> SubtitlesViewModels;
        public List<TextManagerViewModel> TextManagers;
        public SelectList SelectListOriginalTitle;
        public SelectList SelectListSubtitle;
        public SelectList SelectListChapter;
        public SelectList SelectListActiveString;
        public string[] ListModule;
        public List<OriginalTitleViewModel> OriginalTitleViewModels;
        public SelectList categoryListItems;
        private readonly ISubtitleApplication _subtitleApplication;
        private readonly IChapterApplication _chapterApplication;
        private readonly IOriginalTitleApplication _originalTitleApplication;
        private readonly ITextManagerApplication _textManagerApplication;
        private readonly IModuleApplication _moduleApplication;
        private readonly ITextManagerRepozitory _textManagerRepozitory;
        public IndexModel(ISubtitleApplication subtitleApplication, IChapterApplication chapterApplication, IOriginalTitleApplication originalTitleApplication, ITextManagerApplication textManagerApplication, IModuleApplication moduleApplication, ITextManagerRepozitory textManagerRepozitory)
        {
            _textManagerRepozitory = textManagerRepozitory;
            _subtitleApplication = subtitleApplication;
            _chapterApplication = chapterApplication;
            _originalTitleApplication = originalTitleApplication;
            _textManagerApplication = textManagerApplication;
            _moduleApplication = moduleApplication;
        }
       
        public void OnGet(TextManagerSearchModel searchModel)
        {

           TextManagers = _textManagerApplication.Search(searchModel);
            SelectListOriginalTitle = new SelectList(_originalTitleApplication.GetAllOriginalTitle().Where(x=>x.IsActiveString=="true"), "Id", "Title");
            SelectListSubtitle = new SelectList(_subtitleApplication.GetAllSubtitle().Where(x => x.IsActiveString == "true"), "Id", "Subtitle");
            SelectListChapter = new SelectList(_chapterApplication.GetAllChapter().Where(x => x.IsActiveString == "true"), "Id", "Chapter");
            ListModule = _moduleApplication.GetAllModule().Where(x => x.IsActiveString == "true").Select(x => x.NameSubModule).ToArray();

            if (TextManagers != null)
            {
               
                if (searchModel.OriginalTitle_Id != 0)
                {
                    TextManagerSearch = "true";
                }

            }
        }
        public IActionResult OnGetCreate()
        {
            var createTextManager = new CreateTextManager
            {
                OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList(),
                SubtitleViewModels = _subtitleApplication.GetAllSubtitle().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.Subtitle, Value = x.Id.ToString() }).ToList(),
                ChapterViewModels = _chapterApplication.GetAllChapter().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.Chapter, Value = x.Id.ToString() }).ToList(),
                drpModule = _moduleApplication.GetAllModule().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.NameSubModule, Value = x.Id.ToString() }).ToList()
            };
            return Partial("./Create", createTextManager);
        }
        public IActionResult OnPostCreate(CreateTextManager command)
        {
            var result = _textManagerApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var textManager = _textManagerApplication.GetDetails(id);
            List<long> ModuleIds = _textManagerRepozitory.GetRelation(id);

            var textManagereEdit = new EditTextManager
            {
                Id = id,
                NoteNumber = textManager.NoteNumber,
                DateTextManager = textManager.DateTextManager,
                Description = textManager.Description,
                NumberTextManager = textManager.NumberTextManager,
                SubjectTextManager = textManager.SubjectTextManager,
                Paragraph = textManager.Paragraph,
                OriginalTitle_Id = textManager.OriginalTitle_Id,
                Subtitle_Id = textManager.Subtitle_Id,
                Chapter_Id = textManager.Chapter_Id,
                ModuleIds = ModuleIds.ToArray(),
                OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList(),
                SubtitleViewModels = _subtitleApplication.GetAllSubtitle().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.Subtitle, Value = x.Id.ToString() }).ToList(),
                ChapterViewModels = _chapterApplication.GetAllChapter().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.Chapter, Value = x.Id.ToString() }).ToList(),
                drpModule = _moduleApplication.GetAllModule().Where(x => x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.NameSubModule, Value = x.Id.ToString() }).ToList()
            };
            return Partial("Edit", textManagereEdit);
        }
        public JsonResult OnPostEdit(EditTextManager command)
        {
            var result = _textManagerApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetDetails(long id)
        {
            var editJob = _textManagerApplication.GetDetails(id);
            return Partial("Details", editJob);
        }
        public IActionResult OnGetSubtitleList(long OriginalTitle_Id)
        {
            var subtitleList = _subtitleApplication.GetAllSubtitle().Where(d => d.OriginalTitle_Id == OriginalTitle_Id && d.IsActiveString == "true").ToList();
            return new JsonResult(subtitleList);
        }
        public IActionResult OnGetChptereList(long Subtitle_Id)
        {
            var chapterleList = _chapterApplication.GetAllChapter().Where(x => x.Subtitle_Id == Subtitle_Id && x.IsActiveString == "true").ToList().Select(x => new SelectListItem { Text = x.Chapter, Value = x.Id.ToString() }).ToList();
            return new JsonResult(chapterleList);
        }

        public IActionResult OnGetDescription(long subtitle_Id)
        {
            var descriptions = _textManagerApplication.GetAllTextManager().Where(d => d.Subtitle_Id == subtitle_Id).Select(x => x.Description).ToList();
            return new JsonResult(descriptions);
        }
        public IActionResult OnGetDescriptionAll(string term, int Id)
        {
            if (Id == 0)
                return new JsonResult(_textManagerApplication.GetAllTextManager().Where(d => d.Description.Contains(term) && d.IsActiveString == "true").Select(x => x.Description).ToList());
            else
                return new JsonResult(_textManagerApplication.GetAllTextManager().Where(d => d.Description.Contains(term) && d.Chapter_Id == Id && d.IsActiveString == "true").Select(x => x.Description).ToList());
        }

        public IActionResult OnGetSearchText1(string term)
        {
            try
            {
                //string term = HttpContext.Request.Query["term"].ToString();
                List<Parvandeh> ObjList = new List<Parvandeh>()
                {

                    new Parvandeh {Id=1,Name="Latur" },
                    new Parvandeh {Id=2,Name="Mumbai" },
                    new Parvandeh {Id=3,Name="Pune" },
                    new Parvandeh {Id=4,Name="Delhi" },
                    new Parvandeh {Id=5,Name="Dehradun" },
                    new Parvandeh {Id=6,Name="Noida" },
                    new Parvandeh {Id=7,Name="New Delhi" }

                };
                //Searching records from list using LINQ query  
                //var Name = (from N in ObjList
                //            where N.Name.StartsWith(term)
                //            select new { N.Name });
                var Name = (from N in ObjList
                            where N.Name.Contains(term)
                            select new { N.Name }).ToList();
                return new JsonResult(Name);

            }
            catch
            {
                return BadRequest();
            }
        }
     
        public IActionResult OnGetDeActive(long id,string url)
        {
            var result = _textManagerApplication.DeActive(id);

            if (result.IsSuccedded)
                    return new JsonResult(url);
                  Message = result.Message;
            return RedirectToPage(url);
          
        }
        public IActionResult OnGetIsActive(long id, string url)
        {


            var result = _textManagerApplication.Active(id);
            if (result.IsSuccedded)
                 return new JsonResult(url);
            Message = result.Message;
            return RedirectToPage(url);
        }


        public IActionResult OnGetGroupDeActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _textManagerApplication.DeActive(item);
            }
            return RedirectToPage("./Index");

        }


        public IActionResult OnGetGroupReActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _textManagerApplication.Active(item);
            }


            //if (result.IsSuccedded)
            //    return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetGroupSelectModule(List<long> ids, string module, int AD)
        {
            long moduleId = _moduleApplication.GetAllModule().Where(x => x.NameSubModule == module).Select(x => x.Id).FirstOrDefault();
            foreach (var item in ids)
            {
                var result = _textManagerApplication.SelectModule(item, moduleId, AD);

            }
            return RedirectToPage("./Index");

        }
        private class Parvandeh
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
