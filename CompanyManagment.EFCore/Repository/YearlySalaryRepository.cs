using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.ContractAgg;
using Company.Domain.YearlySalaryAgg;
using Company.Domain.YearlySalaryItemsAgg;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.LeftWork;
using CompanyManagment.App.Contracts.YearlySalary;
using CompanyManagment.App.Contracts.YearlySalaryItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersianTools.Core;

namespace CompanyManagment.EFCore.Repository
{
    public class YearlySalaryRepository : RepositoryBase<long, YearlySalary>, IYearlySalaryRepository
    {
        private readonly CompanyContext _context;

        public YearlySalaryRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }


        public List<YearlySalaryViewModel> GetYearlySalary()
        {
            return _context.YearlySalaries.Select(x => new YearlySalaryViewModel
            {
                Id = x.id,
                StartDate = x.StartDate.ToFarsi(),
                Year = x.Year


            })
                .OrderByDescending(x=>x.Year).ToList();
        }

        public string DayliFeeComputing(DateTime startDateW, DateTime contractStart, DateTime endDateW, long employeeId, long workshopId, List<LeftWorkViewModel> leftWorkList)
        {
            int oldYear = 0;
            var startPeriod = new DateTime();
            var endtPeriod = new DateTime();
            string finalResultMoney = string.Empty;
            double FinalResult = 0;
            int DayCounter = 0;
            int Max365 = 365;
            double Basic = 0;
            double BaseResult = 0;
            DateTime periodStarter = new DateTime();
            var salary = _context.YearlySalaries.OrderByDescending(x=>x.EndDate).Include(x => x.YearlySalaryItemsList).ToList();

   

            //var contractView = new List<Contract>();
            //var contractExist = _context.Contracts.Any(x=>x.EmployeeId == employeeId &&x.WorkshopIds == workshopId);

                //var contractView = _context.Contracts.Where(x => x.EmployeeId == employeeId).ToList();
                var startDateB = leftWorkList.OrderBy(x=>x.StartWorkDateGr).Select(x => x.StartWorkDate).FirstOrDefault();
                
                
                long loopDateId = 0;

              
                var syear = Convert.ToInt32(startDateB.Substring(0, 4));
                var smonth = Convert.ToInt32(startDateB.Substring(5, 2));
                var sday = Convert.ToInt32(startDateB.Substring(8, 2));
                var endDateConvert = endDateW.ToFarsi();
                var eyear = Convert.ToInt32(endDateConvert.Substring(0, 4));
                var emonth = Convert.ToInt32(endDateConvert.Substring(5, 2));
                var eday = Convert.ToInt32(endDateConvert.Substring(8, 2));

                var d1 = new PersianDateTime(syear, smonth, sday);  
                var d2 = new PersianDateTime(eyear, emonth, eday);

                var getWork = startDateB.ToGeorgianDateTime();
                var getWorkYear = syear - 1;
                oldYear = syear -1;
                var getWorkYearString = getWorkYear.ToString();
                //var getWorkSalary = salary.FirstOrDefault(x=>x.Year == getWorkYearString);
             
                var DayliSalaryStep1 = salary.FirstOrDefault(x => x.Year == getWorkYearString)
                    .YearlySalaryItemsList.Where(x => x.ItemName == "مزد روزانه").Select(x => x.ItemValue).FirstOrDefault();
                double firstDayliSalary = DayliSalaryStep1;
                for (var LoopDate = d1; LoopDate <= d2; LoopDate.AddDays(1))
                {
                    var loopdateYear = LoopDate.Year;
                    var LoopDateGr = LoopDate.ToGregorianDateTime();
                    var checkExist = salary.Any(x =>
                        x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId);
                    if (checkExist && loopdateYear > oldYear)
                    {
                       
                        var fixFeePercentage = salary.FirstOrDefault(x => x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId)
                            .YearlySalaryItemsList.Where(x => x.ItemName == "درصد مزد ثابت").Select(x => x.ItemValue).FirstOrDefault();
                        var fixFeePrice = salary.FirstOrDefault(x => x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId)
                            .YearlySalaryItemsList.Where(x => x.ItemName == "مبلغ مزد ثابت").Select(x => x.ItemValue).FirstOrDefault();


                        var percntSumDaylifee = (firstDayliSalary * fixFeePercentage) / 100;
                        var Sum = firstDayliSalary + percntSumDaylifee;
                        BaseResult = Sum + fixFeePrice;
                        //var rondUp = Convert.ToInt32(BaseResult);
                       
                        
                       

                        loopDateId = salary.Where(x => x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId).Select(x => x.id).FirstOrDefault();

                        oldYear = LoopDate.Year;
                    }
                
                    var check = leftWorkList.Any(x => x.StartWorkDateGr == LoopDateGr);
                    if (check)
                    {
                       var period = leftWorkList.FirstOrDefault(x => x.StartWorkDateGr == LoopDateGr);
                       startPeriod = period.StartWorkDateGr;
                       if (period.LeftWorkDate == "1500/01/01")
                       {
                           endtPeriod = endDateW;
                       }
                       else
                       {
                           var left = period.LeftWorkDateGr;
                           left = left.AddDays(-1);
                           endtPeriod = left;
                       }

                     
                    }
                      
                    
                    if (LoopDateGr >= startPeriod && LoopDateGr <= endtPeriod)
                    {
                        if (DayCounter == 0)
                        {
                            var date = LoopDate.ToString();
                            Max365 = date.FindeKabiseh();
                        }

                        DayCounter += 1;
                        
                        //periodStarter = startPeriod.ContractStartGr;
                    }

                    //var checkContracts = contractList.Any(x =>
                    //    x.ContractStartGr <= LoopDateGr && x.ContractEndGr >= LoopDateGr &&
                    //    x.ContractStartGr >= startPeriod.ContractStartGr);
                    //if (checkContracts && DayCounter < Max365 && LoopDateGr <= endDateW)
                    //{
                    //    if (DayCounter == 0)
                    //    {
                    //        var date = LoopDate.ToString();
                    //        Max365 = date.FindeKabiseh();
                    //    }
                    //    DayCounter += 1;
                    //}

                    //if (LoopDateGr >= contractStart && LoopDateGr <= endDateW && DayCounter < Max365)
                    //{
                    //    if (DayCounter == 0)
                    //    {
                    //        var date = LoopDate.ToString();
                    //        Max365 = date.FindeKabiseh();
                    //    }
                    //    DayCounter += 1;
                    //}
                    if (DayCounter == Max365)
                    {
                        var basicSalari =
                            salary.FirstOrDefault(x => x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr);
                        Basic = basicSalari
                            .YearlySalaryItemsList.Where(x => x.ItemName == "پایه سنوات").Select(x => x.ItemValue).FirstOrDefault();
                        BaseResult += Basic;
                        DayCounter = 0;
                    }

                    if (DayCounter == 366)
                    {
                        var a = DayCounter;
                    }


                    FinalResult = BaseResult;
                    firstDayliSalary = FinalResult;
                }
              
            //}
            //else
            //{
            //    var startDateB = startDateW.ToFarsi();

            //    long loopDateId = 0;


            //    var syear = Convert.ToInt32(startDateB.Substring(0, 4));
            //    var smonth = Convert.ToInt32(startDateB.Substring(5, 2));
            //    var sday = Convert.ToInt32(startDateB.Substring(8, 2));
            //    var d1 = new PersianDateTime(syear, smonth, sday);


            //    var endDateConvert = endDateW.ToFarsi();
            //    var eyear = Convert.ToInt32(endDateConvert.Substring(0, 4));
            //    var emonth = Convert.ToInt32(endDateConvert.Substring(5, 2));
            //    var eday = Convert.ToInt32(endDateConvert.Substring(8, 2));
            //    var d2 = new PersianDateTime(eyear, emonth, eday);
            //    var getWork = startDateB.ToGeorgianDateTime();
            //    var getWorkSalary = salary.FirstOrDefault(x => x.StartDate <= getWork && x.EndDate >= getWork);

            //    var DayliSalaryStep1 = salary.FirstOrDefault(x => x.EndDate < getWorkSalary.StartDate)
            //        .YearlySalaryItemsList.Where(x => x.ItemName == "مزد روزانه").Select(x => x.ItemValue).FirstOrDefault();
            //    double firstDayliSalary = DayliSalaryStep1;

            //    for (var LoopDate = d1; LoopDate <= d2; LoopDate.AddDays(1))
            //    {
            //        var LoopDateGr = LoopDate.ToGregorianDateTime();
            //        var checkExist = salary.Any(x =>
            //            x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId);
            //        if (checkExist)
            //        {

            //            var fixFeePercentage = salary.FirstOrDefault(x => x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId)
            //                .YearlySalaryItemsList.Where(x => x.ItemName == "درصد مزد ثابت").Select(x => x.ItemValue).FirstOrDefault();
            //            var fixFeePrice = salary.FirstOrDefault(x => x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId)
            //                .YearlySalaryItemsList.Where(x => x.ItemName == "مبلغ مزد ثابت").Select(x => x.ItemValue).FirstOrDefault();


            //            var percntSumDaylifee = (firstDayliSalary * fixFeePercentage) / 100;
            //            var Sum = firstDayliSalary + percntSumDaylifee;
            //            BaseResult = Sum + fixFeePrice;
            //            //var rondUp = Convert.ToInt32(BaseResult);




            //            loopDateId = salary.Where(x => x.StartDate <= LoopDateGr && x.EndDate >= LoopDateGr && x.id != loopDateId).Select(x => x.id).FirstOrDefault();


            //        }

   

            //        if (LoopDateGr >= contractStart && LoopDateGr <= endDateW && DayCounter < Max365)
            //        {
            //            if (DayCounter == 0)
            //            {
            //                var date = LoopDate.ToString();
            //                Max365 = date.FindeKabiseh();
            //            }
            //            DayCounter += 1;
            //        }
            //        if (DayCounter == Max365)
            //        {
            //            var basicSalari =
            //                salary.FirstOrDefault(x => x.StartDate <= LoopDateGr && x.EndDate > LoopDateGr);
            //            Basic = basicSalari
            //                .YearlySalaryItemsList.Where(x => x.ItemName == "پایه سنوات").Select(x => x.ItemValue).FirstOrDefault();
            //            BaseResult += Basic;
            //            DayCounter = 0;
            //        }




            //        FinalResult = BaseResult;
            //        firstDayliSalary = FinalResult;
            //    }
            //}







           //=====================================//
         
            //var startDateConvert = startDateW.ToFarsi();
            //var syear = Convert.ToInt32(startDateConvert.Substring(0, 4));
            //var smonth = Convert.ToInt32(startDateConvert.Substring(5, 2));
            //var sday = Convert.ToInt32(startDateConvert.Substring(8, 2));
            //var d1 = new PersianDateTime(syear, smonth, sday);
            //var NextYearFinder = new PersianDateTime(syear, smonth, sday);
            //var diff = new PersianDateTime(syear, smonth, sday);
           

            //var endDateConvert = endDateW.ToFarsi();
            //var eyear = Convert.ToInt32(endDateConvert.Substring(0, 4));
            //var emonth = Convert.ToInt32(endDateConvert.Substring(5, 2));
            //var eday = Convert.ToInt32(endDateConvert.Substring(8, 2));
            //var d2 = new PersianDateTime(eyear, emonth, eday);
            
            //var firstDate = new YearlySalary();
            //try
            //{
               
            //     firstDate = _context.YearlySalaries
            //        .SingleOrDefault(x => x.StartDate <= startDateW && x.EndDate >= startDateW);
            //}
            //catch (Exception e)
            //{
            //    finalResultMoney = " خطای ورود سال";
            //}
            
            //var FirstItems = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == firstDate.id && x.ItemName == "مزد روزانه");
            //var FirstFee = FirstItems.ItemValue;
            //long dateCompId = 0;
            //double result = 0;
            //double FinalResult = 0;
            //double basic = 0;
            //string checkOneYear = "false";
            //var DiffCheck = d2.DateDifference(diff);
            //var OneYear = NextYearFinder.AddYears(1);
            //var diff2 = OneYear.DateDifference(diff);

            //for (var dateComp = d1; dateComp <= d2; dateComp.AddMonths(1))
            //{
               
            //    var startDate = dateComp.ToGregorianDateTime();
            //    var yearlySalaryFinder = _context.YearlySalaries
            //        .FirstOrDefault(x => x.StartDate <= startDate && x.EndDate >= startDate && x.id != firstDate.id && x.id != dateCompId);
               

            //    if (yearlySalaryFinder != null)
            //    {
            //        dateCompId = yearlySalaryFinder.id;
            //        var FixFeePercent = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == dateCompId && x.ItemName == "درصد مزد ثابت").ItemValue;
            //        var FixFeePrice = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == dateCompId && x.ItemName == "مبلغ مزد ثابت").ItemValue;
            //        basic = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == dateCompId && x.ItemName == "پایه سنوات").ItemValue;
            //        var percntSumDaylifee = (FirstFee * FixFeePercent) / 100;
            //        var Sum = FirstFee + percntSumDaylifee;
            //        result = Sum + FixFeePrice; 
            //        var rondUp = Convert.ToInt32(result);
            //        result = rondUp;
            //        if (checkOneYear == "false")
            //        {
            //            FirstFee = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == dateCompId && x.ItemName == "مزد روزانه").ItemValue;
            //        }
                      
                    
                   
            //    }

            
                


            //    if (dateComp == OneYear)
            //    {
            //        basic = Convert.ToInt32(basic);
            //        FinalResult = result + basic;
            //        FirstFee = FinalResult;
            //        checkOneYear = "true";
            //        OneYear = OneYear.AddYears(1);
            //    }

            //    else if(d2 < OneYear)
            //    {
            //        FinalResult = result;
            //    }


            //}

            //if (DiffCheck < diff2)
            //    FinalResult = FirstFee;
            finalResultMoney = FinalResult.ToMoney();
            return finalResultMoney;
        }

        public string ConsumableItems(DateTime endDateW)
        {
           var endDateInput = _context.YearlySalaries
                .SingleOrDefault(x => x.StartDate <= endDateW && x.EndDate >= endDateW);
           var FirstItems = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == endDateInput.id && x.ItemName == "کمک هزینه اقلام");
           var res = FirstItems.ItemValue;
           var result = res.ToMoney();
           return result;
        }

        public string HousingAllowance(DateTime endDateW)
        {
            var endDateInput = _context.YearlySalaries
                .SingleOrDefault(x => x.StartDate <= endDateW && x.EndDate >= endDateW);
            var FirstItems = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == endDateInput.id && x.ItemName == "کمک هزینه مسکن");
            var res = FirstItems.ItemValue;
            var result = res.ToMoney();
            return result;
        }

        public string FamilyAllowance(long personelID, DateTime EndCantract)
        {
            DateTime zeroTime = new DateTime(1,1,1);
            TimeSpan Age = new TimeSpan();
            int childeNumber = 0;
       
            var endDateInput = _context.YearlySalaries
                .SingleOrDefault(x => x.StartDate <= EndCantract && x.EndDate >= EndCantract);
            var FirstItems = _context.YearlySalaryItems.SingleOrDefault(x => x.YearlySalaryId == endDateInput.id && x.ItemName == "مزد روزانه");
            var dayliSalary = FirstItems.ItemValue;
            var dayliSalar3 = dayliSalary * 3;
            try
            {
                var children = _context.EmployeeChildrenSet.Where(x => x.EmployeeId == personelID).ToList();
                var insuranceYearAndMonth = _context.Employees.SingleOrDefault(x => x.id == personelID);
                var yearI = Convert.ToInt32(insuranceYearAndMonth.InsuranceHistoryByYear);
                var monthI = Convert.ToInt32(insuranceYearAndMonth.InsuranceHistoryByMonth);
                yearI *= 365;
                monthI *= 30;
                var insurancHistoey = yearI + monthI;

                foreach (var item in children)
                {
                    Age = (EndCantract - item.DateOfBirth);
                    var ageUp18 = (zeroTime + Age).Year - 1; var res = ageUp18;
                    if (ageUp18 <= 18 && insurancHistoey >= 720)
                    {
                        childeNumber += 1;
                    }
                }
            }
            catch (Exception e)
            {
                childeNumber = 0;
            }

            var ress = dayliSalar3 * childeNumber;

            var result = ress.ToMoney();


            return result;
        }


        public EditYearlySalary GetDetails(long id)
        {
            return _context.YearlySalaries.Select(x => new EditYearlySalary
            {
                Id = x.id,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                ConnectionId = x.ConnectionId,






            }).FirstOrDefault(x => x.Id == id);
        }

        public List<YearlySalaryViewModel> Search(YearlySalarySearchModel searchModel)
        {
            var query = _context.YearlySalaries.Select(x => new YearlySalaryViewModel
            {
                Id = x.id,

                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                Year = x.Year,
                EndDate = x.EndDate.ToFarsi(),


            });

            if (!string.IsNullOrWhiteSpace(searchModel.year))
            {


                query = query.Where(x => x.Year == searchModel.year);
            }













            return query.OrderByDescending(x => x.StartDateGr).ToList();
        }

        public int FindConnection()
        {
            int connectionid = 0;
            var exist = _context.YearlySalaries.Any(x => x.ConnectionId > 0);
            if (exist)
            {
                connectionid = _context.YearlySalaries.Max(x => x.ConnectionId);
            }
            else
            {
                connectionid = 0;
            }
            return connectionid += 1;
        }
    }
}
