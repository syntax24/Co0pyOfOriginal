
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.Subtitle;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagment.App.Contracts.Bill
{
   public class CreateBill
    {
        [Required(ErrorMessage = " موضوع لایحه نباید خالی باشد")]
        public string SubjectBill { get; set; }
        [Required(ErrorMessage = " متن لایحه نباید خالی باشد")]
        public string Description { get; set; }
        [Required(ErrorMessage = " مخاطب  نباید خالی باشد")]
        public string Contact { get; set; }
        [Required(ErrorMessage = " مرحله رسیدگی نباید خالی باشد")]
        public string Appointed { get; set; }
        [Required(ErrorMessage = " موکل نباید خالی باشد")]
        public string ProcessingStage { get; set; }
        public byte Status { get; set; }

       
        public long OriginalTitle_Id { get; set; }
        public long Subtitles_Id { get; set; }
   
        public List<SubtitleViewModel> SubtitleViewModels { get; set; }
        public List<OriginalTitleViewModel> OriginalTitleViewModels { get; set; }
        public List<SelectListItem> SelectListOriginalTitle { get; set; }


        //public List<ModuleTextManagerViewModel>  ModuleTextManagerViewModels { get; set; }


    }
    
}
