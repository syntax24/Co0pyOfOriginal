using System.Collections.Generic;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.App.Contracts.YearlySalary;

namespace CompanyManagment.App.Contracts.Contract
{
    public class ExtensionViewModel
    {
        public long Id { get; set; }

        public long EmployeeId { get; set; }

        public long WorkshopIds { get; set; }

        public string ContarctStart { get; set; }
        public string ContractEnd { get; set; }



        public string Year { get; set; }
        public string Month { get; set; }
        public string Signature { get; set; }

        public bool Extension { get; set; }
        public bool RedColor { get; set; }
        public bool Waiting { get; set; }
        public bool MoreThanOneMonth { get; set; }
        public string ConvertYear { get; set; }
        public string ConvertMonth { get; set; }
        public bool LaterThanEnd { get; set; }

        public bool CheckNext { get; set; }
        public string FormStep { get; set; }

        public string EmployerName { get; set; }
        public string EmployeeName { get; set; }
        public string WorkshopName { get; set; }
        public List<ContractViweModel> Contracts { get; set; }
        public List<WorkshopViewModel> Workshops { get; set; }
        public List<EmployerViewModel> Employers { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public List<YearlySalaryViewModel> YearlySalaries { get; set; }

        public List<long> ContractsId { get; set; }
    }
}
