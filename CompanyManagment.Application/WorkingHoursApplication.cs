using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.WorkingHoursAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.WorkingHours;
using CompanyManagment.App.Contracts.Workshop;

namespace CompanyManagment.Application
{
    public class WorkingHoursApplication : IWorkingHoursApplication
    {
        private readonly IWorkingHoursRepository _workingHoursRepository;

        public WorkingHoursApplication(IWorkingHoursRepository workingHoursRepository)
        {
            _workingHoursRepository = workingHoursRepository;
        }


        public OperationResult Create(CreateWorkingHours command)
        {
            var op = new OperationResult();
            var create = new WorkingHours(command.ShiftWork, command.ContractNo, command.NumberOfWorkingDays,
                command.NumberOfFriday, command.TotalHoursesH, command.TotalHoursesM,
                command.OverTimeWorkH, command.OverTimeWorkM, command.OverNightWorkH, command.OverNightWorkM,
                command.WeeklyWorkingTime,
                command.ContractId);
            _workingHoursRepository.Create(create);
            _workingHoursRepository.SaveChanges();

            return op.Succcedded($"{create.id}");
        }

        public OperationResult Edit(EditWorkingHours command)
        {
            var op = new OperationResult();
            var edit = _workingHoursRepository.Get(command.Id);
            edit.Edit(command.ShiftWork, command.ContractNo, command.NumberOfWorkingDays,
                command.NumberOfFriday, command.TotalHoursesH, command.TotalHoursesM,
                command.OverTimeWorkH, command.OverTimeWorkM, command.OverNightWorkH, command.OverNightWorkM,
                command.WeeklyWorkingTime,
                command.ContractId);
            _workingHoursRepository.SaveChanges();

            return op.Succcedded();
        }

        public EditWorkingHours GetDetails(long id)
        {
            return _workingHoursRepository.GetDetails(id);
        }

        public List<WorkingHoursViewModel> GetWorkingHours()
        {
            return _workingHoursRepository.GetWorkingHours();
        }

        public WorkingHoursViewModel GetByContractId(long id)
        {
            return _workingHoursRepository.GetByContractId(id);
        }
    }
}
