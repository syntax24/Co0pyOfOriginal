using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.WorkingHoursItemsAgg;
using CompanyManagment.App.Contracts.WorkingHours;
using CompanyManagment.App.Contracts.WorkingHoursItems;

namespace CompanyManagment.Application
{
    public class WorkingHoursItemsApplication : IWorkingHoursItemsApplication
    {
        private readonly IWorkingHoursItemsRepository _workingHoursItemsRepository;

        public WorkingHoursItemsApplication(IWorkingHoursItemsRepository workingHoursItemsRepository)
        {
            _workingHoursItemsRepository = workingHoursItemsRepository;
        }


        public OperationResult Create(CreateWorkingHoursItems command)
        {
            var op = new OperationResult();

            var create = new WorkingHoursItems(command.DayOfWork,command.Start1,command.End1,command.RestTime,
                command.Start2,command.End2,command.Start3,command.End3,command.ComplexStart,command.ComplexEnd,
                command.WorkingHoursId);
            _workingHoursItemsRepository.Create(create);
            _workingHoursItemsRepository.SaveChanges();

            return op.Succcedded();
        }

        public OperationResult Edit(EditWorkingHoursItems command)
        {
            var op = new OperationResult();
            var edit = _workingHoursItemsRepository.Get(command.Id);
            edit.Edit(command.DayOfWork, command.Start1, command.End1, command.RestTime,
                command.Start2, command.End2, command.Start3, command.End3, command.ComplexStart, command.ComplexEnd,
                command.WorkingHoursId);
            _workingHoursItemsRepository.SaveChanges();

            return op.Succcedded();
        }

        public EditWorkingHoursItems GetDetails(long id)
        {
            return _workingHoursItemsRepository.GetDetails(id);
        }

        public List<WorkingHoursItemsViewModel> GetWorkingHoursItems()
        {
            return _workingHoursItemsRepository.GetWorkingHoursItems();
        }

        public WorkingHoursItemsViewModel GetByWorkingHoursId(long id)
        {
            return _workingHoursItemsRepository.GetByWorkingHoursId(id);
        }
    }
}
