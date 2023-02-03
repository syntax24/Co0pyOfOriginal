using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.ContractAgg;
using Company.Domain.EmployeeAgg;
using Company.Domain.LeftWorkAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.LeftWork;
using CompanyManagment.App.Contracts.WorkingHours;
using CompanyManagment.App.Contracts.WorkingHoursItems;

namespace CompanyManagment.Application
{
    public class LeftWorkApplication : ILeftWorkApplication
    {
        private readonly ILeftWorkRepository _leftWorkRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IContractApplication _contractApplication;
        private readonly IWorkingHoursApplication _workingHoursApplication;
        private readonly IWorkingHoursItemsApplication _workingHoursItemsApplication;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWorkshopRepository _workshopRepository;


        public LeftWorkApplication(ILeftWorkRepository leftWorkRepository, IContractRepository contractRepository, IContractApplication contractApplication, IWorkingHoursApplication workingHoursApplication, IWorkingHoursItemsApplication workingHoursItemsApplication, IEmployeeRepository employeeRepository, IWorkshopRepository workshopRepository)
        {
            _leftWorkRepository = leftWorkRepository;
            _contractRepository = contractRepository;
            _contractApplication = contractApplication;
            _workingHoursApplication = workingHoursApplication;
            _workingHoursItemsApplication = workingHoursItemsApplication;
            _employeeRepository = employeeRepository;
            _workshopRepository = workshopRepository;
        }

        public OperationResult Create(CreateLeftWork command)
        {

            //var Contracts = _contractRepository.Search(new ContractSearchModel()
            //{
            //    EmployeeId = command.EmployeeId,
            //    WorkshopIds = command.WorkshopId
                
            //});
            //var lastContract = Contracts.FirstOrDefault();
            var operation = new OperationResult();
            var left = command.LeftWorkDate.ToGeorgianDateTime();
            var start = command.StartWorkDate.ToGeorgianDateTime();

            //var nextMonthStartGr = lastContract.ContractEndGr.AddDays(1);
            //var nextMonthStartFarsi = nextMonthStartGr.ToFarsi();
            //var nextMonthEnd = nextMonthStartFarsi.FindeEndOfMonth();
            //var nextMonthEndGr = nextMonthEnd.ToGeorgianDateTime();


            if (_leftWorkRepository.Exists(x =>
                x.StartWorkDate > start && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
                return operation.Failed("تاریخ وارد شده کوچکتر از سابقه  شروع به کار قبلی است");
            if (_leftWorkRepository.Exists(x =>
                x.StartWorkDate == start && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
                return operation.Failed("تاریخ وارد شده برابر سابقه  شروع به کار قبلی است");
            if (_leftWorkRepository.Exists(x =>
                x.StartWorkDate <= start && x.LeftWorkDate == left && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
                return operation.Failed("شروع به کار قبلی این شخص ترک کار ندارد ");
            if (_leftWorkRepository.Exists(x =>
                x.StartWorkDate <= start && x.LeftWorkDate < left && x.LeftWorkDate >= start && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
                return operation.Failed("تاریخ وارد شده در بازه زمانی سابقه ترک کار قبلی است");
            //if (left <= lastContract.ContractStartGr)
            //    return operation.Failed("تاریخ وارد شده کوچکتر از تاریخ شروع آخرین قرارداد است");
            //if (_leftWorkRepository.Exists(x =>
            //    lastContract.ContractEndGr >= left && x.LeftWorkDate >= lastContract.ContractStartGr && x.LeftWorkDate <= left && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
            //    return operation.Failed("برای آخرین قرارداد سابقه ترک کار وجود دارد");
            //if (_leftWorkRepository.Exists(x =>
            //    lastContract.ContractEndGr < left && x.LeftWorkDate >= lastContract.ContractStartGr && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
            //    return operation.Failed("برای تاریخ وارد شده قراردادی وجود ندارد");
            //if (left > nextMonthEndGr)
            //    return operation.Failed("برای تاریخ وارد شده قراردادی وجود ندارد");
            //if (left > nextMonthStartGr)
            //{
            //    LeftWorkExtension(lastContract.Id, nextMonthStartFarsi, nextMonthEnd);
            //}
            if (command.WorkshopId < 1)
                return operation.Failed("انتخاب کارگاه ضروری است");
            var employeeFullName = _employeeRepository.GetDetails(command.EmployeeId).EmployeeFullName;
            var workshopName = _workshopRepository.GetDetails(command.WorkshopId).WorkshopFullName;
         
            var leftWork = new LeftWork(left,start,command.WorkshopId,
                command.EmployeeId, employeeFullName, workshopName);
            _leftWorkRepository.Create(leftWork);
            _leftWorkRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult Edit(EditLeftWork command)
        {
            var operation = new OperationResult();
            var left = command.LeftWorkDate.ToGeorgianDateTime();
            var start = command.StartWorkDate.ToGeorgianDateTime();
            var leftWorkEdit = _leftWorkRepository.Get(command.Id);
            if (leftWorkEdit == null)
                operation.Failed("رکورد مورد نظر وجود ندارد");
            if (start >= left)
                return operation.Failed("تاریخ وارد شده ک.چکتر یا مساوی تاریخ شروع به کار است");

            leftWorkEdit.Edit(left, start, command.WorkshopId,
                command.EmployeeId);
            _leftWorkRepository.SaveChanges();
            return operation.Succcedded();
        }

        public EditLeftWork GetDetails(long id)
        {
            return _leftWorkRepository.GetDetails(id);
        }

        public List<LeftWorkViewModel> search(LeftWorkSearchModel searchModel)
        {
            return _leftWorkRepository.search(searchModel);
        }

        public string StartWork(long employeeId, long workshopId, string leftWork)
        {
            return _leftWorkRepository.StartWork(employeeId, workshopId, leftWork);
        }

        public OperationResult RemoveLeftWork(long id)
        {
            return _leftWorkRepository.RemoveLeftWork(id);
        }

        public void LeftWorkExtension(long contractId,string CStart,string CEnd)
        {
            
            var step1 = _contractApplication.GetDetails(contractId);
            var step2 = _workingHoursApplication.GetByContractId(contractId);
            var step3 = _workingHoursItemsApplication.GetWorkingHoursItems();
            var step4 = step3.Where(x => x.WorkingHoursId == step2.Id).ToList();
            var RestTime = step4.Where(x => x.DayOfWork == "0").Select(x => x.RestTime).SingleOrDefault();
            var RestTimeYekshanbeh =
                step4.Where(x => x.DayOfWork == "1").Select(x => x.RestTime).SingleOrDefault();
            var RestTimeDoshanbeh =
                step4.Where(x => x.DayOfWork == "2").Select(x => x.RestTime).SingleOrDefault();
            var RestTimeSeshanbeh =
                step4.Where(x => x.DayOfWork == "3").Select(x => x.RestTime).SingleOrDefault();
            var RestTimeCheharshanbeh =
                step4.Where(x => x.DayOfWork == "4").Select(x => x.RestTime).SingleOrDefault();
            var RestTimePanjshanbeh =
                step4.Where(x => x.DayOfWork == "5").Select(x => x.RestTime).SingleOrDefault();
            var RestTimeJomeh = step4.Where(x => x.DayOfWork == "6").Select(x => x.RestTime).SingleOrDefault();

            var SingleShift1 = step4.Where(x => x.DayOfWork == "0").Select(x => x.Start1).SingleOrDefault();
            var SingleShift2 = step4.Where(x => x.DayOfWork == "0").Select(x => x.End1).SingleOrDefault();
            var SingleShift1Yekshanbeh =
                step4.Where(x => x.DayOfWork == "1").Select(x => x.Start1).SingleOrDefault();
            var SingleShift2Yekshanbeh = step4.Where(x => x.DayOfWork == "1").Select(x => x.End1).SingleOrDefault();
            var SingleShift1Doshanbeh =
                step4.Where(x => x.DayOfWork == "2").Select(x => x.Start1).SingleOrDefault();
            var SingleShift2Doshanbeh = step4.Where(x => x.DayOfWork == "2").Select(x => x.End1).SingleOrDefault();
            var SingleShift1Seshanbeh =
                step4.Where(x => x.DayOfWork == "3").Select(x => x.Start1).SingleOrDefault();
            var SingleShift2Seshanbeh = step4.Where(x => x.DayOfWork == "3").Select(x => x.End1).SingleOrDefault();
            var SingleShift1Cheharshanbeh =
                step4.Where(x => x.DayOfWork == "4").Select(x => x.Start1).SingleOrDefault();
            var SingleShift2Cheharshanbeh =
                step4.Where(x => x.DayOfWork == "4").Select(x => x.End1).SingleOrDefault();
            var SingleShift1Panjshanbeh =
                step4.Where(x => x.DayOfWork == "5").Select(x => x.Start1).SingleOrDefault();
            var SingleShift2Panjshanbeh =
                step4.Where(x => x.DayOfWork == "5").Select(x => x.End1).SingleOrDefault();
            var SingleShift1Jomeh = step4.Where(x => x.DayOfWork == "6").Select(x => x.Start1).SingleOrDefault();
            var SingleShift2Jomeh = step4.Where(x => x.DayOfWork == "6").Select(x => x.End1).SingleOrDefault();


            var TowShifts1 = step4.Where(x => x.DayOfWork == "0").Select(x => x.Start2).SingleOrDefault();
            var TowShifts2 = step4.Where(x => x.DayOfWork == "0").Select(x => x.End2).SingleOrDefault();
            var TowShifts1Yekshanbeh = step4.Where(x => x.DayOfWork == "1").Select(x => x.Start2).SingleOrDefault();
            var TowShifts2Yekshanbeh = step4.Where(x => x.DayOfWork == "1").Select(x => x.End2).SingleOrDefault();
            var TowShifts1Doshanbeh = step4.Where(x => x.DayOfWork == "2").Select(x => x.Start2).SingleOrDefault();
            var TowShifts2Doshanbeh = step4.Where(x => x.DayOfWork == "2").Select(x => x.End2).SingleOrDefault();
            var TowShifts1Seshanbeh = step4.Where(x => x.DayOfWork == "3").Select(x => x.Start2).SingleOrDefault();
            var TowShifts2Seshanbeh = step4.Where(x => x.DayOfWork == "3").Select(x => x.End2).SingleOrDefault();
            var TowShifts1Cheharshanbeh =
                step4.Where(x => x.DayOfWork == "4").Select(x => x.Start1).SingleOrDefault();
            var TowShifts2Cheharshanbeh =
                step4.Where(x => x.DayOfWork == "4").Select(x => x.End2).SingleOrDefault();
            var TowShifts1Panjshanbeh =
                step4.Where(x => x.DayOfWork == "5").Select(x => x.Start2).SingleOrDefault();
            var TowShifts2Panjshanbeh = step4.Where(x => x.DayOfWork == "5").Select(x => x.End2).SingleOrDefault();
            var TowShifts1Jomeh = step4.Where(x => x.DayOfWork == "6").Select(x => x.Start2).SingleOrDefault();
            var TowShifts2Jomeh = step4.Where(x => x.DayOfWork == "6").Select(x => x.End2).SingleOrDefault();

            var Start1224 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexStart).SingleOrDefault();
            var End1224 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexEnd).SingleOrDefault();
            var Start1236 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexStart).SingleOrDefault();
            var End1236 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexEnd).SingleOrDefault();
            var Start2424 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexStart).SingleOrDefault();
            var End2424 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexEnd).SingleOrDefault();
            var Start2448 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexStart).SingleOrDefault();
            var End2448 = step4.Where(x => x.DayOfWork == "7").Select(x => x.ComplexEnd).SingleOrDefault();

            var computing = new CreateContract
            {
                ShiftWork = step2.ShiftWork,
                RestTime = RestTime,
                RestTimeYekshanbeh = RestTimeYekshanbeh,
                RestTimeDoshanbeh = RestTimeDoshanbeh,
                RestTimeSeshanbeh = RestTimeSeshanbeh,
                RestTimeCheharshanbeh = RestTimeCheharshanbeh,
                RestTimePanjshanbeh = RestTimePanjshanbeh,
                RestTimeJomeh = RestTimeJomeh,

                SingleShift1 = SingleShift1,
                SingleShift2 = SingleShift2,
                SingleShift1Yekshanbeh = SingleShift1Yekshanbeh,
                SingleShift2Yekshanbeh = SingleShift2Yekshanbeh,
                SingleShift1Doshanbeh = SingleShift1Doshanbeh,
                SingleShift2Doshanbeh = SingleShift2Doshanbeh,
                SingleShift1Seshanbeh = SingleShift1Seshanbeh,
                SingleShift2Seshanbeh = SingleShift2Seshanbeh,
                SingleShift1Cheharshanbeh = SingleShift1Cheharshanbeh,
                SingleShift2Cheharshanbeh = SingleShift2Cheharshanbeh,
                SingleShift1Panjshanbeh = SingleShift1Panjshanbeh,
                SingleShift2Panjshanbeh = SingleShift2Panjshanbeh,
                SingleShift1Jomeh = SingleShift1Jomeh,
                SingleShift2Jomeh = SingleShift2Jomeh,


                TowShifts1 = TowShifts1,
                TowShifts2 = TowShifts2,
                TowShifts1Yekshanbeh = TowShifts1Yekshanbeh,
                TowShifts2Yekshanbeh = TowShifts2Yekshanbeh,
                TowShifts1Doshanbeh = TowShifts1Doshanbeh,
                TowShifts2Doshanbeh = TowShifts2Doshanbeh,
                TowShifts1Seshanbeh = TowShifts1Seshanbeh,
                TowShifts2Seshanbeh = TowShifts2Seshanbeh,
                TowShifts1Cheharshanbeh = TowShifts1Cheharshanbeh,
                TowShifts2Cheharshanbeh = TowShifts2Cheharshanbeh,
                TowShifts1Panjshanbeh = TowShifts1Panjshanbeh,
                TowShifts2Panjshanbeh = TowShifts2Panjshanbeh,
                TowShifts1Jomeh = TowShifts1Jomeh,
                TowShifts2Jomeh = TowShifts2Jomeh,

                Start1224 = Start1224,
                End1224 = End1224,
                Start1236 = Start1236,
                End1236 = End1236,
                Start2424 = Start2424,
                End2424 = End2424,
                Start2448 = Start2448,
                End2448 = End2448,
                EmployeeId = step1.EmployeeId,
                ContarctStart = CStart,
                ContractEnd = CEnd,
                GetWorkDateHide = step1.GetWorkDate,

            };
            var step5 = _contractApplication.MandatoryHours(computing);
            string workingDays = string.Empty;
            if (step5.NumberOfWorkingDays == "0")
            {

                workingDays = step5.ComplexNumberOfWorkingDays;
            }
            else
            {
                workingDays = step5.NumberOfWorkingDays;
            }


            var createNew = new CreateContract
            {
                EmployeeId = step1.EmployeeId,
                EmployerId = step1.EmployerId,
                WorkshopIds = step1.WorkshopIds,
                GetWorkDate = step1.GetWorkDate,
                SetContractDate = CStart,
                ArchiveCode = step1.ArchiveCode,
                ContarctStart = CStart,
                ContractEnd = CEnd,
                YearlySalaryId = step1.YearlySalaryId,
                ConsumableItems = step5.ConsumableItems,
                HousingAllowance = step5.HousingAllowance,
                DayliWage = step5.SalaryCompute,
                FamilyAllowance = step5.FamilyAllowance,
                WeeklyWorkingTime = step5.SumTime44,
                WorkingHoursWeekly = step5.SumTime44,
                JobType = step1.JobType,
                JobTypeId = step1.JobTypeId,
                ContractType = step1.ContractType,
                WorkshopAddress1 = step1.WorkshopAddress1,
                WorkshopAddress2 = step1.WorkshopAddress2,
                AgreementSalary = step1.AgreementSalary,
                ContractPeriod = step1.ContractPeriod,

                ShiftWork = step2.ShiftWork,
                RestTime = RestTime,
                RestTimeYekshanbeh = RestTimeYekshanbeh,
                RestTimeDoshanbeh = RestTimeDoshanbeh,
                RestTimeSeshanbeh = RestTimeSeshanbeh,
                RestTimeCheharshanbeh = RestTimeCheharshanbeh,
                RestTimePanjshanbeh = RestTimePanjshanbeh,
                RestTimeJomeh = RestTimeJomeh,

                SingleShift1 = SingleShift1,
                SingleShift2 = SingleShift2,
                SingleShift1Yekshanbeh = SingleShift1Yekshanbeh,
                SingleShift2Yekshanbeh = SingleShift2Yekshanbeh,
                SingleShift1Doshanbeh = SingleShift1Doshanbeh,
                SingleShift2Doshanbeh = SingleShift2Doshanbeh,
                SingleShift1Seshanbeh = SingleShift1Seshanbeh,
                SingleShift2Seshanbeh = SingleShift2Seshanbeh,
                SingleShift1Cheharshanbeh = SingleShift1Cheharshanbeh,
                SingleShift2Cheharshanbeh = SingleShift2Cheharshanbeh,
                SingleShift1Panjshanbeh = SingleShift1Panjshanbeh,
                SingleShift2Panjshanbeh = SingleShift2Panjshanbeh,
                SingleShift1Jomeh = SingleShift1Jomeh,
                SingleShift2Jomeh = SingleShift2Jomeh,


                TowShifts1 = TowShifts1,
                TowShifts2 = TowShifts2,
                TowShifts1Yekshanbeh = TowShifts1Yekshanbeh,
                TowShifts2Yekshanbeh = TowShifts2Yekshanbeh,
                TowShifts1Doshanbeh = TowShifts1Doshanbeh,
                TowShifts2Doshanbeh = TowShifts2Doshanbeh,
                TowShifts1Seshanbeh = TowShifts1Seshanbeh,
                TowShifts2Seshanbeh = TowShifts2Seshanbeh,
                TowShifts1Cheharshanbeh = TowShifts1Cheharshanbeh,
                TowShifts2Cheharshanbeh = TowShifts2Cheharshanbeh,
                TowShifts1Panjshanbeh = TowShifts1Panjshanbeh,
                TowShifts2Panjshanbeh = TowShifts2Panjshanbeh,
                TowShifts1Jomeh = TowShifts1Jomeh,
                TowShifts2Jomeh = TowShifts2Jomeh,

                Start1224 = Start1224,
                End1224 = End1224,
                Start1236 = Start1236,
                End1236 = End1236,
                Start2424 = Start2424,
                End2424 = End2424,
                Start2448 = Start2448,
                End2448 = End2448,

                NumberOfWorkingDays = workingDays,
                NumberOfFriday = step5.NumberOfFriday,
                TotalHoursesH = step5.TotalHoursesH == "0" ? "" : step5.TotalHoursesH,
                TotalHoursesM = step5.TotalHoursesM == "0" ? "" : step5.TotalHoursesM,
                OverTimeWorkH = step5.OverTimeWorkH == "0" ? "" : step5.OverTimeWorkH,
                OverTimeWorkM = step5.OverTimeWorkM == "0" ? "" : step5.OverTimeWorkM,
                OverNightWorkH = step5.OverNightWorkH == "0" ? "" : step5.OverNightWorkH,
                OverNightWorkM = step5.OverNightWorkM == "0" ? "" : step5.OverNightWorkM,


            };
            var resss = _contractApplication.Create(createNew);
        }
    }
}
