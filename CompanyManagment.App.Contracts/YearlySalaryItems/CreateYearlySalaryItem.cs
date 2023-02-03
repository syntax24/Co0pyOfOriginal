using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.YearlySalaryItems
{
    public class CreateYearlySalaryItem
    {
     
        public string ItemName { get; set; }
       
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double ItemValue { get; set; }

        public string ValueType { get; set; }
        public int ParentConnectionId { get; set; }
        public long YearlySalaryId { get; set; }
    
    }
}
