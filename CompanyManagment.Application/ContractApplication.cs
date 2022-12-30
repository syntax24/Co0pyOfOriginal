using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.ContractAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.HolidayItemAgg;
using Company.Domain.LeftWorkAgg;
using Company.Domain.WorkingHoursAgg;
using Company.Domain.YearlySalaryAgg;
using Company.Domain.YearlySalaryItemsAgg;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.LeftWork;
using CompanyManagment.App.Contracts.WorkingHours;
using CompanyManagment.App.Contracts.WorkingHoursItems;
using CompanyManagment.App.Contracts.Workshop;
using Microsoft.EntityFrameworkCore;
using PersianTools.Core;

namespace CompanyManagment.Application
{
    public class ContractApplication : IContractApplication
    {
        private readonly IContractRepository _contractRepository;
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IEmployerApplication _employerApplication;
        private readonly IWorkshopApplication _workshopApplication;
        private readonly IEmployerRepository _employerRepository;
        private readonly IHolidayItemRepository _holidayItemRepository;
        private readonly IYearlySalaryRepository _yearlySalaryRepository;
        private readonly IYearlySalaryItemRepository _yearlySalaryItemRepository;
        private readonly IWorkingHoursApplication _workingHoursApplication;
        private readonly IWorkingHoursItemsApplication _workingHoursItemsApplication;
        private readonly ILeftWorkRepository _leftWorkRepository;

        public List<EmployerViewModel> EmpList;

        //List<string> holiday = new List<string>();
        private string InterferenceMessage = string.Empty;
        string Notholiday = String.Empty;
        private string Holidays = string.Empty;
        private string SingleShiftResult = String.Empty;
        string shift1Hourse = "0";
        string shift1Minuts = "0";
        string shift1HolidayHours = "0";
        string shift1HolidayMinuts = "0";
        private string overMandatoryHours = "0";
        private string overMandatoryMinuts = "0";
        private string shiftOver22Hours = "0";
        private string shiftOver22Minuts = "0";
        string line2 = string.Empty;
        string line3 = string.Empty;
        string line4 = string.Empty;

        public ContractApplication(IContractRepository contractRepository,
            IHolidayItemRepository holidayItemRepository,
            IYearlySalaryRepository yearlySalaryRepository,
            IYearlySalaryItemRepository yearlySalaryItemRepository
            , IEmployeeApplication employeeApplication, IEmployerApplication employerApplication, IWorkshopApplication workshopApplication, IEmployerRepository employerRepository,
            IWorkingHoursApplication workingHoursApplication, IWorkingHoursItemsApplication workingHoursItemsApplication, ILeftWorkRepository leftWorkRepository)
        {
            _contractRepository = contractRepository;
            _holidayItemRepository = holidayItemRepository;
            _yearlySalaryRepository = yearlySalaryRepository;
            _yearlySalaryItemRepository = yearlySalaryItemRepository;
            _employeeApplication = employeeApplication;
            _employerApplication = employerApplication;
            _workshopApplication = workshopApplication;
            _employerRepository = employerRepository;
            _workingHoursApplication = workingHoursApplication;
            _workingHoursItemsApplication = workingHoursItemsApplication;
            _leftWorkRepository = leftWorkRepository;
            //_leftWorkApplication = leftWorkApplication;
        }


        public OperationResult Create(CreateContract command)
        {
            var yearlysalaryList = _yearlySalaryRepository.GetYearlySalary();
            var yearlySalarId = yearlysalaryList.FirstOrDefault().Id;
            var operation = new OperationResult();

            var personnelCode = _contractRepository.FindPersonnelCode(command.WorkshopIds, command.EmployeeId);
            if (command.EmployeeId == 0)
                return operation.Failed("لطفا پرسنل را وارد کنید");
            if (command.ArchiveCode == null)
                return operation.Failed("لطفا کارگاه را انتخاب کنید");
            if (command.ContarctStart == null)
                return operation.Failed("لطفا تاریخ شروع قرارداد را مشخص کنید");
            if (command.ContractEnd == null)
                return operation.Failed("لطفا تاریخ پایان قرارداد را مشخص کنید");
            if (command.SetContractDate == null)
                return operation.Failed("لطفا تاریخ انعقاد قرارداد را مشخص کنید");
            if (command.GetWorkDate == null)
                return operation.Failed("لطفا تاریخ شروع به کار را مشخص کنید");
            var start = command.ContarctStart.ToGeorgianDateTime();
            var end = command.ContractEnd.ToGeorgianDateTime();
            var getWorkdate = command.GetWorkDate.ToGeorgianDateTime();
            var setContractDate = command.SetContractDate.ToGeorgianDateTime();
            //var familyAllowance = _yearlySalaryRepository.FamilyAllowance(command.EmployeeId, end);
            if (_contractRepository.Exists(x =>
                x.EmployeeId == command.EmployeeId && (x.ContarctStart <= start && x.ContractEnd >= start && x.IsActiveString=="true"))) {
                var message = _contractRepository.ContractStartCheck(start, command.EmployeeId);
                return operation.Failed(message);
            }

            if (_contractRepository.Exists(x =>
                x.ContarctStart == start && x.WorkshopIds == command.WorkshopIds && x.EmployeeId == command.EmployeeId && x.IsActiveString =="true"))
                return operation.Failed("تکراراری است");
            if (start > end)
                return operation.Failed("تاریخ شروع از تاریخ پایان بزرگتر است");

            if (start == end)
                return operation.Failed("تاریخ شروع و تاریخ پایان برابر وارد شده اند");

            if (command.ConsumableItems == null || command.HousingAllowance == null || command.DayliWage == null || command.WorkingHoursWeekly == null)
                return operation.Failed("لطفا محاسبات بخش ساعت کار را کامل کنید");
            
            var makeContract = new Contract(personnelCode, command.EmployeeId, command.EmployerId, command.WorkshopIds,
                yearlySalarId,
                start, end, command.DayliWage, command.ArchiveCode, getWorkdate, setContractDate,
                command.JobType, command.ContractType, command.WorkshopAddress1, command.WorkshopAddress2,
                command.ConsumableItems, command.JobTypeId, command.HousingAllowance, command.AgreementSalary, command.WorkingHoursWeekly, command.FamilyAllowance, command.ContractPeriod);

            _contractRepository.Create(makeContract);
            _contractRepository.SaveChanges();

            var createWorkingHours = new CreateWorkingHours
            {
                ContractId = makeContract.id,
                ShiftWork = command.ShiftWork,
                ContractNo = makeContract.ContractNo,
                NumberOfWorkingDays = command.NumberOfWorkingDays,
                NumberOfFriday = command.NumberOfFriday,
                TotalHoursesH = command.TotalHoursesH,
                TotalHoursesM = command.TotalHoursesM,
                OverTimeWorkH = command.OverTimeWorkH,
                OverTimeWorkM = command.OverTimeWorkM,
                OverNightWorkH = command.OverNightWorkH,
                OverNightWorkM = command.OverNightWorkM,
                WeeklyWorkingTime = command.WeeklyWorkingTime,

            };
            var a = _workingHoursApplication.Create(createWorkingHours);
            var workingHoursID = Convert.ToInt64(a.Message);
            if (command.ShiftWork == "1" || command.ShiftWork == "2")
            {
                if (command.shanbeh == true)
                {
                    var create = new CreateWorkingHoursItems
                    {
                        DayOfWork = "0",
                        Start1 = command.SingleShift1,
                        End1 = command.SingleShift2,
                        RestTime = command.RestTime,
                        Start2 = command.TowShifts1,
                        End2 = command.TowShifts2,
                        WorkingHoursId = workingHoursID

                    };
                    _workingHoursItemsApplication.Create(create);
                }
                if (command.yekshanbeh == true)
                {
                    var create = new CreateWorkingHoursItems
                    {
                        DayOfWork = "1",
                        Start1 = command.SingleShift1Yekshanbeh,
                        End1 = command.SingleShift2Yekshanbeh,
                        RestTime = command.RestTimeYekshanbeh,
                        Start2 = command.TowShifts1Yekshanbeh,
                        End2 = command.TowShifts2Yekshanbeh,
                        WorkingHoursId = workingHoursID

                    };
                    _workingHoursItemsApplication.Create(create);
                }
                if (command.doshanbeh == true)
                {
                    var create = new CreateWorkingHoursItems
                    {
                        DayOfWork = "2",
                        Start1 = command.SingleShift1Doshanbeh,
                        End1 = command.SingleShift2Doshanbeh,
                        RestTime = command.RestTimeDoshanbeh,
                        Start2 = command.TowShifts1Doshanbeh,
                        End2 = command.TowShifts2Doshanbeh,
                        WorkingHoursId = workingHoursID

                    };
                    _workingHoursItemsApplication.Create(create);
                }
                if (command.seshanbeh == true)
                {
                    var create = new CreateWorkingHoursItems
                    {
                        DayOfWork = "3",
                        Start1 = command.SingleShift1Seshanbeh,
                        End1 = command.SingleShift2Seshanbeh,
                        RestTime = command.RestTimeSeshanbeh,
                        Start2 = command.TowShifts1Seshanbeh,
                        End2 = command.TowShifts2Seshanbeh,
                        WorkingHoursId = workingHoursID

                    };
                    _workingHoursItemsApplication.Create(create);
                }
                if (command.cheharshanbeh == true)
                {
                    var create = new CreateWorkingHoursItems
                    {
                        DayOfWork = "4",
                        Start1 = command.SingleShift1Cheharshanbeh,
                        End1 = command.SingleShift2Cheharshanbeh,
                        RestTime = command.RestTimeCheharshanbeh,
                        Start2 = command.TowShifts1Cheharshanbeh,
                        End2 = command.TowShifts2Cheharshanbeh,
                        WorkingHoursId = workingHoursID

                    };
                    _workingHoursItemsApplication.Create(create);
                }
                if (command.pangshanbeh == true)
                {
                    var create = new CreateWorkingHoursItems
                    {
                        DayOfWork = "5",
                        Start1 = command.SingleShift1Panjshanbeh,
                        End1 = command.SingleShift2Panjshanbeh,
                        RestTime = command.RestTimePanjshanbeh,
                        Start2 = command.TowShifts1Panjshanbeh,
                        End2 = command.TowShifts2Panjshanbeh,
                        WorkingHoursId = workingHoursID

                    };
                    _workingHoursItemsApplication.Create(create);
                }
                if (command.jomeh == true)
                {
                    var create = new CreateWorkingHoursItems
                    {
                        DayOfWork = "6",
                        Start1 = command.SingleShift1Jomeh,
                        End1 = command.SingleShift2Jomeh,
                        RestTime = command.RestTimeJomeh,
                        Start2 = command.TowShifts1Jomeh,
                        End2 = command.TowShifts2Jomeh,
                        WorkingHoursId = workingHoursID

                    };
                    _workingHoursItemsApplication.Create(create);
                }
            }
            else if (command.ShiftWork == "5")
            {
                var create = new CreateWorkingHoursItems
                {
                    DayOfWork = "7",
                    ComplexStart = command.Start1224,
                    ComplexEnd = command.End1224,

                    WorkingHoursId = workingHoursID

                };
                _workingHoursItemsApplication.Create(create);
            }
            else if (command.ShiftWork == "6")
            {
                var create = new CreateWorkingHoursItems
                {
                    DayOfWork = "7",
                    ComplexStart = command.Start2424,
                    ComplexEnd = command.End2424,

                    WorkingHoursId = workingHoursID

                };
                _workingHoursItemsApplication.Create(create);
            }
            else if (command.ShiftWork == "7")
            {
                var create = new CreateWorkingHoursItems
                {
                    DayOfWork = "7",
                    ComplexStart = command.Start1236,
                    ComplexEnd = command.End1236,

                    WorkingHoursId = workingHoursID

                };
                _workingHoursItemsApplication.Create(create);
            }
            else if (command.ShiftWork == "8")
            {
                var create = new CreateWorkingHoursItems
                {
                    DayOfWork = "7",
                    ComplexStart = command.Start2448,
                    ComplexEnd = command.End2448,

                    WorkingHoursId = workingHoursID

                };
                _workingHoursItemsApplication.Create(create);
            }


            return operation.Succcedded();


        }

        public OperationResult Edit(EditContract command)
        {
            throw new NotImplementedException();
        }

        public ComputingViewModel MandatoryHours(CreateContract command)
        {
            string SumWorkeTime = string.Empty;

            bool overNight = false;
            bool overNightTow = false;
            TimeSpan singleOver24 = new TimeSpan();
            TimeSpan towOver24 = new TimeSpan();
            TimeSpan panjshanbehOver24 = new TimeSpan();
            TimeSpan panjshanbehOver24Tow = new TimeSpan();
            TimeSpan rest = new TimeSpan();
            TimeSpan Over22 = new TimeSpan();

            DateTime starTimeSingel1, endTimeSingel2, singleShiftOver24, startTimeTowSh1, endTimeTowSh2, nightWork22, nightWork6;


            singleShiftOver24 = Convert.ToDateTime("00:00");
            nightWork22 = Convert.ToDateTime("22:00");
            nightWork6 = Convert.ToDateTime("06:00");


            TimeSpan SumSingle = new TimeSpan();
            TimeSpan SumTow = new TimeSpan();
            int SumSingleHourses = 0;
            int SumTowHourses = 0;

            TimeSpan sumRest = new TimeSpan();
            if (command.RestTime != null)
            {
                var rest0 = TimeSpan.Parse($"{command.RestTime}:{00}");
                sumRest = sumRest.Add(rest0);
            }

            if (command.RestTimeYekshanbeh != null)
            {
                var rest1 = TimeSpan.Parse($"{command.RestTimeYekshanbeh}:{00}");
                sumRest = sumRest.Add(rest1);
            }

            if (command.RestTimeDoshanbeh != null)
            {
                var rest2 = TimeSpan.Parse($"{command.RestTimeDoshanbeh}:{00}");
                sumRest = sumRest.Add(rest2);
            }
            if (command.RestTimeSeshanbeh != null)
            {
                var rest3 = TimeSpan.Parse($"{command.RestTimeSeshanbeh}:{00}");
                sumRest = sumRest.Add(rest3);
            }
            if (command.RestTimeCheharshanbeh != null)
            {
                var rest4 = TimeSpan.Parse($"{command.RestTimeCheharshanbeh}:{00}");
                sumRest = sumRest.Add(rest4);
            }
            if (command.RestTimePanjshanbeh != null)
            {
                var rest5 = TimeSpan.Parse($"{command.RestTimePanjshanbeh}:{00}");
                sumRest = sumRest.Add(rest5);
            }
            if (command.RestTimeJomeh != null)
            {
                var rest6 = TimeSpan.Parse($"{command.RestTimeJomeh}:{00}");
                sumRest = sumRest.Add(rest6);
            }











            DateTime StartShanbehSingle = Convert.ToDateTime(command.SingleShift1);
            DateTime EndShanbehSingle = Convert.ToDateTime(command.SingleShift2);
            if (StartShanbehSingle > EndShanbehSingle)
                EndShanbehSingle = EndShanbehSingle.AddDays(1);
            TimeSpan ShanbehSingle = (EndShanbehSingle - StartShanbehSingle);
            SumSingle = SumSingle.Add(ShanbehSingle);

            DateTime StartYekShanbehSingle = Convert.ToDateTime(command.SingleShift1Yekshanbeh);
            DateTime EndYekShanbehSingle = Convert.ToDateTime(command.SingleShift2Yekshanbeh);
            if (StartYekShanbehSingle > EndYekShanbehSingle)
                EndYekShanbehSingle = EndYekShanbehSingle.AddDays(1);
            TimeSpan YekShanbehSingle = (EndYekShanbehSingle - StartYekShanbehSingle);
            SumSingle = SumSingle.Add(YekShanbehSingle);

            DateTime StartDoShanbehSingle = Convert.ToDateTime(command.SingleShift1Doshanbeh);
            DateTime EndDoShanbehSingle = Convert.ToDateTime(command.SingleShift2Doshanbeh);
            if (StartDoShanbehSingle > EndDoShanbehSingle)
                EndDoShanbehSingle = EndDoShanbehSingle.AddDays(1);
            TimeSpan DoShanbehSingle = (EndDoShanbehSingle - StartDoShanbehSingle);
            SumSingle = SumSingle.Add(DoShanbehSingle);


            DateTime StartSehShanbehSingle = Convert.ToDateTime(command.SingleShift1Seshanbeh);
            DateTime EndSehShanbehSingle = Convert.ToDateTime(command.SingleShift2Seshanbeh);
            if (StartSehShanbehSingle > EndSehShanbehSingle)
                EndSehShanbehSingle = EndSehShanbehSingle.AddDays(1);
            TimeSpan SeShanbehSingle = (EndSehShanbehSingle - StartSehShanbehSingle);
            SumSingle = SumSingle.Add(SeShanbehSingle);

            DateTime StartCheharShanbehSingle = Convert.ToDateTime(command.SingleShift1Cheharshanbeh);
            DateTime EndCheharShanbehSingle = Convert.ToDateTime(command.SingleShift2Cheharshanbeh);
            if (StartCheharShanbehSingle > EndCheharShanbehSingle)
                EndCheharShanbehSingle = EndCheharShanbehSingle.AddDays(1);
            TimeSpan CheharShanbehSingle = (EndCheharShanbehSingle - StartCheharShanbehSingle);
            SumSingle = SumSingle.Add(CheharShanbehSingle);

            DateTime StartPanjShanbehSingle = Convert.ToDateTime(command.SingleShift1Panjshanbeh);
            DateTime EndPanjShanbehSingle = Convert.ToDateTime(command.SingleShift2Panjshanbeh);
            if (StartPanjShanbehSingle > EndPanjShanbehSingle)
                EndPanjShanbehSingle = EndPanjShanbehSingle.AddDays(1);
            TimeSpan PanjShanbehSingle = (EndPanjShanbehSingle - StartPanjShanbehSingle);
            SumSingle = SumSingle.Add(PanjShanbehSingle);

            DateTime StartJomehSingle = Convert.ToDateTime(command.SingleShift1Jomeh);
            DateTime EndjomehSingle = Convert.ToDateTime(command.SingleShift2Jomeh);
            if (StartJomehSingle > EndjomehSingle)
                EndjomehSingle = EndjomehSingle.AddDays(1);
            TimeSpan JomehSingle = (EndjomehSingle - StartJomehSingle);
            SumSingle = SumSingle.Add(JomehSingle);
            if (command.ShiftWork == "1")
            {
                SumSingle = SumSingle.Subtract(sumRest);
            }
            //SumSingleHourses = (int)SumSingle.TotalHours;


            DateTime StartShanbehTow = Convert.ToDateTime(command.TowShifts1);
            DateTime EndShanbehTow = Convert.ToDateTime(command.TowShifts2);
            if (StartShanbehTow > EndShanbehTow)
                EndShanbehTow = EndShanbehTow.AddDays(1);
            TimeSpan ShanbehTow = (EndShanbehTow - StartShanbehTow);
            SumTow = SumTow.Add(ShanbehTow);

            DateTime StartYekShanbehTow = Convert.ToDateTime(command.TowShifts1Yekshanbeh);
            DateTime EndYekShanbehTow = Convert.ToDateTime(command.TowShifts2Yekshanbeh);
            if (StartYekShanbehTow > EndYekShanbehTow)
                EndYekShanbehTow = EndYekShanbehTow.AddDays(1);
            TimeSpan YekShanbehTow = (EndYekShanbehTow - StartYekShanbehTow);
            SumTow = SumTow.Add(YekShanbehTow);

            DateTime StartDoShanbehTow = Convert.ToDateTime(command.TowShifts1Doshanbeh);
            DateTime EndDoShanbehTow = Convert.ToDateTime(command.TowShifts2Doshanbeh);
            if (StartDoShanbehTow > EndDoShanbehTow)
                EndDoShanbehTow = EndDoShanbehTow.AddDays(1);
            TimeSpan DoShanbehTow = (EndDoShanbehTow - StartDoShanbehTow);
            SumTow = SumTow.Add(DoShanbehTow);


            DateTime StartSehShanbehTow = Convert.ToDateTime(command.TowShifts1Seshanbeh);
            DateTime EndSehShanbehTow = Convert.ToDateTime(command.TowShifts2Seshanbeh);
            if (StartSehShanbehTow > EndSehShanbehTow)
                EndSehShanbehTow = EndSehShanbehTow.AddDays(1);
            TimeSpan SeShanbehTow = (EndSehShanbehTow - StartSehShanbehTow);
            SumTow = SumTow.Add(SeShanbehTow);

            DateTime StartCheharShanbehTow = Convert.ToDateTime(command.TowShifts1Cheharshanbeh);
            DateTime EndCheharShanbehTow = Convert.ToDateTime(command.TowShifts2Cheharshanbeh);
            if (StartCheharShanbehTow > EndCheharShanbehTow)
                EndCheharShanbehTow = EndCheharShanbehTow.AddDays(1);
            TimeSpan CheharShanbehTow = (EndCheharShanbehTow - StartCheharShanbehTow);
            SumTow = SumTow.Add(CheharShanbehTow);

            DateTime StartPanjShanbehTow = Convert.ToDateTime(command.TowShifts1Panjshanbeh);
            DateTime EndPanjShanbehTow = Convert.ToDateTime(command.TowShifts2Panjshanbeh);
            if (StartPanjShanbehTow > EndPanjShanbehTow)
                EndPanjShanbehTow = EndPanjShanbehTow.AddDays(1);
            TimeSpan PanjShanbehTow = (EndPanjShanbehTow - StartPanjShanbehTow);
            SumTow = SumTow.Add(PanjShanbehTow);

            DateTime StartJomehTow = Convert.ToDateTime(command.TowShifts1Jomeh);
            DateTime EndjomehTow = Convert.ToDateTime(command.TowShifts2Jomeh);
            if (StartJomehTow > EndjomehTow)
                EndjomehTow = EndjomehTow.AddDays(1);
            TimeSpan jomehTow = (EndjomehTow - StartJomehTow);
            SumTow = SumTow.Add(jomehTow);

            //SumTowHourses = (int)SumTow.TotalHours;


           
            if (command.ShiftWork == "5")
            {
                SumWorkeTime = "24 - 12";
            }
            else if (command.ShiftWork == "6")
            {
                SumWorkeTime = "24 - 24";
            }
            else if (command.ShiftWork == "7")
            {
                SumWorkeTime = "36 - 12";
            }
            else if (command.ShiftWork == "8")
            {
                SumWorkeTime = "48 - 24";
            }












            TimeSpan dailyFix = TimeSpan.Parse("07:20");





            TimeSpan notHolidays = new TimeSpan();
            TimeSpan jomeh = new TimeSpan();

            var sdate = command.ContarctStart.ToEnglishNumber();
            var edate = command.ContractEnd.ToEnglishNumber();
            var syear = Convert.ToInt32(sdate.Substring(0, 4));
            var smonth = Convert.ToInt32(sdate.Substring(5, 2));
            var sday = Convert.ToInt32(sdate.Substring(8, 2));

            var eyear = Convert.ToInt32(edate.Substring(0, 4));
            var emonth = Convert.ToInt32(edate.Substring(5, 2));
            var eday = Convert.ToInt32(edate.Substring(8, 2));

            var d1 = new PersianDateTime(syear, smonth, sday);
            var d2 = new PersianDateTime(eyear, emonth, eday);
            int i = 0, i1 = 0, i2 = 0, i3 = 0, i4 = 0, i5 = 0, i6 = 0;

            for (var da = d1; da <= d2; da.AddDays(1))
            {
                if (command.ShiftWork == "1" || command.ShiftWork == "2" || command.ShiftWork == "3" || command.ShiftWork == "4")
                {
                    if (command.shanbeh == true)
                    {

                        if (da.DayOfWeek == "شنبه")
                        {
                            var test = da.ToGregorianDateTime();
                            var checkHoliday = _holidayItemRepository.GetHoliday(test);
                            if (checkHoliday == false)
                            {
                                i += 1;
                                if (command.ShiftWork == "1")
                                {

                                    if (command.RestTime != null)
                                    {
                                        rest = TimeSpan.Parse($"{command.RestTime}:{00}");
                                    }

                                    starTimeSingel1 = Convert.ToDateTime(command.SingleShift1);
                                    endTimeSingel2 = Convert.ToDateTime(command.SingleShift2);
                                    if (starTimeSingel1 > endTimeSingel2)
                                    {
                                        overNight = true;
                                        endTimeSingel2 = endTimeSingel2.AddDays(1);

                                    }

                                    TimeSpan singleSpan1 = (endTimeSingel2 - starTimeSingel1);
                                    if (command.RestTime != "0")
                                        singleSpan1 = singleSpan1.Subtract(rest);

                                    notHolidays = notHolidays.Add(singleSpan1);
                                    TimeSpan Over22Compute = Over22Check(starTimeSingel1, endTimeSingel2);
                                    //Over22Compute = Over22Compute.Subtract(rest);
                                    Over22 = Over22.Add(Over22Compute);
                                }
                                else if (command.ShiftWork == "2")
                                {
                                    starTimeSingel1 = Convert.ToDateTime(command.SingleShift1);
                                    endTimeSingel2 = Convert.ToDateTime(command.SingleShift2);
                                    startTimeTowSh1 = Convert.ToDateTime(command.TowShifts1);
                                    endTimeTowSh2 = Convert.ToDateTime(command.TowShifts2);
                                    if (starTimeSingel1 > endTimeSingel2)
                                    {
                                        overNight = true;
                                        endTimeSingel2 = endTimeSingel2.AddDays(1);

                                    }
                                    if (startTimeTowSh1 > endTimeTowSh2)
                                    {
                                        overNight = true;
                                        endTimeTowSh2 = endTimeTowSh2.AddDays(1);

                                    }
                                    TimeSpan singleSpanTow1 = (endTimeSingel2 - starTimeSingel1);
                                    TimeSpan singleSpanTow2 = (endTimeTowSh2 - startTimeTowSh1);
                                    notHolidays = notHolidays.Add(singleSpanTow1);
                                    notHolidays = notHolidays.Add(singleSpanTow2);

                                    TimeSpan Over22ComputeTow1 = Over22Check(starTimeSingel1, endTimeSingel2);
                                    Over22 = Over22.Add(Over22ComputeTow1);
                                    TimeSpan Over22ComputeTow2 = Over22Check(startTimeTowSh1, endTimeTowSh2);
                                    Over22 = Over22.Add(Over22ComputeTow2);
                                }




                            }


                        }
                    }
                    if (command.yekshanbeh == true)
                    {

                        if (da.DayOfWeek == "یکشنبه")
                        {
                            var test = da.ToGregorianDateTime();
                            var checkHoliday = _holidayItemRepository.GetHoliday(test);
                            if (checkHoliday == false)
                            {
                                i1 += 1;

                                if (command.ShiftWork == "1")
                                {
                                    if (command.RestTimeYekshanbeh != null)
                                    {
                                        rest = TimeSpan.Parse($"{command.RestTimeYekshanbeh}:{00}");
                                    }

                                    starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Yekshanbeh);
                                    endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Yekshanbeh);
                                    if (starTimeSingel1 > endTimeSingel2)
                                    {
                                        overNight = true;
                                        endTimeSingel2 = endTimeSingel2.AddDays(1);

                                    }

                                    TimeSpan singleSpan1 = (endTimeSingel2 - starTimeSingel1);
                                    if (command.RestTimeYekshanbeh != "0")
                                        singleSpan1 = singleSpan1.Subtract(rest);

                                    notHolidays = notHolidays.Add(singleSpan1);
                                    
                                    TimeSpan Over22Compute = Over22Check(starTimeSingel1, endTimeSingel2);
                                    //Over22Compute = Over22Compute.Subtract(rest);
                                    Over22 = Over22.Add(Over22Compute);
                                }

                                else if (command.ShiftWork == "2")
                                {
                                    starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Yekshanbeh);
                                    endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Yekshanbeh);
                                    startTimeTowSh1 = Convert.ToDateTime(command.TowShifts1Yekshanbeh);
                                    endTimeTowSh2 = Convert.ToDateTime(command.TowShifts2Yekshanbeh);
                                    if (starTimeSingel1 > endTimeSingel2)
                                    {
                                        overNight = true;
                                        endTimeSingel2 = endTimeSingel2.AddDays(1);

                                    }

                                    if (startTimeTowSh1 > endTimeTowSh2)
                                    {
                                        overNight = true;
                                        endTimeTowSh2 = endTimeTowSh2.AddDays(1);

                                    }

                                    TimeSpan singleSpanTow1 = (endTimeSingel2 - starTimeSingel1);
                                    TimeSpan singleSpanTow2 = (endTimeTowSh2 - startTimeTowSh1);
                                    notHolidays = notHolidays.Add(singleSpanTow1);
                                    notHolidays = notHolidays.Add(singleSpanTow2);

                                    TimeSpan Over22ComputeTow1 = Over22Check(starTimeSingel1, endTimeSingel2);
                                    Over22 = Over22.Add(Over22ComputeTow1);
                                    TimeSpan Over22ComputeTow2 = Over22Check(startTimeTowSh1, endTimeTowSh2);
                                    Over22 = Over22.Add(Over22ComputeTow2);

                                }
                            }


                        }
                    }
                    if (command.doshanbeh == true)
                    {
                        if (da.DayOfWeek == "دوشنبه")
                        {
                            var test = da.ToGregorianDateTime();
                            var checkHoliday = _holidayItemRepository.GetHoliday(test);
                            if (checkHoliday == false)
                            {
                                i2 += 1;
                                switch (command.ShiftWork)
                                {
                                    case "1":
                                        if (command.RestTimeDoshanbeh != null)
                                        {
                                            rest = TimeSpan.Parse($"{command.RestTimeDoshanbeh}:{00}");
                                        }
                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Doshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Doshanbeh);
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);

                                        }
                                        TimeSpan singleSpan1 = (endTimeSingel2 - starTimeSingel1);
                                        if (command.RestTimeDoshanbeh != "0")
                                            singleSpan1 = singleSpan1.Subtract(rest);

                                        notHolidays = notHolidays.Add(singleSpan1);
                                       
                                        TimeSpan Over22Compute = Over22Check(starTimeSingel1, endTimeSingel2);
                                       
                                        Over22 = Over22.Add(Over22Compute);
                                        break;

                                    case "2":
                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Doshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Doshanbeh);
                                        startTimeTowSh1 = Convert.ToDateTime(command.TowShifts1Doshanbeh);
                                        endTimeTowSh2 = Convert.ToDateTime(command.TowShifts2Doshanbeh);
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);

                                        }
                                        if (startTimeTowSh1 > endTimeTowSh2)
                                        {
                                            overNight = true;
                                            endTimeTowSh2 = endTimeTowSh2.AddDays(1);

                                        }
                                        TimeSpan singleSpanTow1 = (endTimeSingel2 - starTimeSingel1);
                                        TimeSpan singleSpanTow2 = (endTimeTowSh2 - startTimeTowSh1);
                                        notHolidays = notHolidays.Add(singleSpanTow1);
                                        notHolidays = notHolidays.Add(singleSpanTow2);

                                        TimeSpan Over22ComputeTow1 = Over22Check(starTimeSingel1, endTimeSingel2);
                                        Over22 = Over22.Add(Over22ComputeTow1);
                                        TimeSpan Over22ComputeTow2 = Over22Check(startTimeTowSh1, endTimeTowSh2);
                                        Over22 = Over22.Add(Over22ComputeTow2);
                                        break;
                                }
                            }


                        }
                    }
                    if (command.seshanbeh == true)
                    {
                        if (da.DayOfWeek == "سه شنبه")
                        {
                            var test = da.ToGregorianDateTime();
                            var checkHoliday = _holidayItemRepository.GetHoliday(test);
                            if (checkHoliday == false)
                            {
                                i3 += 1;
                                switch (command.ShiftWork)
                                {
                                    case "1":
                                        if (command.RestTimeSeshanbeh != null)
                                        {
                                            rest = TimeSpan.Parse($"{command.RestTimeSeshanbeh}:{00}");
                                        }

                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Seshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Seshanbeh);
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);

                                        }
                                        TimeSpan singleSpan1 = (endTimeSingel2 - starTimeSingel1);
                                        if (command.RestTimeSeshanbeh != "0")
                                            singleSpan1 = singleSpan1.Subtract(rest);

                                        notHolidays = notHolidays.Add(singleSpan1);
                                       
                                        TimeSpan Over22Compute = Over22Check(starTimeSingel1, endTimeSingel2);
                                        Over22 = Over22.Add(Over22Compute);
                                        break;

                                    case "2":
                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Seshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Seshanbeh);
                                        startTimeTowSh1 = Convert.ToDateTime(command.TowShifts1Seshanbeh);
                                        endTimeTowSh2 = Convert.ToDateTime(command.TowShifts2Seshanbeh);
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);

                                        }
                                        if (startTimeTowSh1 > endTimeTowSh2)
                                        {
                                            overNight = true;
                                            endTimeTowSh2 = endTimeTowSh2.AddDays(1);

                                        }
                                        TimeSpan singleSpanTow1 = (endTimeSingel2 - starTimeSingel1);
                                        TimeSpan singleSpanTow2 = (endTimeTowSh2 - startTimeTowSh1);
                                        notHolidays = notHolidays.Add(singleSpanTow1);
                                        notHolidays = notHolidays.Add(singleSpanTow2);

                                        TimeSpan Over22ComputeTow1 = Over22Check(starTimeSingel1, endTimeSingel2);
                                        Over22 = Over22.Add(Over22ComputeTow1);
                                        TimeSpan Over22ComputeTow2 = Over22Check(startTimeTowSh1, endTimeTowSh2);
                                        Over22 = Over22.Add(Over22ComputeTow2);
                                        break;
                                }
                            }


                        }
                    }
                    if (command.cheharshanbeh == true)
                    {
                        if (da.DayOfWeek == "چهارشنبه")
                        {
                            var test = da.ToGregorianDateTime();
                            var checkHoliday = _holidayItemRepository.GetHoliday(test);
                            if (checkHoliday == false)
                            {
                                i4 += 1;
                                switch (command.ShiftWork)
                                {
                                    case "1":
                                        if (command.RestTimeCheharshanbeh != null)
                                        {
                                            rest = TimeSpan.Parse($"{command.RestTimeCheharshanbeh}:{00}");
                                        }
                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Cheharshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Cheharshanbeh);
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);

                                        }
                                        TimeSpan singleSpan1 = (endTimeSingel2 - starTimeSingel1);
                                        if (command.RestTimeCheharshanbeh != "0")
                                            singleSpan1 = singleSpan1.Subtract(rest);

                                        notHolidays = notHolidays.Add(singleSpan1);
                                     
                                        TimeSpan Over22Compute = Over22Check(starTimeSingel1, endTimeSingel2);
                                        Over22 = Over22.Add(Over22Compute);
                                        break;

                                    case "2":
                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Cheharshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Cheharshanbeh);
                                        startTimeTowSh1 = Convert.ToDateTime(command.TowShifts1Cheharshanbeh);
                                        endTimeTowSh2 = Convert.ToDateTime(command.TowShifts2Cheharshanbeh);
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);

                                        }
                                        if (startTimeTowSh1 > endTimeTowSh2)
                                        {
                                            overNight = true;
                                            endTimeTowSh2 = endTimeTowSh2.AddDays(1);

                                        }
                                        TimeSpan singleSpanTow1 = (endTimeSingel2 - starTimeSingel1);
                                        TimeSpan singleSpanTow2 = (endTimeTowSh2 - startTimeTowSh1);
                                        notHolidays = notHolidays.Add(singleSpanTow1);
                                        notHolidays = notHolidays.Add(singleSpanTow2);

                                        TimeSpan Over22ComputeTow1 = Over22Check(starTimeSingel1, endTimeSingel2);
                                        Over22 = Over22.Add(Over22ComputeTow1);
                                        TimeSpan Over22ComputeTow2 = Over22Check(startTimeTowSh1, endTimeTowSh2);
                                        Over22 = Over22.Add(Over22ComputeTow2);
                                        break;
                                }
                            }


                        }
                    }
                    if (command.pangshanbeh == true)
                    {
                        if (da.DayOfWeek == "پنج شنبه")
                        {
                            var test = da.ToGregorianDateTime();
                            var checkHoliday = _holidayItemRepository.GetHoliday(test);
                            if (checkHoliday == false)
                            {
                                i5 += 1;
                                switch (command.ShiftWork)
                                {
                                    case "1":
                                        if (command.RestTimePanjshanbeh != null)
                                        {
                                            rest = TimeSpan.Parse($"{command.RestTimePanjshanbeh}:{00}");
                                        }
                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Panjshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Panjshanbeh);
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            singleOver24 = (endTimeSingel2 - singleShiftOver24);
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);


                                        }
                                        TimeSpan singleSpan1 = (endTimeSingel2 - starTimeSingel1);
                                        if (command.RestTimePanjshanbeh != "0")
                                            singleSpan1 = singleSpan1.Subtract(rest);

                                        singleSpan1 = singleSpan1.Subtract(singleOver24);
                                        jomeh = jomeh.Add(singleOver24);
                                        notHolidays = notHolidays.Add(singleSpan1);
                                       
                                        TimeSpan Over22Compute = Over22Check(starTimeSingel1, endTimeSingel2);
                                        Over22 = Over22.Add(Over22Compute);
                                        break;

                                    case "2":
                                        starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Panjshanbeh);
                                        endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Panjshanbeh);
                                        startTimeTowSh1 = Convert.ToDateTime(command.TowShifts1Panjshanbeh);
                                        endTimeTowSh2 = Convert.ToDateTime(command.TowShifts2Panjshanbeh);
                                        TimeSpan singleOver24Tow = new TimeSpan();
                                        if (starTimeSingel1 > endTimeSingel2)
                                        {
                                            overNight = true;
                                            singleOver24 = (endTimeSingel2 - singleShiftOver24);
                                            endTimeSingel2 = endTimeSingel2.AddDays(1);

                                        }
                                        if (startTimeTowSh1 > endTimeTowSh2)
                                        {
                                            overNight = true;
                                            singleOver24Tow = (endTimeTowSh2 - singleShiftOver24);
                                            endTimeTowSh2 = endTimeTowSh2.AddDays(1);

                                        }
                                        TimeSpan singleSpanTow1 = (endTimeSingel2 - starTimeSingel1);
                                        TimeSpan singleSpanTow2 = (endTimeTowSh2 - startTimeTowSh1);


                                        singleSpanTow1 = singleSpanTow1.Subtract(singleOver24);
                                        singleSpanTow2 = singleSpanTow2.Subtract(singleOver24Tow);

                                        jomeh = jomeh.Add(singleOver24);
                                        jomeh = jomeh.Add(singleOver24Tow);

                                        notHolidays = notHolidays.Add(singleSpanTow1);
                                        notHolidays = notHolidays.Add(singleSpanTow2);

                                        TimeSpan Over22ComputeTow1 = Over22Check(starTimeSingel1, endTimeSingel2);
                                        Over22 = Over22.Add(Over22ComputeTow1);
                                        TimeSpan Over22ComputeTow2 = Over22Check(startTimeTowSh1, endTimeTowSh2);
                                        Over22 = Over22.Add(Over22ComputeTow2);
                                        break;
                                }
                            }


                        }
                    }

                    if (command.jomeh == true)
                    {
                        if (da.DayOfWeek == "جمعه")
                        {
                            i6 += 1;
                            switch (command.ShiftWork)
                            {
                                case "1":
                                    if (command.RestTimeJomeh != null)
                                    {
                                        rest = TimeSpan.Parse($"{command.RestTimeJomeh}:{00}");
                                    }
                                    starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Jomeh);
                                    endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Jomeh);
                                    if (starTimeSingel1 > endTimeSingel2)
                                    {
                                        overNight = true;
                                        endTimeSingel2 = endTimeSingel2.AddDays(1);

                                    }
                                    TimeSpan singleSpan1 = (endTimeSingel2 - starTimeSingel1);
                                    if (command.RestTimeJomeh != "0")
                                        singleSpan1 = singleSpan1.Subtract(rest);

                                    jomeh = jomeh.Add(singleSpan1);
                                   
                                    TimeSpan Over22Compute = Over22Check(starTimeSingel1, endTimeSingel2);
                                    Over22 = Over22.Add(Over22Compute);
                                    break;

                                case "2":
                                    starTimeSingel1 = Convert.ToDateTime(command.SingleShift1Jomeh);
                                    endTimeSingel2 = Convert.ToDateTime(command.SingleShift2Jomeh);
                                    startTimeTowSh1 = Convert.ToDateTime(command.TowShifts1Jomeh);
                                    endTimeTowSh2 = Convert.ToDateTime(command.TowShifts2Jomeh);
                                    if (starTimeSingel1 > endTimeSingel2)
                                    {
                                        overNight = true;
                                        endTimeSingel2 = endTimeSingel2.AddDays(1);

                                    }
                                    if (startTimeTowSh1 > endTimeTowSh2)
                                    {
                                        overNight = true;
                                        endTimeTowSh2 = endTimeTowSh2.AddDays(1);

                                    }
                                    TimeSpan singleSpanTow1 = (endTimeSingel2 - starTimeSingel1);
                                    TimeSpan singleSpanTow2 = (endTimeTowSh2 - startTimeTowSh1);
                                    jomeh = jomeh.Add(singleSpanTow1);
                                    jomeh = jomeh.Add(singleSpanTow2);

                                    TimeSpan Over22ComputeTow1 = Over22Check(starTimeSingel1, endTimeSingel2);
                                    Over22 = Over22.Add(Over22ComputeTow1);
                                    TimeSpan Over22ComputeTow2 = Over22Check(startTimeTowSh1, endTimeTowSh2);
                                    Over22 = Over22.Add(Over22ComputeTow2);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        i6 = 0;
                    }
                }


            }

            int SumComplexDays = 0;
            if (command.ShiftWork == "5")
            {
                var sdate2 = command.ContarctStart.ToEnglishNumber();
                var edate2 = command.ContractEnd.ToEnglishNumber();
                var syear2 = Convert.ToInt32(sdate.Substring(0, 4));
                var smonth2 = Convert.ToInt32(sdate.Substring(5, 2));
                var sday2 = Convert.ToInt32(sdate.Substring(8, 2));

                var eyear2 = Convert.ToInt32(edate.Substring(0, 4));
                var emonth2 = Convert.ToInt32(edate.Substring(5, 2));
                var eday2 = Convert.ToInt32(edate.Substring(8, 2));

                var d1b = new PersianDateTime(syear2, smonth2, sday2);
                var d2b = new PersianDateTime(eyear2, emonth2, eday2, 23, 59);

                var start = Convert.ToDateTime(command.Start1224);
                var end = Convert.ToDateTime(command.End1224);


                var sh = start.Hour;
                var sm = start.Minute;
                var eh = end.Hour;
                var em = end.Minute;
                var startDateAndTime = new PersianDateTime(syear2, smonth2, sday2, sh, sm);
                var endDateTime = new PersianDateTime(syear2, smonth2, sday2, eh, em);

                end = endDateTime.ToGregorianDateTime();




                for (var da2 = startDateAndTime; da2 <= d2b; da2.AddHours(36))
                {

                    if (da2.DayOfWeek == "جمعه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);

                        TimeSpan singleSpanTow1 = new TimeSpan();

                        i6 += 1;
                        if (start.Date < end.Date)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);

                            singleSpanTow1 = (end - start);
                            singleSpanTow1 = singleSpanTow1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleOver24);
                            jomeh = jomeh.Add(singleSpanTow1);
                            i += 1;


                        }
                        else
                        {
                            singleSpanTow1 = (end - start);
                            jomeh = jomeh.Add(singleSpanTow1);

                        }
                        TimeSpan Over22Computer = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computer);

                        TimeSpan endCal = (end - start);
                        var NextStart = start.AddHours(36);
                        end = NextStart.Add(endCal);
                    }
                    else if (da2.DayOfWeek == "پنج شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = new TimeSpan();
                        i5 += 1;
                        if (start.Date < end.Date && start.Day != end.Day)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);


                            jomeh = jomeh.Add(singleOver24);

                            i6 += 1;

                            singleSpan1 = (end - start);
                            singleSpan1 = singleSpan1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleSpan1);

                        }
                        else
                        {
                            singleSpan1 = (end - start);
                            notHolidays = notHolidays.Add(singleSpan1);
                        }




                        TimeSpan Over22Computer2 = Over22Complex(start, end);


                        Over22 = Over22.Add(Over22Computer2);


                        TimeSpan endCal = (end - start);
                        var NextStart = start.AddHours(36);
                        end = NextStart.Add(endCal);
                    }
                    else if (da2.DayOfWeek == "شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i += 1;
                        var NextStart = start.AddHours(36);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "یکشنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i1 += 1;

                        var NextStart = start.AddHours(36);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "دوشنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i2 += 1;

                        var NextStart = start.AddHours(36);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "سه شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);

                        i3 += 1;
                        var NextStart = start.AddHours(36);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "چهارشنبه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i4 += 1;
                        var NextStart = start.AddHours(36);
                        end = NextStart.Add(singleSpan1);
                    }




                }


                for (var daa = d1b; daa <= d2b; daa.AddDays(1))
                {
                    if (daa.DayOfWeek != "جمعه")
                    {
                        var test = daa.ToGregorianDateTime();
                        var checkHoliday = _holidayItemRepository.GetHoliday(test);
                        if (checkHoliday == false)
                        {
                            SumComplexDays += 1;
                        }

                    }
                }

            }

            if (command.ShiftWork == "6")
            {
                var sdate2 = command.ContarctStart.ToEnglishNumber();
                var edate2 = command.ContractEnd.ToEnglishNumber();
                var syear2 = Convert.ToInt32(sdate.Substring(0, 4));
                var smonth2 = Convert.ToInt32(sdate.Substring(5, 2));
                var sday2 = Convert.ToInt32(sdate.Substring(8, 2));

                var eyear2 = Convert.ToInt32(edate.Substring(0, 4));
                var emonth2 = Convert.ToInt32(edate.Substring(5, 2));
                var eday2 = Convert.ToInt32(edate.Substring(8, 2));

                var d1b = new PersianDateTime(syear2, smonth2, sday2);
                var d2b = new PersianDateTime(eyear2, emonth2, eday2, 23, 59);

                var start = Convert.ToDateTime(command.Start2424);
                var end = Convert.ToDateTime(command.End2424);


                var sh = start.Hour;
                var sm = start.Minute;
                var eh = end.Hour;
                var em = end.Minute;
                var startDateAndTime = new PersianDateTime(syear2, smonth2, sday2, sh, sm);
                var endDateTime = new PersianDateTime(syear2, smonth2, sday2, eh, em);
                //if (start > end)
                //{

                //    endDateTime.AddDays(1);
                //}

                endDateTime.AddDays(1);
                end = endDateTime.ToGregorianDateTime();


                for (var da2 = startDateAndTime; da2 <= d2b; da2.AddHours(48))
                {

                    if (da2.DayOfWeek == "جمعه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpanTow1 = new TimeSpan();
                        TimeSpan WorkHours = (end - start);
                        i6 += 1;
                        if (start.Date < end.Date)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);

                            singleSpanTow1 = (end - start);
                            singleSpanTow1 = singleSpanTow1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleOver24);
                            jomeh = jomeh.Add(singleSpanTow1);
                            i += 1;


                        }
                        else
                        {
                            singleSpanTow1 = (end - start);
                            jomeh = jomeh.Add(singleSpanTow1);

                        }
                        TimeSpan Over22Computer = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computer);

                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(WorkHours);
                    }
                    else if (da2.DayOfWeek == "پنج شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        TimeSpan singleSpan1 = new TimeSpan();
                        TimeSpan WorkHours = (end - start);
                        i5 += 1;
                        if (start.Date < end.Date && start.Day != end.Day)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);


                            jomeh = jomeh.Add(singleOver24);

                            i6 += 1;

                            singleSpan1 = (end - start);
                            singleSpan1 = singleSpan1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleSpan1);

                        }
                        else
                        {
                            singleSpan1 = (end - start);
                            notHolidays = notHolidays.Add(singleSpan1);
                        }




                        TimeSpan Over22Computer2 = Over22Complex2424(start, end);


                        Over22 = Over22.Add(Over22Computer2);



                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(WorkHours);
                    }
                    else if (da2.DayOfWeek == "شنبه")
                    {
                        start = da2.ToGregorianDateTime();


                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i += 1;
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "یکشنبه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i1 += 1;

                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "دوشنبه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i2 += 1;

                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "سه شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);

                        i3 += 1;
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "چهارشنبه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i4 += 1;
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);
                    }




                }


                for (var daa = d1b; daa <= d2b; daa.AddDays(1))
                {

                    if (daa.DayOfWeek != "جمعه")
                    {
                        var test = daa.ToGregorianDateTime();
                        var checkHoliday = _holidayItemRepository.GetHoliday(test);
                        if (checkHoliday == false)
                        {
                            SumComplexDays += 1;
                        }

                    }

                }

            }
            if (command.ShiftWork == "7")
            {
                var sdate2 = command.ContarctStart.ToEnglishNumber();
                var edate2 = command.ContractEnd.ToEnglishNumber();
                var syear2 = Convert.ToInt32(sdate.Substring(0, 4));
                var smonth2 = Convert.ToInt32(sdate.Substring(5, 2));
                var sday2 = Convert.ToInt32(sdate.Substring(8, 2));

                var eyear2 = Convert.ToInt32(edate.Substring(0, 4));
                var emonth2 = Convert.ToInt32(edate.Substring(5, 2));
                var eday2 = Convert.ToInt32(edate.Substring(8, 2));

                var d1b = new PersianDateTime(syear2, smonth2, sday2);
                var d2b = new PersianDateTime(eyear2, emonth2, eday2, 23, 59);

                var start = Convert.ToDateTime(command.Start1236);
                var end = Convert.ToDateTime(command.End1236);


                var sh = start.Hour;
                var sm = start.Minute;
                var eh = end.Hour;
                var em = end.Minute;
                var startDateAndTime = new PersianDateTime(syear2, smonth2, sday2, sh, sm);
                var endDateTime = new PersianDateTime(syear2, smonth2, sday2, eh, em);
                //if (start > end)
                //{

                //    endDateTime.AddDays(1);
                //}

                //endDateTime.AddDays(1);
                end = endDateTime.ToGregorianDateTime();


                for (var da2 = startDateAndTime; da2 <= d2b; da2.AddHours(48))
                {

                    if (da2.DayOfWeek == "جمعه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);

                        TimeSpan singleSpanTow1 = new TimeSpan();

                        i6 += 1;
                        if (start.Date < end.Date)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);

                            singleSpanTow1 = (end - start);
                            singleSpanTow1 = singleSpanTow1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleOver24);
                            jomeh = jomeh.Add(singleSpanTow1);
                            i += 1;


                        }
                        else
                        {
                            singleSpanTow1 = (end - start);
                            jomeh = jomeh.Add(singleSpanTow1);

                        }
                        TimeSpan Over22Computer = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computer);

                        TimeSpan WorkHours = (end - start);
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(WorkHours);
                    }
                    else if (da2.DayOfWeek == "پنج شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = new TimeSpan();

                        i5 += 1;
                        if (start.Date < end.Date && start.Day != end.Day)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);


                            jomeh = jomeh.Add(singleOver24);

                            i6 += 1;

                            singleSpan1 = (end - start);
                            singleSpan1 = singleSpan1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleSpan1);

                        }
                        else
                        {
                            singleSpan1 = (end - start);
                            notHolidays = notHolidays.Add(singleSpan1);
                        }




                        TimeSpan Over22Computer2 = Over22Complex(start, end);


                        Over22 = Over22.Add(Over22Computer2);


                        TimeSpan WorkHours = (end - start);
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(WorkHours);
                    }
                    else if (da2.DayOfWeek == "شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i += 1;
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "یکشنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i1 += 1;

                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "دوشنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i2 += 1;

                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "سه شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);

                        i3 += 1;
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "چهارشنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        if (start.Date == end.Date && start.TimeOfDay > end.TimeOfDay)
                            end = end.AddDays(1);
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i4 += 1;
                        var NextStart = start.AddHours(48);
                        end = NextStart.Add(singleSpan1);
                    }




                }


                for (var daa = d1b; daa <= d2b; daa.AddDays(1))
                {
                    if (daa.DayOfWeek != "جمعه")
                    {
                        var test = daa.ToGregorianDateTime();
                        var checkHoliday = _holidayItemRepository.GetHoliday(test);
                        if (checkHoliday == false)
                        {
                            SumComplexDays += 1;
                        }

                    }
                }

            }
            if (command.ShiftWork == "8")
            {
                var sdate2 = command.ContarctStart.ToEnglishNumber();
                var edate2 = command.ContractEnd.ToEnglishNumber();
                var syear2 = Convert.ToInt32(sdate.Substring(0, 4));
                var smonth2 = Convert.ToInt32(sdate.Substring(5, 2));
                var sday2 = Convert.ToInt32(sdate.Substring(8, 2));

                var eyear2 = Convert.ToInt32(edate.Substring(0, 4));
                var emonth2 = Convert.ToInt32(edate.Substring(5, 2));
                var eday2 = Convert.ToInt32(edate.Substring(8, 2));

                var d1b = new PersianDateTime(syear2, smonth2, sday2);
                var d2b = new PersianDateTime(eyear2, emonth2, eday2, 23, 59);

                var start = Convert.ToDateTime(command.Start2448);
                var end = Convert.ToDateTime(command.End2448);


                var sh = start.Hour;
                var sm = start.Minute;
                var eh = end.Hour;
                var em = end.Minute;
                var startDateAndTime = new PersianDateTime(syear2, smonth2, sday2, sh, sm);
                var endDateTime = new PersianDateTime(syear2, smonth2, sday2, eh, em);
                //if (start > end)
                //{

                //    endDateTime.AddDays(1);
                //}


                end = endDateTime.ToGregorianDateTime();
                end = end.AddDays(1);


                for (var da2 = startDateAndTime; da2 <= d2b; da2.AddHours(72))
                {

                    if (da2.DayOfWeek == "جمعه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpanTow1 = new TimeSpan();

                        i6 += 1;
                        if (start.Date < end.Date)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);

                            singleSpanTow1 = (end - start);
                            singleSpanTow1 = singleSpanTow1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleOver24);
                            jomeh = jomeh.Add(singleSpanTow1);
                            i += 1;


                        }
                        else
                        {
                            singleSpanTow1 = (end - start);
                            jomeh = jomeh.Add(singleSpanTow1);

                        }
                        TimeSpan Over22Computer = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computer);

                        TimeSpan WorkHours = (end - start);
                        var NextStart = start.AddHours(72);
                        end = NextStart.Add(WorkHours);
                    }
                    else if (da2.DayOfWeek == "پنج شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        TimeSpan singleSpan1 = new TimeSpan();

                        i5 += 1;
                        if (start.Date < end.Date && start.Day != end.Day)
                        {

                            overNight = true;
                            var over24 = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                            singleOver24 = (end - over24);


                            jomeh = jomeh.Add(singleOver24);

                            i6 += 1;

                            singleSpan1 = (end - start);
                            singleSpan1 = singleSpan1.Subtract(singleOver24);
                            notHolidays = notHolidays.Add(singleSpan1);

                        }
                        else
                        {
                            singleSpan1 = (end - start);
                            notHolidays = notHolidays.Add(singleSpan1);
                        }




                        TimeSpan Over22Computer2 = Over22Complex2424(start, end);


                        Over22 = Over22.Add(Over22Computer2);


                        TimeSpan WorkHours = (end - start);
                        var NextStart = start.AddHours(72);
                        end = NextStart.Add(WorkHours);
                    }
                    else if (da2.DayOfWeek == "شنبه")
                    {
                        start = da2.ToGregorianDateTime();


                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i += 1;
                        var NextStart = start.AddHours(72);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "یکشنبه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i1 += 1;

                        var NextStart = start.AddHours(72);
                        end = NextStart.Add(singleSpan1);
                    }
                    else if (da2.DayOfWeek == "دوشنبه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i2 += 1;

                        var NextStart = start.AddHours(72);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "سه شنبه")
                    {
                        start = da2.ToGregorianDateTime();
                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);

                        i3 += 1;
                        var NextStart = start.AddHours(72);
                        end = NextStart.Add(singleSpan1);

                    }
                    else if (da2.DayOfWeek == "چهارشنبه")
                    {
                        start = da2.ToGregorianDateTime();

                        TimeSpan singleSpan1 = (end - start);
                        notHolidays = notHolidays.Add(singleSpan1);
                        TimeSpan Over22Computing = Over22Complex2424(start, end);
                        Over22 = Over22.Add(Over22Computing);


                        i4 += 1;
                        var NextStart = start.AddHours(72);
                        end = NextStart.Add(singleSpan1);
                    }




                }


                for (var daa = d1b; daa <= d2b; daa.AddDays(1))
                {
                    if (daa.DayOfWeek != "جمعه")
                    {
                        var test = daa.ToGregorianDateTime();
                        var checkHoliday = _holidayItemRepository.GetHoliday(test);
                        if (checkHoliday == false)
                        {
                            SumComplexDays += 1;
                        }

                    }
                }

            }

            int sumDays = i + i1 + i2 + i3 + i4 + i5 + i6;
            int holidaysCount = i6;
            int notHolidaysCount = i + i1 + i2 + i3 + i4 + i5;
            TimeSpan ComplexFix = dailyFix.Multiply(SumComplexDays);

            dailyFix = dailyFix.Multiply(notHolidaysCount);

            Notholiday = notHolidaysCount.ToString();
            Holidays = holidaysCount.ToString();

            var AllDaysCount = notHolidaysCount + holidaysCount;
            TimeSpan jomeh2 = new TimeSpan();

            TimeSpan notHolidays2 = new TimeSpan();
            TimeSpan Mandatory = new TimeSpan();




            notHolidays = notHolidays.Add(jomeh);

            var workingDaysH = (int)notHolidays.TotalHours;
            var workingDaysM = notHolidays.TotalMinutes % 60;

            notHolidays2 = notHolidays2.Add(jomeh2);


            var SumNotHolidays = notHolidays.Add(notHolidays2);
            var SumNotHolidaysHours = (int)SumNotHolidays.TotalHours;
            var SumNotHolidaysMinuts = SumNotHolidays.Minutes % 60;

            var SumHolidays = jomeh.Add(jomeh2);
            var SumHolidaysHours = (int)SumHolidays.TotalHours;
            var SumHolidaysMinuts = SumHolidays.Minutes % 60;

            var totalHoursShift1 = notHolidays;
            var totalHoursShift1And2 = SumNotHolidays;
            var GetWorkStartDate = command.GetWorkDateHide.ToEnglishNumber();
            var GetWorkEndDate = command.ContractEnd.ToEnglishNumber();
            var styear = Convert.ToInt32(GetWorkStartDate.Substring(0, 4));
            var stmonth = Convert.ToInt32(GetWorkStartDate.Substring(5, 2));
            var stday = Convert.ToInt32(GetWorkStartDate.Substring(8, 2));

            var edyear = Convert.ToInt32(GetWorkEndDate.Substring(0, 4));
            var edmonth = Convert.ToInt32(GetWorkEndDate.Substring(5, 2));
            var edday = Convert.ToInt32(GetWorkEndDate.Substring(8, 2));
            var startDate = command.GetWorkDateHide.ToGeorgianDateTime();
            var endDate = command.ContractEnd.ToGeorgianDateTime();
            string dayliFee = "خطای تاریخ";
            if (styear >= 1370)
            {
                var searchModel = new LeftWorkSearchModel()
                {
                    EmployeeId = command.EmployeeId,
                    WorkshopId = command.WorkshopIds,
                  
                };

                var leftworkList = _leftWorkRepository.search(searchModel);
                if (leftworkList == null)
                    leftworkList = new List<LeftWorkViewModel>();
                var ContractStart = command.ContarctStart.ToGeorgianDateTime();
                dayliFee = _yearlySalaryRepository.DayliFeeComputing(startDate,ContractStart, endDate, command.EmployeeId, command.WorkshopIds, leftworkList);
            }

            var ConsumableItems = _yearlySalaryRepository.ConsumableItems(endDate);
            var HousingAllowance = _yearlySalaryRepository.HousingAllowance(endDate);

            var familyAllowance = _yearlySalaryRepository.FamilyAllowance(command.EmployeeId, endDate);

            TimeSpan dailyFixx = TimeSpan.Parse("07:20");
            var fix44 = dailyFixx.Multiply(6);

            TimeSpan divideNum = TimeSpan.Parse("06:00");

            if (sday == 1)
            {
                var start = command.ContarctStart.ToEnglishNumber();
                var end = command.ContractEnd.ToEnglishNumber();
                var FindeEnd = start.FindeEndOfMonth();


                if (FindeEnd == end)
                {
                    AllDaysCount = 30;
                }
            }


            if (command.ShiftWork == "1")
            {
               
                if (SumSingle < fix44)
                {

                    var dividTo6Days = SumSingle.Divide(divideNum);

                    var DailyFeeStrNumber = dayliFee.ToDoubleMoney();
                    var DailyFeeNumberType = Convert.ToDouble(DailyFeeStrNumber);

                    var HousingAllowonceStrNumber = HousingAllowance.ToDoubleMoney();
                    var HousingAllowonceNumberType = Convert.ToDouble(HousingAllowonceStrNumber);

                    var ConsumableItemsStrNumber = ConsumableItems.ToDoubleMoney();
                    var ConsumableItemsNumberType = Convert.ToDouble(ConsumableItemsStrNumber);

                    var familyAllowanceStrNumber = familyAllowance.ToDoubleMoney();
                    var familyAllowanceNumberType = Convert.ToDouble(familyAllowanceStrNumber);

                    var dailyStep1 = DailyFeeNumberType / 7.33;
                    var dailyStep2 = dailyStep1 * dividTo6Days;

                    dayliFee = dailyStep2.ToMoney();

                    var HousingStep1 = HousingAllowonceNumberType / 30;
                    var HousingStep2 = HousingStep1 / 7.33;
                    var HousingStep3 = HousingStep2 * dividTo6Days;
                    var HousingStep4 = HousingStep3 * AllDaysCount;
                    HousingAllowance = HousingStep4.ToMoney();

                    var consumableItemsStep1 = ConsumableItemsNumberType / 30;
                    var consumableItemsStep2 = consumableItemsStep1 / 7.33;
                    var consumableItemsStep3 = consumableItemsStep2 * dividTo6Days;
                    var consumableItemsStep4 = consumableItemsStep3 * AllDaysCount;
                    ConsumableItems = consumableItemsStep4.ToMoney();

                    if (familyAllowance != "0")
                    {
                        var familyAllowanceStep1 = familyAllowanceNumberType / 30;
                        var familyAllowanceStep2 = familyAllowanceStep1 / 7.33;
                        var familyAllowanceStep3 = familyAllowanceStep2 * dividTo6Days;
                        var familyAllowanceStep4 = familyAllowanceStep3 * AllDaysCount;
                        familyAllowance = familyAllowanceStep4.ToMoney();
                    }

                    SumWorkeTime = $"{SumSingle.TotalHours}";
                }
                else
                {
                    SumWorkeTime = $"{44}";
                }

            }
            else if (command.ShiftWork == "2")
            {
                var totalShift = SumSingle + SumTow;
                if (totalShift < fix44)
                {
                    var dividTo6Days = totalShift.Divide(divideNum);
                    var DailyFeeStrNumber = dayliFee.ToDoubleMoney();
                    var DailyFeeNumberType = Convert.ToDouble(DailyFeeStrNumber);

                    var HousingAllowonceStrNumber = HousingAllowance.ToDoubleMoney();
                    var HousingAllowonceNumberType = Convert.ToDouble(HousingAllowonceStrNumber);

                    var ConsumableItemsStrNumber = ConsumableItems.ToDoubleMoney();
                    var ConsumableItemsNumberType = Convert.ToDouble(ConsumableItemsStrNumber);

                    var familyAllowanceStrNumber = familyAllowance.ToDoubleMoney();
                    var familyAllowanceNumberType = Convert.ToDouble(familyAllowanceStrNumber);

                    var step1 = DailyFeeNumberType / 7.33;
                    var step2 = step1 * dividTo6Days;

                    dayliFee = step2.ToMoney();



                    var HousingStep1 = HousingAllowonceNumberType / 30;
                    var HousingStep2 = HousingStep1 / 7.33;
                    var HousingStep3 = HousingStep2 * dividTo6Days;
                    var HousingStep4 = HousingStep3 * AllDaysCount;
                    HousingAllowance = HousingStep4.ToMoney();

                    var consumableItemsStep1 = ConsumableItemsNumberType / 30;
                    var consumableItemsStep2 = consumableItemsStep1 / 7.33;
                    var consumableItemsStep3 = consumableItemsStep2 * dividTo6Days;
                    var consumableItemsStep4 = consumableItemsStep3 * AllDaysCount;
                    ConsumableItems = consumableItemsStep4.ToMoney();

                    if (familyAllowance != "0")
                    {
                        var familyAllowanceStep1 = familyAllowanceNumberType / 30;
                        var familyAllowanceStep2 = familyAllowanceStep1 / 7.33;
                        var familyAllowanceStep3 = familyAllowanceStep2 * dividTo6Days;
                        var familyAllowanceStep4 = familyAllowanceStep3 * AllDaysCount;
                        familyAllowance = familyAllowanceStep4.ToMoney();
                    }
                    SumWorkeTime = $"{totalShift.TotalHours}";
                }
                else
                {
                    SumWorkeTime = $"{44}";
                }


            }




            if (command.ShiftWork == "1" && totalHoursShift1 > dailyFix)
            {
                Mandatory = totalHoursShift1.Subtract(dailyFix);
            }

            if (command.ShiftWork == "2" && totalHoursShift1And2 > dailyFix)
            {
                Mandatory = totalHoursShift1And2.Subtract(dailyFix);
            }
            if ((command.ShiftWork == "5" && totalHoursShift1 > ComplexFix)
                || (command.ShiftWork == "6" && totalHoursShift1 > ComplexFix)
                || (command.ShiftWork == "7" && totalHoursShift1 > ComplexFix)
                || (command.ShiftWork == "8" && totalHoursShift1 > ComplexFix))
            {
                Mandatory = totalHoursShift1.Subtract(ComplexFix);
            }
            var mandatoryHours = (int)Mandatory.TotalHours;
            var mandatoryminuts = Mandatory.Minutes % 60;

            //Over22 = Over22.Multiply(sumDays);
            var Over22hours = (int)Over22.TotalHours;
            var Over22Minuts = Over22.TotalMinutes % 60;

            if (command.ShiftWork == "1")
            {
                shift1Hourse = workingDaysH.ToString();
                shift1Minuts = workingDaysM.ToString();



                if (totalHoursShift1 > dailyFix)
                {
                    overMandatoryHours = mandatoryHours.ToString();
                    overMandatoryMinuts = mandatoryminuts.ToString();
                    //line3 = "مجموع ساعات اضافه کاری " + " : " + $" {mandatoryHours} " + "ساعت و " + $" {mandatoryminuts} " + "دقیقه";
                }


                shiftOver22Hours = Over22hours.ToString();
                shiftOver22Minuts = Over22Minuts.ToString();


            }

            if (command.ShiftWork == "2")
            {
                shift1Hourse = SumNotHolidaysHours.ToString();
                shift1Minuts = SumNotHolidaysMinuts.ToString();


                if (totalHoursShift1And2 > dailyFix)
                {
                    overMandatoryHours = mandatoryHours.ToString();
                    overMandatoryMinuts = mandatoryminuts.ToString();

                }
                shiftOver22Hours = Over22hours.ToString();
                shiftOver22Minuts = Over22Minuts.ToString();

            }

            if (command.ShiftWork == "5" || command.ShiftWork == "6" || command.ShiftWork == "7" || command.ShiftWork == "8")
            {
                shift1Hourse = workingDaysH.ToString();
                shift1Minuts = workingDaysM.ToString();



                if (totalHoursShift1 > ComplexFix)
                {
                    overMandatoryHours = mandatoryHours.ToString();
                    overMandatoryMinuts = mandatoryminuts.ToString();
                    //line3 = "مجموع ساعات اضافه کاری " + " : " + $" {mandatoryHours} " + "ساعت و " + $" {mandatoryminuts} " + "دقیقه";
                }


                shiftOver22Hours = Over22hours.ToString();
                shiftOver22Minuts = Over22Minuts.ToString();
            }

            string ComplexNotHolidays = string.Empty;
            if (command.ShiftWork == "5" || command.ShiftWork == "6" || command.ShiftWork == "7" || command.ShiftWork == "8")
            {
                ComplexNotHolidays = Notholiday;
                Notholiday = "0";
            }


            var ress = new ComputingViewModel()
            {

                NumberOfWorkingDays = Notholiday,
                NumberOfFriday = Holidays,
                TotalHoursesH = shift1Hourse,
                TotalHoursesM = shift1Minuts,
                E = shift1HolidayHours,
                F = shift1HolidayMinuts,
                Interference = InterferenceMessage,
                OverTimeWorkH = overMandatoryHours,
                OverTimeWorkM = overMandatoryMinuts,
                OverNightWorkH = shiftOver22Hours,
                OverNightWorkM = shiftOver22Minuts,
                ComplexNumberOfWorkingDays = ComplexNotHolidays,
                SalaryCompute = dayliFee,
                SumTime44 = SumWorkeTime,
                ConsumableItems = ConsumableItems,
                HousingAllowance = HousingAllowance,
                FamilyAllowance = familyAllowance


            };


            return ress;
        }

        public EditContract GetDetails(long id)
        {


            var emplyee = _employeeApplication.GetEmployee();
            var workshop = _workshopApplication.GetWorkshop();
            var workshopEmpList = _contractRepository.GetWorkshopEmployer();
            var res = _contractRepository.GetDetails(id);


            var emp = workshopEmpList.Where(x => x.WorkshopId == res.WorkshopIds)
                .Select(x => x.EmployerId).ToList();
            res.Employers = _employerRepository.GetEmployers(emp);

            res.Workshops = workshop.Where(x => x.Id == res.WorkshopIds).ToList();
            res.Employees = emplyee.Where(x => x.Id == res.EmployeeId).ToList();
            return res;
        }

        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var contract = _contractRepository.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.Active();

            _contractRepository.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var contract = _contractRepository.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.DeActive();


            _contractRepository.SaveChanges();
            return opration.Succcedded();
        }

        public List<ContractViweModel> Search(ContractSearchModel searchModel)
        {
            return _contractRepository.Search(searchModel);
        }

        public List<ContractViweModel> SearchForextension(ContractSearchModel searchModel)
        {
            return _contractRepository.SearchForextension(searchModel);
        }

        public bool CheckNextContractExist(long employeeId, DateTime startContract, DateTime endContract, long WorkshopId)
        {
            return _contractRepository.CheckNextContractExist(employeeId, startContract, endContract, WorkshopId);
        }

        public bool CkeckBetween(long employeeId, DateTime EndOfContract, DateTime StartOfExtension, long WorkshopId)
        {
            return _contractRepository.CkeckBetween(employeeId, EndOfContract, StartOfExtension, WorkshopId);
        }

        public List<ContractViweModel> PrintAll(List<long> id)
        {
            return _contractRepository.PrintAll(id);
        }


        public TimeSpan Over22Check(DateTime date1, DateTime date2)
        {
            TimeSpan Over22 = new TimeSpan();
            DateTime singleShiftOver24 = Convert.ToDateTime("00:00");
            DateTime nightWork22 = Convert.ToDateTime("22:00");
            DateTime nightWork6 = Convert.ToDateTime("06:00");
            DateTime starTimeSingel1 = date1;
            DateTime endTimeSingel2 = date2;
            bool check = false;
            if ((endTimeSingel2 > nightWork22 || endTimeSingel2 == singleShiftOver24) && (starTimeSingel1 < nightWork22 && starTimeSingel1 > nightWork6))
            {
                var nightWork6NextDay = new DateTime();
                if (endTimeSingel2.Day > starTimeSingel1.Day)
                {
                     nightWork6NextDay = nightWork6.AddDays(1);
                }
                check = true;
                if (endTimeSingel2 <= nightWork6NextDay)
                {
                    check = true;
                    Over22 = (endTimeSingel2 - nightWork22);
                }
                else
                {
                    
                    check = true;
                    Over22 = (nightWork6NextDay - nightWork22);
                }
               


            }
            if ((date2 > singleShiftOver24 && endTimeSingel2 <= nightWork6) && (starTimeSingel1 < nightWork22 && starTimeSingel1 > nightWork6))
            {
                check = true;
                endTimeSingel2 = endTimeSingel2.AddDays(1);
                Over22 = (endTimeSingel2 - nightWork22);
            }
            if ((endTimeSingel2 > singleShiftOver24 && endTimeSingel2 <= nightWork6) && (starTimeSingel1 >= nightWork22))
            {
                check = true;
                endTimeSingel2 = endTimeSingel2.AddDays(1);
                Over22 = (endTimeSingel2 - starTimeSingel1);
            }
            if ((endTimeSingel2 > singleShiftOver24 && endTimeSingel2 <= nightWork6) && (starTimeSingel1 >= singleShiftOver24 && starTimeSingel1 <= nightWork6))
            {
                check = true;
                Over22 = (endTimeSingel2 - starTimeSingel1);
            }
            if (starTimeSingel1 >= nightWork22 && endTimeSingel2 > nightWork22)
            {
                check = true;

                var nightWork6NextDay = new DateTime();
                if (endTimeSingel2.Day > starTimeSingel1.Day)
                {
                    nightWork6NextDay = nightWork6.AddDays(1);
                    if (endTimeSingel2 <= nightWork6NextDay)
                    {
                        check = true;
                        Over22 = (endTimeSingel2 - starTimeSingel1);
                    }
                    else
                    {

                        check = true;
                        Over22 = (nightWork6NextDay - starTimeSingel1);
                    }
                }
                
                
            }
            if (endTimeSingel2.Day == starTimeSingel1.Day)
            {
                if (endTimeSingel2 <= nightWork6 && starTimeSingel1 >= singleShiftOver24)
                {
                    check = true;
                    Over22 = (endTimeSingel2 - starTimeSingel1);
                }else if(endTimeSingel2 >= nightWork6 && starTimeSingel1 >= singleShiftOver24 && endTimeSingel2 <= nightWork22 )

                {

                    if (starTimeSingel1 >= nightWork6 && endTimeSingel2 <= nightWork22)
                    {
                        Over22 = TimeSpan.Zero;
                    }
                    else
                    {
                        Over22 = (nightWork6 - starTimeSingel1);
                    }
                   
                       
                    
                }
                else if(starTimeSingel1 >= singleShiftOver24 && endTimeSingel2 > nightWork22)
                {
                    if (starTimeSingel1 >= nightWork22)
                    {
                        Over22 = (endTimeSingel2 - starTimeSingel1);
                    }
                    else if(starTimeSingel1 < nightWork22 && endTimeSingel2 > nightWork22)
                    {
                        if (starTimeSingel1 <  nightWork6)
                        {
                            var step1 = (nightWork6 - starTimeSingel1);
                            var step2 = (endTimeSingel2 - nightWork22);
                            var step3 = step1 + step2;
                            Over22 = step3;
                        }
                        else
                        {
                            Over22 = (endTimeSingel2 - nightWork22);
                        }
                       
                    }
                   
                    
                }else if (starTimeSingel1 > nightWork22 && endTimeSingel2 > nightWork22)
                {
                    Over22 = (endTimeSingel2 - starTimeSingel1);
                }
            }
            return Over22;
        }

        public TimeSpan Over22Complex(DateTime date1, DateTime date2)
        {
            TimeSpan Over22Result = new TimeSpan();
            DateTime Over24 = new DateTime(date2.Year, date2.Month, date2.Day, 0, 0, 0);
            DateTime nightWork22 = new DateTime(date1.Year, date1.Month, date1.Day, 22, 0, 0);
            DateTime nightWork22b = new DateTime(date2.Year, date2.Month, date2.Day, 22, 0, 0);
            DateTime nightWork6 = new DateTime(date2.Year, date2.Month, date2.Day, 6, 0, 0);
            DateTime nightWork6a = new DateTime(date1.Year, date1.Month, date1.Day, 6, 0, 0);
            DateTime starTime = date1;
            DateTime endTime = date2;
            if (endTime > nightWork22 && starTime < nightWork22)
            {
                if (starTime.Day == endTime.Day)
                {
                    nightWork6 = nightWork6.AddDays(1);
                }

                if (endTime <= nightWork6)
                {
                    Over22Result = (endTime - nightWork22);

                }
                else if (endTime > nightWork6)
                {
                    Over22Result = (nightWork6 - nightWork22);
                }
            }

            if (endTime > nightWork22 && starTime >= nightWork22)
            {
                if (endTime <= nightWork6)
                {
                    Over22Result = (endTime - starTime);
                }
                else if (endTime > nightWork6)
                {
                    Over22Result = (nightWork6 - starTime);
                }

            }

            if ((starTime.Hour >= 0 && starTime.Minute >= 0) && (starTime < nightWork6 && starTime.Day == nightWork6.Day))
            {
                if (endTime > nightWork6)
                {
                    Over22Result = (nightWork6 - starTime);
                }
                else if (endTime <= nightWork6)
                {
                    Over22Result = (endTime - starTime);
                }
                //nightWork22 = nightWork22.Subtract(new TimeSpan(1, 0, 0, 0));
            }

            return Over22Result;
        }

        public TimeSpan Over22Complex2424(DateTime date1, DateTime date2)
        {
            TimeSpan Over22Result = new TimeSpan();
            DateTime Over24a = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0);
            DateTime Over24b = new DateTime(date2.Year, date2.Month, date2.Day, 0, 0, 0);
            DateTime nightWork22a = new DateTime(date1.Year, date1.Month, date1.Day, 22, 0, 0);
            DateTime nightWork22b = new DateTime(date2.Year, date2.Month, date2.Day, 22, 0, 0);

            DateTime nightWork6a = new DateTime(date1.Year, date1.Month, date1.Day, 6, 0, 0);
            DateTime nightWork6b = new DateTime(date2.Year, date2.Month, date2.Day, 6, 0, 0);
            DateTime starTime = date1;
            DateTime endTime = date2;

            if (starTime >= Over24a && starTime <= nightWork6a)
            {
                if (endTime > nightWork22a && endTime <= nightWork6b)
                {
                    TimeSpan night1 = (nightWork6a - starTime);
                    TimeSpan night2 = (endTime - nightWork22a);
                    Over22Result = night1.Add(night2);
                }

                if (endTime > nightWork6a && endTime < nightWork22a)
                {
                    Over22Result = (nightWork6a - starTime);
                }
            }

            if (starTime >= nightWork6a && starTime < nightWork22a)
            {
                if (endTime > nightWork22a && endTime <= nightWork6b)
                {
                    Over22Result = (endTime - nightWork22a);
                }

                if (endTime > nightWork6b)
                {
                    Over22Result = (nightWork6b - nightWork22a);
                }
            }

            if (starTime >= nightWork22a && starTime < Over24b)
            {

                if (endTime <= nightWork22b)
                {
                    Over22Result = (nightWork6b - starTime);
                }


                if (endTime > nightWork22b)
                {
                    TimeSpan night1 = (nightWork6b - starTime);
                    TimeSpan night2 = (endTime - nightWork22b);
                    Over22Result = night1.Add(night2);
                }
            }



            return Over22Result;
        }

        public OperationResult Sign(long id)
        {
            var opration = new OperationResult();
            var contract = _contractRepository.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.Sign();


            _contractRepository.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult UnSign(long id)
        {
            var opration = new OperationResult();
            var contract = _contractRepository.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.UnSign();


            _contractRepository.SaveChanges();
            return opration.Succcedded();
        }
    }
}
