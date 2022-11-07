using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.Employer;

namespace CompanyManagment.App.Contracts.Workshop
{
    public class CreateWorkshop
    {
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string WorkshopName { get; set; }

        public string WorkshopSureName { get; set; }
        public string WorkshopFullName { get; set; }

        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string InsuranceCode { get; set; }
        //[Required(ErrorMessage = "لطفا کارفرما را انتخاب نمایید")]
        //public long EmployerId { get; set; }

        public string TypeOfOwnership { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string ArchiveCode { get; set; }

        public string AgentName { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string AgentPhone { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

       
        public string TypeOfInsuranceSend { get; set; }
        [Required(ErrorMessage = "لطفا یکی از موارد زیر را انتخاب نمایید")]
        public string TypeOfContract { get; set; }

        public string ContractTerm { get; set; }
        public List<EmployerViewModel> Employers { get; set; }
        public List<long> EmployerIdList { get; set; }

     
        public List<long> AccountIdsList { get; set; }

    }
}
