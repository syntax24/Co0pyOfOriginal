using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.EmployeeChildren;

namespace CompanyManagment.App.Contracts.Employee
{
    public class CreateEmployee
    {
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string FName { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string LName { get; set; }
       
        public string FatherName { get; set; }
        public string EmployeeFullName { get; set; }
        public string DateOfBirth { get; set; }

        public string DateOfIssue { get; set; }

        public string PlaceOfIssue { get; set; }
        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string NationalCode { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string IdNumber { get; set; }

        //[Required(ErrorMessage = "لطفا جنسیت را تعیین نمایید")]
        public string Gender { get; set; }

        public string Nationality { get; set; }

       
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0][9][0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "لطفا شماره موبایل معتبر وارد کنید")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        //[Required(ErrorMessage = "لطفا وضعیت تاهل را تعیین نمایید")]
        public string MaritalStatus { get; set; }
        public string MilitaryService { get; set; }
        public string LevelOfEducation { get; set; }
        public string FieldOfStudy { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "لطفا شماره کارت معتبر 12 رقمی وارد کنید")]
        public string BankCardNumber { get; set; }
        public string BankBranch { get; set; }

      
        [RegularExpression("[0-9]{8}", ErrorMessage = "لطفا فقط عدد 8 رقمی وارد کنید")]
        public string InsuranceCode { get; set; }



        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]

        public string InsuranceHistoryByYear { get; set; }

        [Range(1, 11, ErrorMessage = "لطفا فقط عددی مابین 1 تا 11 وارد کنید")]

        public string InsuranceHistoryByMonth { get; set; }
        public string NumberOfChildren { get; set; }

        [RegularExpression("^[0][0-9]*$", ErrorMessage = "لطفا فقط شماره تلفن معتبر وارد کنید")]
        public string OfficePhone { get; set; }
        public string MclsUserName { get; set; }

        public string MclsPassword { get; set; }

        public string EserviceUserName { get; set; }

        public string EservicePassword { get; set; }

        public string TaxOfficeUserName { get; set; }

        public string TaxOfficepassword { get; set; }

        public string SanaUserName { get; set; }
        public string SanaPassword { get; set; }
        public List<EmployeeChildernViewModel> CreateEmployeChildrenList { get; set; }
        public List<EmployeeChildernViewModel> EditEmployeChildrenList { get; set; }

    }
}
