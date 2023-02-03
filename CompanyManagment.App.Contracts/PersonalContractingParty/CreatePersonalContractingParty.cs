using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.PersonalContractingParty
{
    public class CreatePersonalContractingParty
    {
        //public long id { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string FName { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string LName { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string Nationalcode { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [MaxLength(12)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string IdNumber { get; set; }


        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        //public string LegalName { get; set; }


        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string RegisterId { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "لطفا فقط عدد 11 رقمی وارد کنید")]
     
        public string NationalId { get; set; }

        public string IsLegal { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "لطفا شماره تلفن معتبر وارد کنید")]
        public string Phone { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string AgentPhone { get; set; }

      
        public string Address { get; set; }
    }
}
