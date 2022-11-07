using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Job;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.App.Contracts.YearlySalary;

namespace CompanyManagment.App.Contracts.Contract
{
    public class CreateContract
    {
        public long PersonnelCode { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public long EmployeeId { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public long EmployerId { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public long WorkshopIds { get; set; }
        public long YearlySalaryId { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string ContarctStart { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string ContractEnd { get; set; }
        public string DayliWage { get; set; }
        public string ContractNo { get; set; }
        public string ArchiveCode { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string WorkshopAddress1 { get; set; }
        public string WorkshopAddress2 { get; set; }
        public string ContractType { get; set; }
        public string JobType { get; set; }
        public string GetWorkDate { get; set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string SetContractDate { get; set; }
        //[Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        [RegularExpression("[+-]?\\d*\\.?\\d+", ErrorMessage = "لطفا فقط عدد وارد کنید")]
        public string ConsumableItems { get; set; }
        public string HousingAllowance { get; set; }
        public string AgreementSalary { get; set; }
        public string WorkingHoursWeekly { get; set; }
        public long JobTypeId { get; set; }
        public string FamilyAllowance { get; set; }
        public string ContractPeriod { get; set; }
        public bool shanbeh { get; set; }
        public bool yekshanbeh { get; set; }
        public bool doshanbeh { get; set; }
        public bool seshanbeh { get; set; }
        public bool cheharshanbeh { get; set; }
        public bool pangshanbeh { get; set; }
        public bool jomeh { get; set; }

        public string MandatoryStatus { get; set; }
        public string ShiftWork { get; set; }
        public string RestTime { get; set; }
        public string RestTimeYekshanbeh { get; set; }
        public string RestTimeDoshanbeh { get; set; }
        public string RestTimeSeshanbeh { get; set; }
        public string RestTimeCheharshanbeh { get; set; }
        public string RestTimePanjshanbeh { get; set; }
        public string RestTimeJomeh { get; set; }

        public string SingleShift1 { get; set; }
        public string SingleShift2 { get; set; }
        public string TowShifts1 { get; set; }
        public string TowShifts2 { get; set; }
        public string ThreeShift1 { get; set; }
        public string ThreeShift2 { get; set; }

        public string SingleShift1Yekshanbeh { get; set; }
        public string SingleShift2Yekshanbeh { get; set; }
        public string TowShifts1Yekshanbeh { get; set; }
        public string TowShifts2Yekshanbeh { get; set; }
        public string ThreeShift1Yekshanbeh { get; set; }
        public string ThreeShift2Yekshanbeh { get; set; }

        public string SingleShift1Doshanbeh { get; set; }
        public string SingleShift2Doshanbeh { get; set; }
        public string TowShifts1Doshanbeh { get; set; }
        public string TowShifts2Doshanbeh { get; set; }
        public string ThreeShift1Doshanbeh { get; set; }
        public string ThreeShift2Doshanbeh { get; set; }

        public string SingleShift1Seshanbeh { get; set; }
        public string SingleShift2Seshanbeh { get; set; }
        public string TowShifts1Seshanbeh { get; set; }
        public string TowShifts2Seshanbeh { get; set; }
        public string ThreeShift1Seshanbeh { get; set; }
        public string ThreeShift2Seshanbeh { get; set; }

        public string SingleShift1Cheharshanbeh { get; set; }
        public string SingleShift2Cheharshanbeh { get; set; }
        public string TowShifts1Cheharshanbeh { get; set; }
        public string TowShifts2Cheharshanbeh { get; set; }
        public string ThreeShift1Cheharshanbeh { get; set; }
        public string ThreeShift2Cheharshanbeh { get; set; }

        public string SingleShift1Panjshanbeh { get; set; }
        public string SingleShift2Panjshanbeh { get; set; }
        public string TowShifts1Panjshanbeh { get; set; }
        public string TowShifts2Panjshanbeh { get; set; }
        public string ThreeShift1Panjshanbeh { get; set; }
        public string ThreeShift2Panjshanbeh { get; set; }

        public string SingleShift1Jomeh { get; set; }
        public string SingleShift2Jomeh { get; set; }
        public string TowShifts1Jomeh { get; set; }
        public string TowShifts2Jomeh { get; set; }
        public string ThreeShift1Jomeh { get; set; }
        public string ThreeShift2Jomeh { get; set; }

        public string Start1224 { get; set; }
        public string End1224 { get; set; }
        public string Start1236 { get; set; }
        public string End1236 { get; set; }
        public string Start2424 { get; set; }
        public string End2424 { get; set; }
        public string Start2448 { get; set; }
        public string End2448 { get; set; }
        public string NumberOfWorkingDays { get; set; }
        public string NumberOfFriday { get; set; }
        public string TotalHoursesH { get; set; }
        public string TotalHoursesM { get; set; }
        public string OverTimeWorkH { get; set; }
        public string OverTimeWorkM { get; set; }
        public string OverNightWorkH { get; set; }
        public string OverNightWorkM { get; set; }
        public string WeeklyWorkingTime { get; set; }
        public string GetWorkDateHide { get; set; }

        public string Year { get; set; }
        public string Month { get; set; }
        public string ConvertYear { get; set; }
        public string ConvertMonth { get; set; }
        public string FormStep { get; set; }

      
        public List<ContractViweModel> Contracts { get; set; }
        public List<WorkshopViewModel> Workshops { get; set; }
        public List<EmployerViewModel> Employers { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public List<YearlySalaryViewModel> YearlySalaries { get; set; }

        public List<ExtensionViewModel> ExtensionViewModels { get; set; }
        public List<JobViewModel> Jobs { get; set; }
        public IQueryable<WorkshopEmployerViewModel> WorkshopEmployerList { get; set; }
     
    }
}
