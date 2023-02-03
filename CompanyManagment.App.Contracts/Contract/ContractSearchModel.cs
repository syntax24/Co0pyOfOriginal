namespace CompanyManagment.App.Contracts.Contract
{
    public class ContractSearchModel
    {
        public long PersonnelCode { get; set; }
        public long EmployeeId { get; set; }
        public long EmployerId { get; set; }
        public long WorkshopIds { get; set; }
        public long YearlySalaryId { get; set; }
        public string ContarctStart { get; set; }
        public string ContractEnd { get; set; }
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
        public string WorkDay { get; set; }
        public string WorkTime { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string ConvertYear { get; set; }
        public string ConvertMonth { get; set; }
        public string ContractPeriod { get; set; }
        public string Signature { get; set; }
    }
}