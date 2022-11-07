using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.MandantoryHours
{
    public class CreateMandatoryHours
    {
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("[0-9]{4}", ErrorMessage = "لطفا سال را بصورت عدد 4 رقمی وارد کنید ")]
        public int Year { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Farvardin { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Ordibehesht { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Khordad { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Tir { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Mordad { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Shahrivar { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Mehr { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Aban { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Azar { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Dey { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Bahman { get; set; }
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public double Esfand { get; set; }
    }
}
