using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.ContractAgg;
using Company.Domain.EmployeeAgg;
using Company.Domain.LeaveAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Leave;
using CompanyManagment.App.Contracts.Workshop;

namespace CompanyManagment.Application
{
    public class LeaveApplication : ILeaveApplication
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWorkshopRepository _workshopRepository;

        public LeaveApplication(ILeaveRepository leaveRepository, IEmployeeRepository employeeRepository, IWorkshopRepository workshopRepository)
        {
            _leaveRepository = leaveRepository;
         
            _employeeRepository = employeeRepository;
            _workshopRepository = workshopRepository;
        }

        public OperationResult Create(CreateLeave command)
        {
            var op = new OperationResult();
            if (command.PaidLeaveType == "روزانه")
            {
                if (string.IsNullOrWhiteSpace(command.EndLeave))
                {
                    return op.Failed("لطفا تاریخ پایان را وارد کنید");
                }

                if (string.IsNullOrWhiteSpace(command.StartLeave))
                {
                    return op.Failed("لطفا تاریخ شروع را وارد کنید");
                }
            }
            else if (command.PaidLeaveType == "ساعتی")
            {
               
               command.EndLeave = command.StartLeave;
               if (string.IsNullOrWhiteSpace(command.StartLeave))
               {
                   return op.Failed("لطفا تاریخ شروع را وارد کنید");
               }

            }

            if (command.LeaveType == "استعلاجی" && string.IsNullOrWhiteSpace(command.StartLeave))
                return op.Failed("لطفا تاریخ شروع را وارد کنید");
            if (command.LeaveType == "استعلاجی" && string.IsNullOrWhiteSpace(command.EndLeave))
                return op.Failed("لطفا تاریخ پایان را وارد کنید");


            var start = command.StartLeave.ToGeorgianDateTime();
            var end = command.EndLeave.ToGeorgianDateTime();
            var startInContactExist =
                _leaveRepository.CheckContractExist(start, command.EmployeeId, command.WorkshopId);
                
            var endInContractExist =
                _leaveRepository.CheckContractExist(end, command.EmployeeId, command.WorkshopId);
            if (_leaveRepository.Exists(x =>
                x.StartLeave <= start && x.EndLeave >= start && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
                return op.Failed("برای تاریخ شروع سابقه مرخصی وجود دارد");
            if (_leaveRepository.Exists(x =>
                x.StartLeave <= end && x.EndLeave >= end && x.EmployeeId == command.EmployeeId && x.WorkshopId == command.WorkshopId))
                return op.Failed("برای تاریخ پایان سابقه مرخصی وجود دارد");
            if (!startInContactExist || !endInContractExist)
                return op.Failed("برای تاریخ شروع یا پایان  وارد شده هیچ قراردادی وجود ندارد");
            if (start > end)
                return op.Failed("تارخ شروع از پایان بزرگتر است");
            if (command.PaidLeaveType == "ساعتی" && string.IsNullOrWhiteSpace(command.LeaveHourses))
                return op.Failed("لطفا فیلد ساعت را پر کنید");

            //var totalHoursbetween = new TimeSpan();
            //totalHoursbetween = (end - start);
            //var totalhoursInt = totalHoursbetween.TotalHours;
            //var totalhourses = totalhoursInt.ToString();
            var totalhourses = "-";
            if (command.LeaveType == "استحقاقی" && command.PaidLeaveType == "ساعتی")
                totalhourses = command.LeaveHourses;

            var employeeFullName = _employeeRepository.GetDetails(command.EmployeeId).EmployeeFullName;
            var workshopName = _workshopRepository.GetDetails(command.WorkshopId).WorkshopName;
            var leave = new Leave(start,end,totalhourses,command.WorkshopId,command.EmployeeId
            ,command.PaidLeaveType,command.LeaveType,employeeFullName,workshopName);
            _leaveRepository.Create(leave);
            _leaveRepository.SaveChanges();

            return op.Succcedded();



        }

        public OperationResult Edit(EditLeave command)
        {
            var op = new OperationResult();
            var leave = _leaveRepository.Get(command.Id);
            if (leave == null)
                op.Failed("رکورد مورد نظر وجود ندارد");

            if (command.PaidLeaveType == "روزانه")
            {
                if (string.IsNullOrWhiteSpace(command.EndLeave))
                {
                    return op.Failed("لطفا تاریخ پایان را وارد کنید");
                }

                if (string.IsNullOrWhiteSpace(command.StartLeave))
                {
                    return op.Failed("لطفا تاریخ شروع را وارد کنید");
                }
            }
            else if (command.PaidLeaveType == "ساعتی")
            {

                command.EndLeave = command.StartLeave;
                if (string.IsNullOrWhiteSpace(command.StartLeave))
                {
                    return op.Failed("لطفا تاریخ شروع را وارد کنید");
                }

            }

            if (command.LeaveType == "استعلاجی" && string.IsNullOrWhiteSpace(command.StartLeave))
                return op.Failed("لطفا تاریخ شروع را وارد کنید");
            if (command.LeaveType == "استعلاجی" && string.IsNullOrWhiteSpace(command.EndLeave))
                return op.Failed("لطفا تاریخ پایان را وارد کنید");
            var start = command.StartLeave.ToGeorgianDateTime();
            var end = command.EndLeave.ToGeorgianDateTime();
            var startInContactExist =
                _leaveRepository.CheckContractExist(start, command.EmployeeId, command.WorkshopId);

            var endInContractExist =
                _leaveRepository.CheckContractExist(end, command.EmployeeId, command.WorkshopId);

            if (_leaveRepository.Exists(x =>
                x.StartLeave <= start && x.EndLeave >= start && x.EmployeeId == command.EmployeeId 
                && x.WorkshopId == command.WorkshopId && x.id != command.Id))
                return op.Failed("برای تاریخ شروع سابقه مرخصی وجود دارد");
            if (_leaveRepository.Exists(x =>
                x.StartLeave <= end && x.EndLeave >= end && x.EmployeeId == command.EmployeeId
                && x.WorkshopId == command.WorkshopId && x.id != command.Id))
                return op.Failed("برای تاریخ پایان سابقه مرخصی وجود دارد");
            if (!startInContactExist || !endInContractExist)
                return op.Failed("برای تاریخ شروع یا پایان  وارد شده هیچ قراردادی وجود ندارد");
            if (start > end)
                return op.Failed("تارخ شروع از پایان بزرگتر است");
            if (command.PaidLeaveType == "ساعتی" && string.IsNullOrWhiteSpace(command.LeaveHourses))
                return op.Failed("لطفا فیلد ساعت را پر کنید");

            //var totalHoursbetween = new TimeSpan();
            //totalHoursbetween = (end - start);
            //var totalhoursInt = totalHoursbetween.Hours;
            //var totalhourses = totalhoursInt.ToString();
            var totalhourses = "-";
            if (command.LeaveType == "استحقاقی" && command.PaidLeaveType == "ساعتی")
                totalhourses = command.LeaveHourses;

            leave.Edit(start, end, totalhourses, command.WorkshopId, command.EmployeeId
                , command.PaidLeaveType, command.LeaveType, command.EmployeeFullName, command.WorkshopName);
            _leaveRepository.SaveChanges();
            return op.Succcedded();
        }

        public EditLeave GetDetails(long id)
        {
            return _leaveRepository.GetDetails(id);
        }

        public List<LeaveViewModel> search(LeaveSearchModel searchModel)
        {
            return _leaveRepository.search(searchModel);
        }

        public OperationResult RemoveLeave(long id)
        {
            return _leaveRepository.RemoveLeave(id);
        }
    }
}
