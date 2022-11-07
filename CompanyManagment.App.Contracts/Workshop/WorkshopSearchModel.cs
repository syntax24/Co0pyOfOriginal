using System.Collections.Generic;
using CompanyManagment.App.Contracts.Employer;

namespace CompanyManagment.App.Contracts.Workshop
{
    public class WorkshopSearchModel
    {
        public string WorkshopName { get; set; }

        public string WorkshopSureName { get; set; }
        public string WorkshopFullName { get; set; }
        public string InsuranceCode { get; set; }

        public string ArchiveCode { get; set; }

        //public long EmployerId { get; set; }

        public string IsActiveString { get; set; }

        public string TypeOfInsuranceSend { get; set; }

        public string TypeOfContract { get; set; }
        public string ContractTerm { get; set; }
        public long EmployerId { get; set; }
        public List<EmployerViewModel> Employers { get; set; }
        
    }
}