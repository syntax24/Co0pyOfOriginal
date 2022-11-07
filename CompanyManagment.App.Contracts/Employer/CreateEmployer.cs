using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.PersonalContractingParty;

namespace CompanyManagment.App.Contracts.Employer
{
    public class CreateEmployer
    {
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string FName { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string LName { get; set; }
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا طرف حساب این کارفرما را انتخاب کنید")]
        public long ContractingPartyId { get;  set; }

        [Required(ErrorMessage = "لطفا جنسیت را تعیین نمایید")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string Nationalcode { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [MaxLength(12)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string IdNumber { get; set; }

        public string Nationality { get; set; }

        public string FatherName { get; set; }

     
        public string DateOfBirth { get; set; }

        
        public string DateOfIssue { get; set; }

        public string PlaceOfIssue { get; set; }


        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string RegisterId { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "لطفا فقط عدد 11 رقمی وارد کنید")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string EmployerLName { get; set; }

        public string IsLegal { get; set; }


        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string Phone { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string AgentPhone { get; set; }
            
        public string Address { get; set; }

        public string MclsUserName { get; set; }

        public string MclsPassword { get; set; }

        public string EserviceUserName { get; set; }

        public string EservicePassword { get; set; }

        public string TaxOfficeUserName { get; set; }

        public string TaxOfficepassword { get; set; }

        public string SanaUserName { get; set; }
        public string SanaPassword { get; set; }
        public string EmployerNo { get; set; }

        public List<PersonalContractingPartyViewModel> ContractingParties { get; set; }
    }

    
}
