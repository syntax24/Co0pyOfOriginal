using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.ContractAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopEmployerAgg;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Workshop;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using PersianTools.Core;
using DateTime = System.DateTime;

namespace CompanyManagment.EFCore.Repository
{
    public class ContractRepository : RepositoryBase<long, Contract>, IContractRepository
    {
        private readonly CompanyContext _context;
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IEmployerApplication _employerApplication;
        private readonly IWorkshopApplication _workshopApplication;
        private readonly IEmployerRepository _employerRepository;
        private readonly IAuthHelper _authHelper;
        public ContractRepository(CompanyContext context, IEmployeeApplication employeeApplication, IEmployerApplication employerApplication, IWorkshopApplication workshopApplication, IEmployerRepository employerRepository, IAuthHelper authHelper) : base(context)
        {
            _context = context;
            _employeeApplication = employeeApplication;
            _employerApplication = employerApplication;
            _workshopApplication = workshopApplication;
            _employerRepository = employerRepository;
            _authHelper = authHelper;
        }

        public EditContract GetDetails(long id)
        {
            return _context.Contracts.Select(x => new EditContract
                {
                    Id = x.id,
                    PersonnelCode = x.PersonnelCode,
                    EmployerId = x.EmployerId,
                    EmployeeId = x.EmployeeId,
                    WorkshopIds = x.WorkshopIds,
                    YearlySalaryId = x.YearlySalaryId,
                    DayliWage = x.DayliWage,
                    ContarctStart = x.ContarctStart.ToFarsi(),
                    ContractEnd = x.ContractEnd.ToFarsi(),
                    GetWorkDate = x.GetWorkDate.ToFarsi(),
                    SetContractDate = x.SetContractDate.ToFarsi(),
                    JobType = x.JobType,
                    ContractType = x.ContractType,
                    WorkshopAddress1 = x.WorkshopAddress1,
                    WorkshopAddress2 = x.WorkshopAddress2,
                    ContractNo = x.ContractNo,
                    JobTypeId = x.JobTypeId,
                    ConsumableItems = x.ConsumableItems,
                    HousingAllowance = x.HousingAllowance,
                    WorkingHoursWeekly = x.WorkingHoursWeekly,
                    FamilyAllowance = x.FamilyAllowance,
                    ContractPeriod = x.ContractPeriod,
                    AgreementSalary = x.AgreementSalary,
                    ArchiveCode = x.ArchiveCode,
                    
                    
                    




                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ContractViweModel> Search(ContractSearchModel searchModel)
        {
            var AcountID = _authHelper.CurrentAccountId();
            var workshopAcounts = _context.WorkshopAccounts.Where(x => x.AccountId == AcountID)
                .Select(x => x.WorkshopId).ToList();
            var emp = _context.WorkshopEmployers.Where(x => x.EmployerId == searchModel.EmployerId)
                .Select(x => x.WorkshopId).ToList();
            var query = _context.Contracts.Select(x => new ContractViweModel
            {
                Id = x.id,
                PersonnelCode = x.PersonnelCode,
                EmployerId = x.EmployerId,
                EmployeeId = x.EmployeeId,
                WorkshopIds = x.WorkshopIds,
                YearlySalaryId = x.YearlySalaryId,
                DayliWage = x.DayliWage,
                ContarctStart = x.ContarctStart.ToFarsi(),
                ContractEnd = x.ContractEnd.ToFarsi(),
                ContractStartGr = x.ContarctStart,
                ContractEndGr = x.ContractEnd,
                ContractNo = x.ContractNo,
                ArchiveCode = x.ArchiveCode,
                IsActiveString = x.IsActiveString,
                GetWorkDate = x.GetWorkDate.ToFarsi(),
                SetContractDate = x.SetContractDate.ToFarsi(),
                JobType = x.JobType,
                ContractType = x.ContractType,
                WorkshopAddress1 = x.WorkshopAddress1,
                WorkshopAddress2 = x.WorkshopAddress2,
                JobTypeId = x.JobTypeId,
                ConsumableItems = x.ConsumableItems,
                FamilyAllowance = x.FamilyAllowance,
                ContractPeriod = x.ContractPeriod,
                Signature = x.Signature




            });
            if (searchModel.WorkshopIds != 0)
                query = query.Where(x => x.WorkshopIds == searchModel.WorkshopIds);
            if (searchModel.EmployeeId != 0)
                query = query.Where(x => x.EmployeeId == searchModel.EmployeeId);
            if (searchModel.EmployerId != 0)
            {

                query = query.Where(x => emp.Contains(x.WorkshopIds));

            }
            if (!string.IsNullOrWhiteSpace(searchModel.ContractNo))
                query = query.Where(x => x.ContractNo == searchModel.ContractNo);

            if (!string.IsNullOrWhiteSpace(searchModel.ContractPeriod))
                query = query.Where(x => x.ContractPeriod == searchModel.ContractPeriod);

            if (!string.IsNullOrWhiteSpace(searchModel.Year))
            {
                var y = searchModel.Year + "/01" + "/29";
                var start = y.ToGeorgianDateTime();
 
                query = query.Where(x => x.ContractEndGr.Year == start.Year);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Year) && !string.IsNullOrWhiteSpace(searchModel.Month))
            {
                var y = searchModel.Year + "/" + searchModel.Month + "/01";
                string y2 = string.Empty;
                int month = Convert.ToInt32(searchModel.Month);
                int year= Convert.ToInt32(searchModel.Year);

                if (month <= 6)
                {
                    y2 =$"{searchModel.Year}/{searchModel.Month}/31";
                }
                else if (month > 6 && month < 12)
                {
                   y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                }
                else if (month == 12)
                {
                    switch (year)
                    {
                        case 1346:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1350:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1354:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1358:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1362:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1366:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1370:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1375:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1379:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1383:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1387:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1391:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1395:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1399:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1403:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1408:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1412:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1416:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1420:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1424:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1428:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1432:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1436:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1441:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                        case 1445:
                            y2 = $"{searchModel.Year}/{searchModel.Month}/30";
                            break;
                          
                        default: y2 = $"{searchModel.Year}/{searchModel.Month}/29";
                            break;

                    }
                }

                var start = y.ToGeorgianDateTime();
                var end = y2.ToGeorgianDateTime();

                query = query.Where(x => x.ContractEndGr >= start && x.ContractEndGr <= end);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.ContarctStart) &&
                !string.IsNullOrWhiteSpace(searchModel.ContractEnd))
            {
                var start = searchModel.ContarctStart.ToGeorgianDateTime();
                var endd = searchModel.ContractEnd.ToGeorgianDateTime();
                query = query.Where(x =>
                    x.ContractStartGr >= start && x.ContractEndGr <= endd);
            }
               
            if (searchModel.IsActiveString == null)
            {
                query = query.Where(x => x.IsActiveString == "true");
            }

            if (searchModel.IsActiveString == "false")
            {
                query = query.Where(x => x.IsActiveString == "false");
            }
            else if (searchModel.IsActiveString == "both")
            {
                query = query.Where(x => x.IsActiveString == "false" || x.IsActiveString == "true");
            }
             query = query.Where(e => workshopAcounts.Contains(e.WorkshopIds));
            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<ContractViweModel> SearchForextension(ContractSearchModel searchModel)
        {
            var Allemplyee = _employeeApplication.GetEmployee();
            var Allemployer = _employerApplication.GetEmployers();
            var Allworkshop = _workshopApplication.GetWorkshop();
            var today = DateTime.Now;
            var faToday = string.Empty;
            var GrogorianThisMonthStart = new DateTime();
   

            int syear = 0;
            int smonth = 0;
            if (string.IsNullOrWhiteSpace(searchModel.ContarctStart)&& string.IsNullOrWhiteSpace(searchModel.ContractEnd))
            {
                if (searchModel.Month == "0" && searchModel.Year == "0")
                {
                    faToday = today.ToFarsi();
                }
                else
                {

                    faToday = $"{searchModel.Year}/{searchModel.Month}/01";
                }

                syear = Convert.ToInt32(faToday.Substring(0, 4));
                smonth = Convert.ToInt32(faToday.Substring(5, 2));


                var PersianStartMonth = new PersianDateTime(syear, smonth, 01);
                PersianStartMonth = PersianStartMonth.AddMonths(1);
                GrogorianThisMonthStart = PersianStartMonth.ToGregorianDateTime();
            }
            
            



      

            var query = _context.Contracts.Select(x => new ContractViweModel
            {
               
                Id = x.id,
                PersonnelCode = x.PersonnelCode,
                EmployerId = x.EmployerId,
                EmployeeId = x.EmployeeId,
                WorkshopIds = x.WorkshopIds,
                YearlySalaryId = x.YearlySalaryId,
                DayliWage = x.DayliWage,
                ContarctStart = x.ContarctStart.ToFarsi(),
                ContractEnd = x.ContractEnd.ToFarsi(),
                ContractStartGr = x.ContarctStart,
                ContractEndGr = x.ContractEnd,
                ContractNo = x.ContractNo,
                ArchiveCode = x.ArchiveCode,
                IsActiveString = x.IsActiveString,
                GetWorkDate = x.GetWorkDate.ToFarsi(),
                SetContractDate = x.SetContractDate.ToFarsi(),
                JobType = x.JobType,
                ContractType = x.ContractType,
                WorkshopAddress1 = x.WorkshopAddress1,
                WorkshopAddress2 = x.WorkshopAddress2,
                JobTypeId = x.JobTypeId,
                ConsumableItems = x.ConsumableItems,
                FamilyAllowance = x.FamilyAllowance,
                ContractPeriod = x.ContractPeriod,
                Signature = x.Signature,
          




            });

            if (searchModel.WorkshopIds != 0)
            {
                var step1 = _context.Contracts.Where(x =>
                        x.WorkshopIds == searchModel.WorkshopIds && x.IsActiveString=="true")
                    .GroupBy(x => x.EmployeeId).Select(x => x.Key).ToList();
                var contractData = new List<long>();
                foreach (var i in step1)
                {
                    if (string.IsNullOrWhiteSpace(searchModel.ContarctStart) && string.IsNullOrWhiteSpace(searchModel.ContractEnd))
                    {
                        var step2 = _context.Contracts.Where(x => x.EmployeeId == i && x.IsActiveString == "true")
                            .Where(x => x.ContarctStart < GrogorianThisMonthStart).OrderByDescending(x => x.ContarctStart);
                        var step3 = step2.Select(x => x.id).FirstOrDefault();

                        contractData.Add(step3);
                    }
                    else
                    {
                        var start = searchModel.ContarctStart.ToGeorgianDateTime();
                        var endd = searchModel.ContractEnd.ToGeorgianDateTime();
                        var step2 = _context.Contracts.Where(x => x.EmployeeId == i && x.IsActiveString == "true")
                            .Where(x => x.ContarctStart < endd).OrderByDescending(x => x.ContarctStart);
                        var step3 = step2.Select(x => x.id).FirstOrDefault();

                        contractData.Add(step3);
                    }


                }
                query = query.Where(e => contractData.Contains(e.Id))
                    .Where(x => x.WorkshopIds == searchModel.WorkshopIds);
                //if (string.IsNullOrWhiteSpace(searchModel.ContarctStart) &&
                //    string.IsNullOrWhiteSpace(searchModel.ContractEnd))
                //{
                //    query = query.Where(e => contractData.Contains(e.Id))
                //        .Where(x => x.WorkshopIds == searchModel.WorkshopIds);
                //}
                //else
                //{
                


                //    //var start = searchModel.ContarctStart.ToGeorgianDateTime();
                //    //var endd = searchModel.ContractEnd.ToGeorgianDateTime();
                //    //var step2 = _context.Contracts.Where(x => x.EmployeeId == i && x.IsActiveString == "true")
                //    //    .Where(x => x.ContarctStart >= start && x.ContractEnd <= endd).OrderByDescending(x => x.ContarctStart);
                //    //var step3 = step2.Select(x => x.id).FirstOrDefault();

                //    //contractData.Add(step3);

                //}




            }

            if (searchModel.EmployeeId != 0)
                query = query.Where(x => x.EmployeeId == searchModel.EmployeeId);
            var Join = new List<ContractViweModel>();
            IQueryable<ContractViweModel> newQuery = null;
            foreach (var item in query)
            {
                var employeeFullName = string.Empty;
                var employerFullName = string.Empty;
                var workshopName = string.Empty;
                var employeeF = Allemplyee.FirstOrDefault(x => x.Id == item.EmployeeId);
                if(employeeF != null)
                    employeeFullName = employeeF.EmployeeFullName;
                var employerF = Allemployer.FirstOrDefault(x => x.Id == item.EmployerId);
                if (employerF != null)
                    employerFullName = employerF.FullName;
                var workshopN = Allworkshop.FirstOrDefault(x => x.Id == item.WorkshopIds);
                if (workshopN != null)
                    workshopName = workshopN.WorkshopFullName;

                var a = new ContractViweModel
                {
                    Id = item.Id,
                    PersonnelCode = item.PersonnelCode,
                    EmployerId = item.EmployerId,
                    EmployeeId = item.EmployeeId,
                    WorkshopIds = item.WorkshopIds,
                    YearlySalaryId = item.YearlySalaryId,
                    DayliWage = item.DayliWage,
                    ContarctStart = item.ContarctStart,
                    ContractEnd = item.ContractEnd,
                    ContractStartGr = item.ContractStartGr,
                    ContractEndGr = item.ContractEndGr,
                    ContractNo = item.ContractNo,
                    ArchiveCode = item.ArchiveCode,
                    IsActiveString = item.IsActiveString,
                    GetWorkDate = item.GetWorkDate,
                    SetContractDate = item.SetContractDate,
                    JobType = item.JobType,
                    ContractType = item.ContractType,
                    WorkshopAddress1 = item.WorkshopAddress1,
                    WorkshopAddress2 = item.WorkshopAddress2,
                    JobTypeId = item.JobTypeId,
                    ConsumableItems = item.ConsumableItems,
                    FamilyAllowance = item.FamilyAllowance,
                    ContractPeriod = item.ContractPeriod,
                    Signature = item.Signature,
                    EmployeeName = employeeFullName,
                    EmployerName = employerFullName,
                    WorkshopName = workshopName,

                };
                 Join.Add(a);
                
            }

            query = Join.AsQueryable();
           
            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<ContractViweModel> PrintAll(List<long> id)
        {
            var emplyee = _employeeApplication.GetEmployee();
            var workshop = _workshopApplication.GetWorkshop();
            var workshopEmpList = GetWorkshopEmployer();
            var query = new List<ContractViweModel>();
            
            foreach (var item in id)
            {
                
                
                
                var c = _context.Contracts.Select(x => new ContractViweModel
                {
                    Id = x.id,
                    PersonnelCode = x.PersonnelCode,
                    EmployerId = x.EmployerId,
                    EmployeeId = x.EmployeeId,
                    WorkshopIds = x.WorkshopIds,
                    YearlySalaryId = x.YearlySalaryId,
                    DayliWage = x.DayliWage,
                    ContarctStart = x.ContarctStart.ToFarsi(),
                    ContractEnd = x.ContractEnd.ToFarsi(),
                    ContractStartGr = x.ContarctStart,
                    ContractEndGr = x.ContractEnd,
                    ContractNo = x.ContractNo,
                    ArchiveCode = x.ArchiveCode,
                    IsActiveString = x.IsActiveString,
                    GetWorkDate = x.GetWorkDate.ToFarsi(),
                    SetContractDate = x.SetContractDate.ToFarsi(),
                    JobType = x.JobType,
                    ContractType = x.ContractType,
                    WorkshopAddress1 = x.WorkshopAddress1,
                    WorkshopAddress2 = x.WorkshopAddress2,
                    JobTypeId = x.JobTypeId,
                    ConsumableItems = x.ConsumableItems,
                    FamilyAllowance = x.FamilyAllowance,
                    ContractPeriod = x.ContractPeriod,
                    WorkingHoursWeekly = x.WorkingHoursWeekly,
                    HousingAllowance = x.HousingAllowance





                })
                    .SingleOrDefault(x => x.Id == item);
                var emp = workshopEmpList.Where(x => x.WorkshopId == c.WorkshopIds)
                    .Select(x => x.EmployerId).ToList();
                c.Employers = _employerRepository.GetEmployers(emp);
                c.Workshops = workshop.Where(x => x.Id == c.WorkshopIds).ToList();
                c.Employees = emplyee.Where(x => x.Id == c.EmployeeId).ToList();
                query.Add(c);
            }

            return query;
        }

        public IQueryable<WorkshopEmployerViewModel> GetWorkshopEmployer()
        {
            return _context.WorkshopEmployers.Select(x => new WorkshopEmployerViewModel
            {
                EmployerId = x.EmployerId,
                WorkshopId = x.WorkshopId
            });
        }

        public long FindPersonnelCode(long workshopId, long employeeId)
        {
            long personnelCode = 0;
            var employee = _context.Contracts.Any(x => x.EmployeeId == employeeId && x.WorkshopIds == workshopId);
            var exist = _context.Contracts.Any(x => x.WorkshopIds == workshopId && x.PersonnelCode > 0);
            if (exist && !employee)
            {
                var workshoplist = _context.Contracts.Where(x => x.WorkshopIds == workshopId).ToList();
                personnelCode = workshoplist.Max(x => x.PersonnelCode);
            }
            else
            {
                personnelCode = 0;
            }

            if (employee)
            {
                long pcode = 0;
                var p = _context.Contracts.FirstOrDefault(x => x.EmployeeId == employeeId && x.WorkshopIds==workshopId);
                if (p != null)
                {
                    pcode = p.PersonnelCode;
                }
            
                return pcode;
            }
            else
            {
                return personnelCode += 1;
            }
            
        }

        public string ContractStartCheck(DateTime cstart,long employeeId)
        {
            string duplicateMessage = "";
            var exist=_context.Contracts.Any(x => x.EmployeeId == employeeId && (x.ContarctStart <= cstart && x.ContractEnd >= cstart));
            if (exist)
            {
                var duplicate =_context.Contracts.FirstOrDefault(x => x.EmployeeId == employeeId && (x.ContarctStart <= cstart && x.ContractEnd >= cstart));
                duplicateMessage = $"این پرسنل یک قرار داد از تاریخ {duplicate.ContarctStart.ToFarsi()} تا تاریخ {duplicate.ContractEnd.ToFarsi()} دارد";
            }

            return duplicateMessage;
        }

        public bool CheckNextContractExist(long employeeId, DateTime startContract, DateTime endContract, long WorkshopId)
        {
            //var personelContracts = _context.Contracts.Where(x => x.EmployeeId == employeeId && x.WorkshopIds == WorkshopId && x.IsActiveString == "true")
            //    .OrderByDescending(x=>x.ContarctStart).ToList();
            //var checkLast = personelContracts.Select(x => x.ContarctStart).FirstOrDefault();
            var personelContracts1 = _context.Contracts.Any(x =>
                x.ContarctStart >= startContract && x.ContractEnd <= endContract && x.EmployeeId == employeeId && x.WorkshopIds == WorkshopId && x.IsActiveString == "true");
            var personelContracts2 = _context.Contracts.Any(x =>
                x.ContarctStart < startContract && x.ContractEnd <= endContract&& x.ContractEnd > startContract && x.EmployeeId == employeeId && x.WorkshopIds == WorkshopId && x.IsActiveString == "true");
            var personelContracts3 = _context.Contracts.Any(x =>
                x.ContarctStart >= startContract && x.ContarctStart < endContract && x.ContractEnd > endContract && x.EmployeeId == employeeId && x.WorkshopIds == WorkshopId && x.IsActiveString == "true");

            if (personelContracts1 || personelContracts2 || personelContracts3)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CkeckBetween(long employeeId, DateTime EndOfContract, DateTime StartOfExtension, long WorkshopId)
        {
            var personelContracts = _context.Contracts.Any(x =>
                x.ContarctStart >= EndOfContract && x.ContractEnd <= StartOfExtension && x.EmployeeId == employeeId && x.WorkshopIds == WorkshopId && x.IsActiveString == "true");
            if (personelContracts)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
