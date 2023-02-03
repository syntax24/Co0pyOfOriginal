#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Domain;
using Company.Domain.EmployeeAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.JobAgg;
using Company.Domain.WorkingHoursAgg;
using Company.Domain.WorkshopAgg;
using Company.Domain.YearlySalaryAgg;

namespace Company.Domain.ContractAgg
{
    public class Contract : EntityBase
    {
        public Contract(long personnelCode, long employeeId, long employerId, 
            long workshopIds, long yearlySalaryId, DateTime contarctStart, DateTime contractEnd, string dayliWage,
            string archiveCode, DateTime getWorkDate, DateTime setContractDate, string jobType,
            string contractType, string workshopAddress1, string workshopAddress2, string consumableItems, long jobTypeId, string housingAllowance, string agreementSalary, string workingHoursWeekly, string familyAllowance, string contractPeriod)
        {
            PersonnelCode = personnelCode;
            EmployeeId = employeeId;
            EmployerId = employerId;
            WorkshopIds = workshopIds;
            YearlySalaryId = yearlySalaryId;
            ContarctStart = contarctStart;
            ContractEnd = contractEnd;
            DayliWage = dayliWage;
            IsActiveString = "true";
            var month = contarctStart.ToFarsiMonth();
            var year = contarctStart.ToFarsiYear();
            var sumYear = year.Substring(Math.Max(0, year.Length - 2));
            ArchiveCode = archiveCode;
            GetWorkDate = getWorkDate;
            SetContractDate = setContractDate;
            JobType = jobType;
            ContractType = contractType;
            WorkshopAddress1 = workshopAddress1;
            WorkshopAddress2 = workshopAddress2;
            ConsumableItems = consumableItems;
            JobTypeId = jobTypeId;
            HousingAllowance = housingAllowance;
            AgreementSalary = agreementSalary;
            WorkingHoursWeekly = workingHoursWeekly;
            FamilyAllowance = familyAllowance;
            ContractPeriod = contractPeriod;
            Signature = "0";


            var personnelcodeConvert = personnelCode.ToString();
            ContractNo = archiveCode+"/"+personnelCode+"/"+sumYear+"/"+month;
        }

        public long PersonnelCode { get; private set; }
        public string ContractNo { get; private set; }
        public long EmployeeId { get; private set; }
        public long EmployerId { get; private set; }
        public long WorkshopIds { get; private set; }
        public long YearlySalaryId { get; private set; }
        public long JobTypeId { get; private set; }
        public DateTime ContarctStart { get; private set; }
        public DateTime ContractEnd { get; private set; }
        public DateTime GetWorkDate { get; private set; }
        public DateTime SetContractDate { get; private set; }
        public string JobType { get; private set; }
        public string ContractType { get; private set; }
        public string DayliWage { get; private set; }
        public string IsActiveString { get; private set; }
        public string ArchiveCode { get; private set; }
        public string WorkshopAddress1 { get; private set; }
        public string WorkshopAddress2 { get; private set; }
        public string ConsumableItems { get; private set; }
        public string HousingAllowance { get; private set; }
        public string AgreementSalary { get; private set; }
        public string WorkingHoursWeekly { get; private set; }
        public string FamilyAllowance { get; private set; }
        public string ContractPeriod { get; private set; }
        public string Signature { get; private set; }
        public Employee Employee { get; private set; }
        public Employer Employer { get; private set; }
        public Workshop? Workshop { get; set; }
        public YearlySalary YearlySalary { get; private set; }
        public Job Job { get; private set; }

        public List<WorkingHours> WorkingHoursList { get; private set; }

        public Contract()
        {
            WorkingHoursList = new List<WorkingHours>();
        }
        public void Edit(long pesrsonnelCode, long employeeId, long employerId, long workshopId, long yearlySalaryId,
            DateTime contarctStart, DateTime contractEnd, string dayliWage,
            string archiveCode, DateTime getWorkDate, DateTime setContractDate,
            string jobType, string contractType, string workshopAddress1, string workshopAddress2, string consumableItems, long jobTypeId, string housingAllowance, string agreementSalary, string workingHoursWeekly, string familyAllowance, string contractPeriod)
        {
            PersonnelCode = pesrsonnelCode;
            EmployeeId = employeeId;
            EmployerId = employerId;
            WorkshopIds = workshopId;
            YearlySalaryId = yearlySalaryId;
            ContarctStart = contarctStart;
            ContractEnd = contractEnd;
            DayliWage = dayliWage;
            ArchiveCode = archiveCode;
            GetWorkDate = getWorkDate;
            SetContractDate = setContractDate;
            JobType = jobType;
            ContractType = contractType;
            WorkshopAddress1 = workshopAddress1;
            WorkshopAddress2 = workshopAddress2;
            ConsumableItems = consumableItems;
            JobTypeId = jobTypeId;
            HousingAllowance = housingAllowance;
            AgreementSalary = agreementSalary;
            WorkingHoursWeekly = workingHoursWeekly;
            FamilyAllowance = familyAllowance;
            ContractPeriod = contractPeriod;
        }
        public void Active()
        {
           
            this.IsActiveString = "true";
        }

        public void DeActive()
        {
          
            this.IsActiveString = "false";
        }

        public void Sign()
        {
            this.Signature = "1";
        }

        public void UnSign()
        {
            this.Signature = "0";
        }
    }
}
