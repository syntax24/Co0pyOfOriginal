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

namespace ServiceHost.Areas.Admin.Pages.Company.TextManager
{
    public class IndexModel : PageModel
    {

        public TextManagerViewModel searchModel;
        public List<SubtitleViewModel> SubtitlesViewModels;
        public List<TextManagerViewModel> TextManagers;
        public SelectList SelectListOriginalTitle;
        public SelectList SelectListSubtitle;
        public string[] ListModule;
        public List<OriginalTitleViewModel> OriginalTitleViewModels;
        public SelectList categoryListItems;
        private readonly ISubtitleApplication _subtitleApplication;
        private readonly IOriginalTitleApplication _originalTitleApplication;
        private readonly ITextManagerApplication _textManagerApplication;
        private readonly IModuleApplication _moduleApplication;
        private readonly ITextManagerRepozitory _textManagerRepozitory;
        public IndexModel(ISubtitleApplication subtitleApplication, IOriginalTitleApplication originalTitleApplication, ITextManagerApplication textManagerApplication, IModuleApplication moduleApplication, ITextManagerRepozitory textManagerRepozitory)
        {
            _textManagerRepozitory = textManagerRepozitory;
            _subtitleApplication = subtitleApplication;
            _originalTitleApplication = originalTitleApplication;
            _textManagerApplication = textManagerApplication;
            _moduleApplication = moduleApplication;
        }

        public void OnGet(TextManagerSearchModel searchModel)
        {

            TextManagers = _textManagerApplication.Search(searchModel);
            SelectListOriginalTitle = new SelectList(_originalTitleApplication.GetAllOriginalTitle(), "Id", "Title");
            SelectListSubtitle = new SelectList(_subtitleApplication.GetAllSubtitle(), "Id", "Subtitle");
            ListModule = _moduleApplication.GetAllModule().Select(x => x.NameSubModule).ToArray();
        }
        public IActionResult OnGetCreate()
        {
            var createTextManager = new CreateTextManager
            {
                OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle().ToList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList(),
                SubtitleViewModels = _subtitleApplication.GetAllSubtitle().ToList().Select(x => new SelectListItem { Text = x.Subtitle, Value = x.Id.ToString() }).ToList(),
                drpModule = _moduleApplication.GetAllModule().ToList().Select(x => new SelectListItem { Text = x.NameSubModule, Value = x.Id.ToString() }).ToList()

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
                DateTextManager = Tools.ToFarsi(Convert.ToDateTime(textManager.DateTextManager)).ToString(),
                Description = textManager.Description,
                NumberTextManager = textManager.NumberTextManager,
                SubjectTextManager = textManager.SubjectTextManager,
                Paragraph = textManager.Paragraph,
                OriginalTitle_Id = textManager.OriginalTitle_Id,
                Subtitles_Id = textManager.Subtitles_Id,
                ModuleIds = ModuleIds.ToArray(),
                OriginalTitleViewModels = _originalTitleApplication.GetAllOriginalTitle().ToList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList(),
                SubtitleViewModels = _subtitleApplication.GetAllSubtitle().ToList().Select(x => new SelectListItem { Text = x.Subtitle, Value = x.Id.ToString() }).ToList(),
                drpModule = _moduleApplication.GetAllModule().ToList().Select(x => new SelectListItem { Text = x.NameSubModule, Value = x.Id.ToString() }).ToList()
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
            var subtitleList = _subtitleApplication.GetAllSubtitle().Where(d => d.OriginalTitle_Id == OriginalTitle_Id).ToList();
            return new JsonResult(subtitleList);
        }
        public IActionResult OnGetDescription(long subtitleList_Id)
        {
            var descriptions = _textManagerApplication.GetAllTextManager().Where(d => d.Subtitles_Id == subtitleList_Id).Select(x => x.Description).ToList();
            return new JsonResult(descriptions);
        }
        public IActionResult OnGetDescriptionAll(string term)
        {
            var descriptions = _textManagerApplication.GetAllTextManager().Where(d => d.Description.Contains(term)).Select(x => x.Description).ToList();
            return new JsonResult(descriptions);
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
        private class Parvandeh
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
