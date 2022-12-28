using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.YearlySalaryAgg;
using CompanyManagment.App.Contracts.YearlySalary;
using CompanyManagment.EFCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Application
{
    public class YearlySalaryApplication : IYearlySalaryApplication
    {
        private readonly IYearlySalaryRepository _yearlySalaryRepository;
        private readonly CompanyContext _context;

        public YearlySalaryApplication(IYearlySalaryRepository yearlySalaryRepository, CompanyContext context)
        {
            _yearlySalaryRepository = yearlySalaryRepository;
            _context = context;
        }


        public OperationResult Create(CreateYearlySalary command)
        {

          
            var start = command.StartDate.ToGeorgianDateTime();
            var end = command.EndDate.ToGeorgianDateTime();
            
            var operation = new OperationResult();
            if (_yearlySalaryRepository.Exists(x => x.StartDate == start && x.EndDate == end))
                return operation.Failed(" تاریخ شروع و پایان تکراری است");

            if (_yearlySalaryRepository.Exists(x => x.StartDate == start))
                return operation.Failed(" تاریخ شروع  تکراری است");

            if (_yearlySalaryRepository.Exists(x => x.EndDate == end))
                return operation.Failed(" تاریخ  پایان تکراری است");

            if (start == new DateTime(3000, 12, 20, new PersianCalendar()) && end == new DateTime(3000, 12, 20, new PersianCalendar()))
                return operation.Failed("تاریخ شروع و تاریخ پایان صحیح  وارد نشده اند");
            if(start == new DateTime(3000, 12, 20, new PersianCalendar()))
                return operation.Failed("تاریخ شروع صحیح  وارد نشده است");
            if (end == new DateTime(3000, 12, 20, new PersianCalendar()))
                return operation.Failed("تاریخ پایان صحیح  وارد نشده است");



            //var convertDailyWages = double.Parse(command.DailyWages.ToDoubleMoney());
            //if (convertDailyWages == 0)
            //    return operation.Failed("مبلغ مزد روزانه صحیح نیست");
            //var convertCommodityAllowance = double.Parse(command.CommodityAllowance.ToDoubleMoney());
            //if (convertCommodityAllowance == 0)
            //    return operation.Failed("مبلغ کمک هزینه اقلام صحیح نیست");
            //var convertBasicSalary = double.Parse(command.BasicSalary.ToDoubleMoney());
            //if (convertBasicSalary == 0)
            //    return operation.Failed("مبلغ مزد پایه صحیح نیست");
            //var convertHousingAllowance = double.Parse(command.HousingAllowance.ToDoubleMoney());
            //if (convertHousingAllowance == 0)
            //    return operation.Failed("مبلغ  کمک هزینه مسکن صحیح نیست");

            //var convertFixedWages = double.Parse(command.FixedWages.ToDoubleMoney());
            //if (convertFixedWages == 0)
            //    return operation.Failed("مبلغ مزد ثابت صحیح نیست");

            //connectionid += 1;
            var yearlySalaries = new YearlySalary(start, end, command.ConnectionId);
            _yearlySalaryRepository.Create(yearlySalaries);
            _yearlySalaryRepository.SaveChanges();
            return operation.Succcedded();
        }

        public OperationResult Edit(EditYearlySalary command)
        {
            var start = command.StartDate.ToGeorgianDateTime();
            var end = command.EndDate.ToGeorgianDateTime();
            var opration = new OperationResult();
            var yearlysalaryedit = _yearlySalaryRepository.Get(command.Id);
            if (yearlysalaryedit == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            if (_yearlySalaryRepository.Exists(x =>
                x.StartDate == start && x.EndDate == end && x.id != command.Id))
                return opration.Failed("تاریخ شروع و پایان تکراری است");
            if (_yearlySalaryRepository.Exists(x =>
                x.StartDate == start && x.id != command.Id))
                return opration.Failed("تاریخ شروع تکراری است");
            if (_yearlySalaryRepository.Exists(x =>
                x.EndDate == end && x.id != command.Id))
                return opration.Failed("تاریخ پایان تکراری است");


            if (start == new DateTime(3000, 12, 20, new PersianCalendar()) && end == new DateTime(3000, 12, 20, new PersianCalendar()))
                return opration.Failed("تاریخ شروع و تاریخ پایان صحیح  وارد نشده اند");
            if (start == new DateTime(3000, 12, 20, new PersianCalendar()))
                return opration.Failed("تاریخ شروع صحیح  وارد نشده است");
            if (end == new DateTime(3000, 12, 20, new PersianCalendar()))
                return opration.Failed("تاریخ پایان صحیح  وارد نشده است");




            yearlysalaryedit.Edit(start, end);
            _yearlySalaryRepository.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult Err()
        {
            var opration = new OperationResult();
            return opration.Failed("مقادیر نباید خالی باشند");
        }

        public EditYearlySalary GetDetails(long id)
        {
            return _yearlySalaryRepository.GetDetails(id);
        }

        public List<YearlySalaryViewModel> GetYearlySalary()
        {
            return _yearlySalaryRepository.GetYearlySalary();
        }

        public List<YearlySalaryViewModel> Search(YearlySalarySearchModel searchModel)
        {
            return _yearlySalaryRepository.Search(searchModel);
        }


       
    }
}
