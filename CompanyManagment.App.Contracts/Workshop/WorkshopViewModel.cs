using System.Collections.Generic;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;

namespace CompanyManagment.App.Contracts.Workshop
{
    public class WorkshopViewModel
    {
        public long Id { get; set; }
        public string WorkshopName { get; set; }
   
        public string WorkshopSureName { get; set; }
        public string WorkshopFullName { get; set; }
        public string InsuranceCode { get; set; }

        public string EmployerName { get; set; }

        public string TypeOfOwnership { get; set; }

        public string ArchiveCode { get; set; }

        public string AgentName { get; set; }

        public string AgentPhone { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string TypeOfInsuranceSend { get; set; }

        public string TypeOfContract { get; set; }
        public long  EmpId { get; set; }
        public string ContractTerm { get; set; }
        public string IsActiveString { get; set; }
        public List<EmployerViewModel> EmpList { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
    }
}