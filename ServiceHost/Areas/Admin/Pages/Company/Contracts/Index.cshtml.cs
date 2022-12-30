using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.ContractAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Job;
using CompanyManagment.App.Contracts.Leave;
using CompanyManagment.App.Contracts.LeftWork;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using CompanyManagment.App.Contracts.WorkingHours;
using CompanyManagment.App.Contracts.WorkingHoursItems;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.App.Contracts.YearlySalary;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PersianTools.Core;

namespace ServiceHost.Areas.Admin.Pages.Company.Contracts
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public string Message { get; set; }

        public ContractSearchModel SearchModel;

        public List<ContractViweModel> Contracts;
        public List<ContractViweModel> Contracts2;
        public List<EmployeeViewModel> EmployeeList;
        public List<EmployerViewModel> EmployerList;
        public List<WorkshopViewModel> WorkshopList;
        public List<ComputingViewModel> ComputingView;
        public string WorkshopSearch = "false";
        public bool falseCheck { get; set; }


        public List<JobViewModel> JobList;
        public List<WorkshopEmployerViewModel> WorkshopEmployer;



        public SelectList Workshops;
        public SelectList WorkshopsCode;
        public SelectList Employees;
        public SelectList Employers;
        public SelectList Jobs;
        public SelectList YearlyList;
        private readonly IContractApplication _contractApplication;
        private readonly IWorkshopApplication _workshopApplication;
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IEmployerApplication _employerApplication;
        private readonly IYearlySalaryApplication _yearlySalaryApplication;
        private readonly IJobApplication _jobApplication;
        private readonly IContractRepository _contractRepository;
        private readonly IWorkingHoursApplication _workingHoursApplication;
        private readonly IWorkingHoursItemsApplication _workingHoursItemsApplication;
        private readonly IAuthHelper _authHelper;
        private readonly ILeftWorkApplication _leftWorkApplication;
        private readonly ILeaveApplication _leaveApplication;

        public IndexModel(IContractApplication contractApplication, IWorkshopApplication workshopApplication,
            IEmployeeApplication employeeApplication,
            IEmployerApplication employerApplication,
            IYearlySalaryApplication yearlySalaryApplication,
            IJobApplication jobApplication, IContractRepository contractRepository,
            IWorkingHoursApplication workingHoursApplication,
            IWorkingHoursItemsApplication workingHoursItemsApplication,
            IAuthHelper authHelper, ILeftWorkApplication leftWorkApplication, ILeaveApplication leaveApplication)
        {
            _contractApplication = contractApplication;
            _workshopApplication = workshopApplication;
            _employeeApplication = employeeApplication;
            _employerApplication = employerApplication;
            _yearlySalaryApplication = yearlySalaryApplication;
            _jobApplication = jobApplication;
            _contractRepository = contractRepository;
            _workingHoursApplication = workingHoursApplication;
            _workingHoursItemsApplication = workingHoursItemsApplication;
            _authHelper = authHelper;
            _leftWorkApplication = leftWorkApplication;
            _leaveApplication = leaveApplication;
        }


        public void OnGet(ContractSearchModel searchModel)
        {

            EmployerList = _employerApplication.GetEmployers();
            EmployeeList = _employeeApplication.GetEmployee();
            WorkshopList = _workshopApplication.GetWorkshop();
            Jobs =
                new SelectList(_jobApplication.GetJob(), "Id", "JobName");

            Workshops =
                new SelectList(_workshopApplication.GetWorkshopAccount(), "Id", "WorkshopFullName");

            WorkshopsCode =
                new SelectList(_workshopApplication.GetWorkshopAccount(), "Id", "ArchiveCode");

            Employees =
                new SelectList(_employeeApplication.GetEmployee(), "Id", "EmployeeFullName");

            Employers =
                new SelectList(_employerApplication.GetEmployers(), "Id", "FullName");
            YearlyList =
                new SelectList(_yearlySalaryApplication.GetYearlySalary(), "Year", "Year");

            Contracts = _contractApplication.Search(searchModel);
            if (Contracts != null)
            {
                if (searchModel.WorkshopIds != 0 || searchModel.EmployeeId != 0)
                {
                    WorkshopSearch = "true";
                }
            }


        }


        public IActionResult OnGetCreateSickLeave(long employeeId, long workshopId, long hd)
        {
            var search = new LeaveSearchModel()
            {
                EmployeeId = employeeId,
                WorkshopId = workshopId,
                LeaveType = "استعلاجی",

            };
            var serachResult = _leaveApplication.search(search);

            var command = new CreateLeave()
            {
                EmployeeId = employeeId,
                WorkshopId = workshopId,
                LeaveSearch = serachResult,


            };
            return Partial("./SickLeave", command);
        }
        public IActionResult OnPostCreateSickLeave(CreateLeave command)
        {

            command.LeaveType = "استعلاجی";

            var result = _leaveApplication.Create(command);
            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                EmployeeId = command.EmployeeId,
                WorkshopId = command.WorkshopId
            });
        }
        public IActionResult OnPostRemoveSickLeave(long id, long EmployeeId, long WorkshopId)
        {
            var result = _leaveApplication.RemoveLeave(id);
            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                employeeId = EmployeeId,
                workshopId = WorkshopId,
                hd = 1
            });

        }
        public IActionResult OnGetEditSickLeave(long id)
        {

            var res = _leaveApplication.GetDetails(id);


            return Partial("EditSick", res);
        }
        public IActionResult OnPostEditSickLeave(EditLeave command)
        {
            if (ModelState.IsValid)
            {

            }

            command.LeaveType = "استعلاجی";
            var result = _leaveApplication.Edit(command);

            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                employeeId = command.EmployeeId,
                workshopId = command.WorkshopId,
                hd = 1
            });



        }
        public IActionResult OnGetCreatePaidLeave(long employeeId, long workshopId, long hd)
        {
            var search = new LeaveSearchModel()
            {
                EmployeeId = employeeId,
                WorkshopId = workshopId,
                LeaveType = "استحقاقی",

            };
            var serachResult = _leaveApplication.search(search);

            var command = new CreateLeave()
            {
                EmployeeId = employeeId,
                WorkshopId = workshopId,
                LeaveSearch = serachResult,


            };
            return Partial("./PaidLeave", command);
        }
        public IActionResult OnPostCreatePaidLeave(CreateLeave command)
        {

            command.LeaveType = "استحقاقی";
       
            var result = _leaveApplication.Create(command);
            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                EmployeeId = command.EmployeeId,
                WorkshopId = command.WorkshopId
            });
        }
        public IActionResult OnPostRemovePaidLeave(long id, long EmployeeId, long WorkshopId)
        {
            var result = _leaveApplication.RemoveLeave(id);
            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                employeeId = EmployeeId,
                workshopId = WorkshopId,
                hd = 1
            });

        }
        public IActionResult OnPostRemoveLeftWork(long id, long EmployeeId, string employeeName)
        {
            var result = _leftWorkApplication.RemoveLeftWork(id);
            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                employeeId = EmployeeId,
                employeeName = employeeName,
                hd = 1
            });

        }
        public IActionResult OnGetCreateLeftWork(long employeeId, string employeeName)
        {
            var search = new LeftWorkSearchModel()
            {
                EmployeeId = employeeId,
          
            };
            var serachResult = _leftWorkApplication.search(search);
            var workShops = _workshopApplication.GetWorkshop();
            var command = new CreateLeftWork()
            {
                EmployeeId = employeeId,
                EmployeeFullName = employeeName,
                LeftWorkSearch = serachResult,
                Workshops = workShops

            };
            return Partial("./LeftWork", command);
        }
      
        public IActionResult OnPostCreateLetWork(CreateLeftWork command)
        {
            
            //var workshopName = _workshopApplication.GetDetails(command.WorkshopId);
            //var start = _leftWorkApplication.StartWork(command.EmployeeId, command.WorkshopId, command.LeftWorkDate);
            command.LeftWorkDate = "1500/01/01";
            //command.WorkshopName = workshopName.WorkshopFullName;
           
            var result = _leftWorkApplication.Create(command);
            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                EmployeeId = command.EmployeeId,
                employeeName = command.EmployeeFullName
            });
        }

        public IActionResult OnGetEditPaidLeave(long id)
        {

            var res = _leaveApplication.GetDetails(id);


            return Partial("EditPaidLeave", res);
        }
        public IActionResult OnPostEditPaidLeave(EditLeave command)
        {
            if (ModelState.IsValid)
            {

            }

            command.LeaveType = "استحقاقی";
            var result = _leaveApplication.Edit(command);

            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                employeeId = command.EmployeeId,
                workshopId = command.WorkshopId,
                hd = 1
            });



        }
        public IActionResult OnGetEditLeftWork(long id)
        {

            var res = _leftWorkApplication.GetDetails(id);


            return Partial("EditLeftWork", res);
        }

        public IActionResult OnPostEditLeftWork(EditLeftWork command)
        {
            if (ModelState.IsValid)
            {

            }


            var result = _leftWorkApplication.Edit(command);

            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                employeeId = command.EmployeeId,
                employeeName = command.EmployeeFullName,
                hd = 1
            });



        }
        public IActionResult OnGetEnterLeftWork(long id, string employeeName)
        {

            var res = _leftWorkApplication.GetDetails(id);
            res.LeftWorkDate = "";
            res.EmployeeFullName = employeeName;

            return Partial("EnterLeftWorkDate", res);
        }
        public IActionResult OnPostEnterLeftWork(EditLeftWork command)
        {
            if (ModelState.IsValid)
            {

            }


            var result = _leftWorkApplication.Edit(command);

            var res = result.IsSuccedded;
            return new JsonResult(new
            {
                IsSuccedded = res,
                message = result.Message,
                employeeId = command.EmployeeId,
                workshopId = command.WorkshopId,
                hd = 1
            });



        }

        public IActionResult OnPostLoadPersonel(long id, long workshopId)
        {
            string leftWorkStartdate = "";
            var result = _employeeApplication.GetDetails(id);
            var serachModel = new LeftWorkSearchModel()
            {
                EmployeeId = id,
                WorkshopId = workshopId,
               
            };
            var leftWoekSerchResult = _leftWorkApplication.search(serachModel);
            if (leftWoekSerchResult.Count > 0)
            {
                var leftWorkLast = leftWoekSerchResult.OrderByDescending(x=>x.StartWorkDateGr).FirstOrDefault();
                if (leftWorkLast.LeftWorkDate == "1500/01/01")
                    leftWorkStartdate = leftWoekSerchResult.Select(x => x.StartWorkDate).FirstOrDefault();
            }
               


            return new JsonResult(new
            {
                IsSuccedded = true,
                FatherName = result.FatherName,
                NationalCode = result.NationalCode,
                IdNumber = result.IdNumber,
                DateOfBirth = result.DateOfBirth,
                State = result.State,
                City = result.City,
                Address = result.Address,
                LeftWorkStartDate = leftWorkStartdate,

            });
        }

        public IActionResult OnPostLoadWorkshops(long id)
        {
            var result = _workshopApplication.GetWorkshopInfo(id);
            return new JsonResult(new
            {
                IsSuccedded = true,
                InsurancCode = result.InsuranceCode,
                archiveCode = result.ArchiveCode,
                state = result.State,
                city = result.City,
                address = result.Address,
                adres =result.State + "-"+ result.City + "-" + result.Address,
                empList = result.EmpList,
                employeeList = result.EmployeeList

            });
        }
        public IActionResult OnGetCreate()
        {
           

            var command = new CreateContract()
            {
                Jobs = _jobApplication.GetJob(),
                //Workshops = _workshopApplication.GetWorkshopAccount(),
                
                YearlySalaries = _yearlySalaryApplication.GetYearlySalary(),
                
                ////Employees = _employeeApplication.GetEmployee(),
                //Employers = _employerApplication.GetEmployers(),
                //WorkshopEmployerList = _contractRepository.GetWorkshopEmployer(),
                //EmployeeSelectList =
                //    new SelectList(_employeeApplication.GetEmployee(), "Id", "EmployeeFullName"),
               
                WorkshopNameSelectList = new SelectList(_workshopApplication.GetWorkshopAccount(),"Id",  "WorkshopFullName"),
                WorkshopCodeSelectList = new SelectList(_workshopApplication.GetWorkshopAccount(),"Id", "ArchiveCode")
            };

            



            return Partial("./Create", command);
        }


        public IActionResult OnPostCreate(CreateContract command)
        {
            
            var result = _contractApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetExtension()
        {
            var today = DateTime.Now;
            var faToday = string.Empty;


            faToday = today.ToFarsi();
            var syear = Convert.ToInt32(faToday.Substring(0, 4));
            var smonth = Convert.ToInt32(faToday.Substring(5, 2));
            var PersianStartMonth = new PersianDateTime(syear, smonth, 01);
            var year = PersianStartMonth.Year.ToString();
            var Getmonth = PersianStartMonth.ToString();
            var month = Getmonth.Substring(5, 2);

            var ConvertStartPersian = PersianStartMonth.AddMonths(1);
            var convertYear = ConvertStartPersian.Year.ToString();
            var GetConvertMonth = ConvertStartPersian.ToString();
            var convertMonth = GetConvertMonth.Substring(5, 2);



            var command = new ExtensionViewModel()
            {

                Workshops = _workshopApplication.GetWorkshopAccount(),

                Employees = _employeeApplication.GetEmployee(),

                Employers = _employerApplication.GetEmployers(),

                YearlySalaries = _yearlySalaryApplication.GetYearlySalary(),

                Year = year,
                Month = month,
                ConvertYear = convertYear,
                ConvertMonth = convertMonth,
            };
            return Partial("./Extension", command);
        }

        public IActionResult OnGetExtension2(long WorkshopIds, string Year, string Month, string ContarctStart, string ContractEnd, long EmployeeId, string FormStep,
            string ConvertYear, string ConvertMonth, string ConvertContractStart, string ConvertContractEnd)
        {
            var opration = new OperationResult();

            var today = DateTime.Now;
            var GrogorianEnd = new DateTime();
            var GrogorianStart = new DateTime();
            var GrogorianThisMonthStart2 = new DateTime();
            var GrogorianPreviusMonthStart2 = new DateTime();
            var ConvertContractStartGr = new DateTime();
            var ConvertContractEndGr = new DateTime();
            var ConvertStartFarsi = string.Empty;
            var nextmonthEndfarsi = string.Empty;
            var faToday = string.Empty;
            var faToday2 = string.Empty;
            int syear = 0;
            int smonth = 0;
            int syear2 = 0;
            int smonth2 = 0;
            var ConvertStart = new DateTime();
            var ConvertEnd = new DateTime();
            if (string.IsNullOrWhiteSpace(ContarctStart) && string.IsNullOrWhiteSpace(ContractEnd))
            {
                if (Month == "0" && Year == "0")
                {
                    faToday = today.ToFarsi();
                }
                else
                {

                    faToday = $"{Year}/{Month}/01";
                }

                syear = Convert.ToInt32(faToday.Substring(0, 4));
                smonth = Convert.ToInt32(faToday.Substring(5, 2));

                var PersianStart = new PersianDateTime(syear, smonth, 01);
                GrogorianStart = PersianStart.ToGregorianDateTime();
                var PersianEndFinde = new PersianDateTime(syear, smonth, 01);
                PersianEndFinde = PersianEndFinde.AddMonths(1);
                GrogorianEnd = PersianEndFinde.ToGregorianDateTime();

                //nextMonthStartFarsi = GrogorianThisMonthStart.ToFarsi();
                //nextmonthEndfarsi = nextMonthStartFarsi.FindeEndOfMonth();
            }

            if (FormStep == "convert" && (string.IsNullOrWhiteSpace(ConvertContractStart) && string.IsNullOrWhiteSpace(ConvertContractEnd)))
            {
                if (ConvertMonth == "0" && ConvertYear == "0")
                {
                    today = today.AddMonths(1);
                    faToday2 = today.ToFarsi();
                }
                else
                {

                    faToday2 = $"{ConvertYear}/{ConvertMonth}/01";
                }

                syear2 = Convert.ToInt32(faToday2.Substring(0, 4));
                smonth2 = Convert.ToInt32(faToday2.Substring(5, 2));
                var PersianStartMonth2 = new PersianDateTime(syear2, smonth2, 01);

                GrogorianThisMonthStart2 = PersianStartMonth2.ToGregorianDateTime();
                var PersianStartPreviusMonth2 = new PersianDateTime(syear2, smonth2, 01);
                PersianStartPreviusMonth2 = PersianStartPreviusMonth2.AddMonths(-1);
                GrogorianPreviusMonthStart2 = PersianStartPreviusMonth2.ToGregorianDateTime();
                ConvertStartFarsi = GrogorianThisMonthStart2.ToFarsi();
                nextmonthEndfarsi = ConvertStartFarsi.FindeEndOfMonth();
                ConvertStart = GrogorianThisMonthStart2;
                ConvertEnd = nextmonthEndfarsi.ToGeorgianDateTime();

            }

            if (!string.IsNullOrWhiteSpace(ConvertContractStart) && !string.IsNullOrWhiteSpace(ConvertContractEnd))
            {

                var year3Start = Convert.ToInt32(ConvertContractStart.Substring(0, 4));
                var month3Start = Convert.ToInt32(ConvertContractStart.Substring(5, 2));
                var day3Start = Convert.ToInt32(ConvertContractStart.Substring(8, 2));
                var PersianStart = new PersianDateTime(year3Start, month3Start, day3Start);
                PersianStart = PersianStart.AddMonths(-1);
                GrogorianPreviusMonthStart2 = PersianStart.ToGregorianDateTime();
                ConvertContractStartGr = ConvertContractStart.ToGeorgianDateTime();

                //var year3 = Convert.ToInt32(ConvertContractEnd.Substring(0, 4));
                //var month3 = Convert.ToInt32(ConvertContractEnd.Substring(5, 2));
                //var PersianEnd = new PersianDateTime(year3, month3, 01);

                ConvertContractEndGr = ConvertContractEnd.ToGeorgianDateTime();

                ConvertStartFarsi = ConvertContractStart;
                nextmonthEndfarsi = ConvertContractEnd;





            }


            //if (FormStep == "convert")
            //{
            //    Year = ConvertYear;
            //    Month = ConvertMonth;

            //}
            var a = new ContractSearchModel()
            {
                WorkshopIds = WorkshopIds,
                Year = Year,
                Month = Month,
                ContarctStart = ContarctStart,
                ContractEnd = ContractEnd,
                EmployeeId = EmployeeId,


            };
            var secondContractSearch = new List<ContractViweModel>();

            var firstContractSearch = _contractApplication.SearchForextension(a);
            if (FormStep == "convert" && (string.IsNullOrWhiteSpace(ConvertContractStart) && string.IsNullOrWhiteSpace(ConvertContractEnd)))
            {
                foreach (var item in firstContractSearch)
                {
                    var sdate = item.ContarctStart.ToEnglishNumber();
                    var edate = item.ContractEnd.ToEnglishNumber();
                    var startY = Convert.ToInt32(sdate.Substring(0, 4));
                    var startM = Convert.ToInt32(sdate.Substring(5, 2));
                    var StartD = Convert.ToInt32(sdate.Substring(8, 2));

                    var endY = Convert.ToInt32(edate.Substring(0, 4));
                    var endM = Convert.ToInt32(edate.Substring(5, 2));
                    var endD = Convert.ToInt32(edate.Substring(8, 2));

                    var d1 = new PersianDateTime(startY, startM, StartD);
                    var d2 = new PersianDateTime(endY, endM, endD);
                    int monthConter = 0;
                    for (var da = d1; da <= d2; da.AddMonths(1))
                    {
                        monthConter = monthConter + 1;
                    }
                    var checkNextExist = _contractApplication.CheckNextContractExist(item.EmployeeId, ConvertStart, ConvertEnd, item.WorkshopIds);
                    if (item.ContractEndGr > ConvertStart && item.WorkshopIds == WorkshopIds && item.IsActiveString == "true")
                    {
                        item.Extension = false;
                        item.RedColor = true;
                        item.Waiting = false;
                        item.MoreThanOneMonth = false;
                        if (item.ContractEndGr > ConvertEnd)
                        {
                            item.LaterThanEnd = true;
                        }




                    }
                    else if (item.ContractEndGr < ConvertStart && item.WorkshopIds == WorkshopIds && item.IsActiveString == "true")
                    {
                        var checkBetween = _contractApplication.CkeckBetween(item.EmployeeId, item.ContractEndGr,
                            ConvertStart, item.WorkshopIds);
                        if (checkNextExist == false)
                        {
                            item.Extension = true;
                            item.RedColor = false;
                            if (checkBetween == false)
                            {
                                var ConvartStartToEnNm = ConvertStartFarsi.ToEnglishNumber();
                                var YearNum = Convert.ToInt32(ConvartStartToEnNm.Substring(0, 4));
                                var MonthNum = Convert.ToInt32(ConvartStartToEnNm.Substring(5, 2));
                                var DayNum = Convert.ToInt32(ConvartStartToEnNm.Substring(8, 2));
                                var ExtentionStart = new PersianDateTime(YearNum, MonthNum, DayNum);
                                ExtentionStart = ExtentionStart.AddMonths(-1);
                                var ExtensionStartFarsi = ExtentionStart.ToString();
                                var ExtensionPreviusMonthEnd = ExtensionStartFarsi.FindeEndOfMonth();
                                var ExtensioinPreviusEndMonthGr = ExtensionPreviusMonthEnd.ToGeorgianDateTime();


                                if (item.ContractEndGr != ExtensioinPreviusEndMonthGr)
                                {
                                    item.Waiting = true;
                                }

                            }

                            if (monthConter > 1)
                            {
                                item.MoreThanOneMonth = true;

                            }
                            else
                            {

                                item.MoreThanOneMonth = false;
                            }

                            item.NextMonthStart = ConvertStartFarsi;
                            item.NextMonthEnd = nextmonthEndfarsi;
                        }
                        else if (checkNextExist)
                        {
                            item.CheckNext = true;
                            item.RedColor = true;
                            item.Extension = false;
                            item.MoreThanOneMonth = false;
                        }


                    }





                    secondContractSearch.Add(item);
                }
            }
            else if (FormStep == "convert" && (!string.IsNullOrWhiteSpace(ConvertContractStart) && !string.IsNullOrWhiteSpace(ConvertContractEnd)))
            {

                foreach (var item in firstContractSearch)
                {
                    var sdate = item.ContarctStart.ToEnglishNumber();
                    var edate = item.ContractEnd.ToEnglishNumber();
                    var startY = Convert.ToInt32(sdate.Substring(0, 4));
                    var startM = Convert.ToInt32(sdate.Substring(5, 2));
                    var StartD = Convert.ToInt32(sdate.Substring(8, 2));

                    var endY = Convert.ToInt32(edate.Substring(0, 4));
                    var endM = Convert.ToInt32(edate.Substring(5, 2));
                    var endD = Convert.ToInt32(edate.Substring(8, 2));

                    var d1 = new PersianDateTime(startY, startM, StartD);
                    var d2 = new PersianDateTime(endY, endM, endD);
                    int monthConter = 0;
                    for (var da = d1; da <= d2; da.AddMonths(1))
                    {
                        monthConter = monthConter + 1;
                    }
                    var checkNextExist = _contractApplication.CheckNextContractExist(item.EmployeeId, ConvertContractStartGr, ConvertContractEndGr, item.WorkshopIds);
                    if (item.ContractEndGr > ConvertContractStartGr && item.WorkshopIds == WorkshopIds && item.IsActiveString == "true")
                    {
                        item.Extension = false;
                        item.RedColor = true;
                        item.Waiting = false;
                        item.MoreThanOneMonth = false;
                        if (item.ContractEndGr > ConvertContractEndGr)
                        {
                            item.LaterThanEnd = true;
                        }
                    }
                    else if (item.ContractEndGr < ConvertContractStartGr && item.WorkshopIds == WorkshopIds && item.IsActiveString == "true")
                    {
                        var checkBetween = _contractApplication.CkeckBetween(item.EmployeeId, item.ContractEndGr,
                            ConvertContractStartGr, item.WorkshopIds);
                        if (checkNextExist == false)
                        {
                            item.Extension = true;
                            item.RedColor = false;
                            if (checkBetween == false)
                            {
                                var ConvartStartToEnNm = ConvertContractStart.ToEnglishNumber();
                                var YearNum = Convert.ToInt32(ConvartStartToEnNm.Substring(0, 4));
                                var MonthNum = Convert.ToInt32(ConvartStartToEnNm.Substring(5, 2));
                                var DayNum = Convert.ToInt32(ConvartStartToEnNm.Substring(8, 2));
                                var ExtentionStart = new PersianDateTime(YearNum, MonthNum, DayNum);
                                ExtentionStart = ExtentionStart.AddMonths(-1);
                                var ExtensionStartFarsi = ExtentionStart.ToString();
                                var ExtensionPreviusMonthEnd = ExtensionStartFarsi.FindeEndOfMonth();
                                var ExtensioinPreviusEndMonthGr = ExtensionPreviusMonthEnd.ToGeorgianDateTime();


                                if (item.ContractEndGr != ExtensioinPreviusEndMonthGr)
                                {
                                    item.Waiting = true;
                                }
                            }
                            if (monthConter > 1)
                            {
                                item.MoreThanOneMonth = true;

                            }
                            else
                            {

                                item.MoreThanOneMonth = false;
                            }

                            item.NextMonthStart = ConvertStartFarsi;
                            item.NextMonthEnd = nextmonthEndfarsi;


                        }
                        else if (checkNextExist)
                        {
                            item.CheckNext = true;
                            item.RedColor = true;
                            item.Extension = false;
                            item.MoreThanOneMonth = false;
                        }


                    }

                    secondContractSearch.Add(item);
                }
            }

            var searchContracts = new List<ContractViweModel>();
            if (FormStep == "convert")
            {
                searchContracts = secondContractSearch;
            }
            else if (FormStep == "select")
            {
                searchContracts = firstContractSearch;
            }
            var command2 = new ExtensionViewModel()
            {

                Workshops = _workshopApplication.GetWorkshopAccount(),

                Employees = _employeeApplication.GetEmployee(),

                Employers = _employerApplication.GetEmployers(),

                YearlySalaries = _yearlySalaryApplication.GetYearlySalary(),
                Contracts = searchContracts,
                WorkshopIds = WorkshopIds,
                Month = Month,
                ContarctStart = ContarctStart,
                ContractEnd = ContractEnd,
                EmployeeId = EmployeeId,
                FormStep = FormStep,

            };
            return Partial("./alert", command2);

        }


        public IActionResult OnPostExtension3(string ConvertMonth, string ConvertYear, string ContarctStart, string ContractEnd, List<long> ContractsId,
            string ConvertContractStart, string ConvertContractEnd)
        {
            var today = DateTime.Now;
            var faToday2 = string.Empty;
            var CStart = string.Empty;
            var CEnd = string.Empty;
            var GrogorianThisMonthStart2 = new DateTime();



            int syear2 = 0;
            int smonth2 = 0;
            if (string.IsNullOrWhiteSpace(ConvertContractStart) && string.IsNullOrWhiteSpace(ConvertContractEnd))
            {
                if (ConvertMonth == "0" && ConvertYear == "0")
                {
                    today = today.AddMonths(1);
                    faToday2 = today.ToFarsi();
                }
                else
                {

                    faToday2 = $"{ConvertYear}/{ConvertMonth}/01";
                }
                syear2 = Convert.ToInt32(faToday2.Substring(0, 4));
                smonth2 = Convert.ToInt32(faToday2.Substring(5, 2));
                var PersianStartMonth2 = new PersianDateTime(syear2, smonth2, 01);

                GrogorianThisMonthStart2 = PersianStartMonth2.ToGregorianDateTime();



                CStart = GrogorianThisMonthStart2.ToFarsi();
                CEnd = CStart.FindeEndOfMonth();
            }
            else
            {
                CStart = ConvertContractStart;
                CEnd = ConvertContractEnd;
            }







            var step3 = _workingHoursItemsApplication.GetWorkingHoursItems();


            var op = new OperationResult();
            var contList = new List<CreateContract>();
            var ContractIdList = ContractsId;
            ContractIdList = ContractIdList.Where(x => x != 0).ToList();
            if (ContractIdList.Count > 0)
            {

                foreach (var item in ContractIdList)
                {
                    var step1 = _contractApplication.GetDetails(item);
                    var step2 = _workingHoursApplication.GetByContractId(item);

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


                var res = op.Succcedded();
                return new JsonResult(res);
            }
            else
            {
                op = op.Failed("هیچ قراردادی برای تمدید انتخاب نشده است");

                return new JsonResult(op);

            }



        }

        public IActionResult OnPostCheck(ExtensionViewModel command)
        {
            var a = command.ConvertYear;
            var b = command.ConvertMonth;


            var op = new OperationResult();
            if (command.ContractsId == null)
            {
                op = op.Failed("هیچ قراردادی برای تمدید انتخاب نشده است");

                return new JsonResult(op);
            }
            else
            {
                op = op.Succcedded();
                return new JsonResult(op);
            }



        }
        public IActionResult OnGetComputing()
        {

            return Partial("./Create");
        }

        public IActionResult OnPostComputing(CreateContract command)
        {

            var result = _contractApplication.MandatoryHours(command);



            return new JsonResult(result);
        }



        public IActionResult OnGetEdit(long id)
        {
            var res = _contractApplication.GetDetails(id);

          
            res.WorkshopEmployerList = _contractRepository.GetWorkshopEmployer();
            res.EmployeeSelectList = new SelectList(_employeeApplication.GetEmployee(), "Id", "EmployeeFullName");
            res.Employees = _employeeApplication.GetEmployee();
            res.Workshops = _workshopApplication.GetWorkshopAccount();
            res.YearlySalaries = _yearlySalaryApplication.GetYearlySalary();
            res.Employers = _employerApplication.GetEmployers();
            res.Jobs = _jobApplication.GetJob();

            return Partial("./Edit", res);
        }



        public JsonResult OnPostEdit(EditContract command)
        {

            if (ModelState.IsValid)
            {

            }


            var result = _contractApplication.Edit(command);
            return new JsonResult(result);







        }



        public IActionResult OnGetDetails(long id)
        {

            var res = _contractApplication.GetDetails(id);
            //res.WorkshopEmployerList = _contractRepository.GetWorkshopEmployer();
            //res.Employers = _employerApplication.GetEmployers();
            //res.Employees = _employeeApplication.GetEmployee();
            //res.Workshops = _workshopApplication.GetWorkshop();
            return Partial("Details", res);
        }

        public IActionResult OnGetPrintAll(List<long> ids)
        {
            var res = new GroupPrintViewModel
            {
                ContractList = _contractApplication.PrintAll(ids)
            };
            //var res = _contractApplication.PrintAll(ids);

            return Partial("PrintAll", res);
        }
        public IActionResult OnGetDeActive(long id)
        {


            var result = _contractApplication.DeActive(id);

            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetIsActive(long id)
        {


            var result = _contractApplication.Active(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetSign(long id)
        {


            var result = _contractApplication.Sign(id);
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetUnSign(long id)
        {


            var result = _contractApplication.UnSign(id);
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetGroupDeActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _contractApplication.DeActive(item);
            }
            return RedirectToPage("./Index");

        }


        public IActionResult OnGetGroupReActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _contractApplication.Active(item);
            }


            //if (result.IsSuccedded)
            //    return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


        public IActionResult OnGetGroupSign(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _contractApplication.Sign(item);
            }
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetGroupUnSign(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _contractApplication.UnSign(item);
            }
            return RedirectToPage("./Index");

        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
