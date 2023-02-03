
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.Subtitle;


namespace CompanyManagment.App.Contracts.OriginalTitle
{
   public class CreateOriginalTitle
    {
        [Required(ErrorMessage =" عنوان نباید خالی باشد")]
        public string Title { get;  set; }
          public List<SubtitleViewModel> SubtitleViewModels { get; set; }
    }
    
}
