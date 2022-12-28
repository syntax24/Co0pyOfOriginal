using System;
using System.Collections.Generic;
using System.Linq;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Workshop;

namespace CompanyManagment.App.Contracts.Contract
{
    public class ContractViweModel
    {
        public long Id { get; set; }
        public long PersonnelCode { get; set; }
        public long EmployeeId { get; set; }
        public long EmployerId { get; set; }
        public long WorkshopIds { get; set; }
        public long YearlySalaryId { get; set; }
        public string ContarctStart { get; set; }
        public string ContractEnd { get; set; }
        public DateTime ContractStartGr { get; set; }
        public DateTime ContractEndGr { get; set; }
        public string DayliWage { get; set; }
        public string ContractNo { get; set; }
        public string IsActiveString { get; set; }
        public string ArchiveCode { get; set; }
        public string WorkshopAddress1 { get; set; }
        public string WorkshopAddress2 { get; set; }
        public string ContractType { get; set; }
        public string JobType { get; set; }
        public string GetWorkDate { get; set; }
        public string SetContractDate { get; set; }
        public string ConsumableItems { get; set; }
        public long JobTypeId { get; set; }
        public string HousingAllowance { get; set; }
        public string AgreementSalary { get; set; }
        public string WorkingHoursWeekly { get; set; }
        public string FamilyAllowance { get; set; }
        public string GetWork { get; set; }
        public string ContractPeriod { get; set; }
         

        public string Year { get; set; }
        public string Month { get; set; }
        public string Signature { get; set; }

        public bool Extension { get; set; }
        public bool RedColor { get; set; }
        public bool Waiting { get; set; }
        public bool MoreThanOneMonth { get; set; }
        public bool LaterThanEnd { get; set; }
        public bool CheckNext { get; set; }
        public string ConvertYear { get; set; }
        public string ConvertMonth { get; set; }

        public string EmployerName { get; set; }
        public string EmployeeName { get; set; }
        public string WorkshopName { get; set; }

        public string NextMonthStart { get; set; }
        public string NextMonthEnd { get; set; }
        public IQueryable<WorkshopEmployerViewModel> WorkshopEmployerList { get; set; }
        public List<EmployerViewModel> Employers { get; set; }
        public List<WorkshopViewModel> Workshops { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

    }
}