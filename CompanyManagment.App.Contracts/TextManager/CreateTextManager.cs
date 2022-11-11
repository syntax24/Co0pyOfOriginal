
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.ModuleTextManager;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagment.App.Contracts.TextManager
{
   public class CreateTextManager
    {
       // [Required(ErrorMessage =" عنوان نباید خالی باشد")]
        public int NoteNumber { get;  set; }
        //[Required(ErrorMessage = " موضوع نباید خالی باشد")]
        public string SubjectTextManager { get;  set; }
        public int NumberTextManager { get;  set; }
        //[Required(ErrorMessage = " تاریخ نباید خالی باشد")]

        [RegularExpression(@"^$|^([1۱][۰-۹ 0-9]{3}[/\/]([0 ۰][۱-۶ 1-6])[/\/]([0 ۰][۱-۹ 1-9]|[۱۲12][۰-۹ 0-9]|[3۳][01۰۱])|[1۱][۰-۹ 0-9]{3}[/\/]([۰0][۷-۹ 7-9]|[1۱][۰۱۲012])[/\/]([۰0][1-9 ۱-۹]|[12۱۲][0-9 ۰-۹]|(30|۳۰)))$", ErrorMessage = "تاریخ وارد شده نامعتبر است.")]
        public string DateTextManager { get;  set; }
        [Required(ErrorMessage = " نگارش متن نباید خالی باشد")]

        public string Description { get;  set; }
        //[Required(ErrorMessage = " نگارش محشا /پی نوشت نباید خالی باشد")]
        public string Paragraph { get;  set; }
        public long OriginalTitle_Id { get;  set; }
        [Required(ErrorMessage = " انتخاب بخش الزامیست")]
        public long Subtitle_Id { get;  set; }
        [Required(ErrorMessage = " انتخاب فصل الزامیست")]
        public long Chapter_Id { get; set; }
       

        [Required(ErrorMessage = " انتخاب حداقل یک ماژول الزامیست")]
        public long[] ModuleIds { get; set; }
        public List<SelectListItem> drpModule { get; set; }
        public List<SelectListItem> OriginalTitleViewModels { get; set; }
        public List<SelectListItem> SubtitleViewModels { get; set; }
        public List<SelectListItem> ChapterViewModels { get; set; }
        public List<ModuleTextManagerViewModel>  ModuleTextManagerViewModels { get; set; }
      

    }
    
}
