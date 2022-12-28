
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.OriginalTitle;

namespace CompanyManagment.App.Contracts.Subtitle
{
   public class CreateSubtitle
    {[Required(ErrorMessage ="نام بخش نباید خالی باشد")]
        public string Subtitle { get;  set; }
        public long OriginalTitle_Id { get;  set; }
        public List<OriginalTitleViewModel> OriginalTitleViewModels { get; set; }
    }
    
}
