using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.YearlySalaryItems;

namespace CompanyManagment.App.Contracts.YearlySalary
{
    public class CreateYearlySalary
    {
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]

        ////[RegularExpression(@"^\(?([0-9]{4})\)?[/ ]?([0-9]{2})[/ ]?([0-9]{2})$", ErrorMessage = "لطفا فرمت تاریخ را صحیح وارد کنید مثال 1400/01/01")]
        //[RegularExpression("[0-9]{4}[/][0-9]{2}[/][0-9]{2}", ErrorMessage = "لطفا فقط عدد 8 رقمی وارد کنید")]
        public string StartDate { get; set; }


        //[RegularExpression(@"^\(?([0-9]{4})\)?[/ ]?([0-9]{2})[/ ]?([0-9]{2})$", ErrorMessage = "لطفا فرمت تاریخ را صحیح وارد کنید مثال 1400/01/01")]
        //[RegularExpression("[0-9]{4}[/][0-9]{2}[/][0-9]{2}", ErrorMessage = "لطفا فقط عدد 8 رقمی وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string EndDate { get; set; }

        public int ConnectionId { get; set; }

        public List<CreateYearlySalaryItem> CreateYearlyItemsList { get; set; }
        public List<CreateYearlySalaryItem> CreateYearlyItemsList2 { get; set; }
        public List<string> TitleViewModels { get; set; }
        public List<YearlysalaryItemViewModel> EditYearlyItemsList { get; set; }

        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        //public string DailyWages { get; set; }

        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        //public string CommodityAllowance { get; set; }

        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        //public string HousingAllowance { get; set; }

        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        //public string BasicSalary { get; set; }

        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        //public string FixedWages { get; set; }

        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        //[RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        //public double SalaryPercentage { get; set; }
    }
}
