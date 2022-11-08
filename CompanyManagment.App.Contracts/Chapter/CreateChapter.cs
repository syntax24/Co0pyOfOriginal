
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.Subtitle;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagment.App.Contracts.Chapter
{
   public class CreateChapter
    {
        [Required(ErrorMessage ="نام بخش نباید خالی باشد")]
        public string Chapter { get;  set; }
        public long Subtitle_Id { get;  set; }
        public long OriginalTitle_Id{ get; set; }
        public List<SelectListItem> OriginalTitleViewModels { get; set; }
        public List<SelectListItem> SubtitleViewModels { get; set; }
    }
    
}
