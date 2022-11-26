using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.WorkHistory;
using CompanyManagment.App.Contracts.WorkHistory;

namespace CompanyManagment.Application
{
    public class WorkHistoryApplication : IWorkHistoryApplication
    {
        private readonly IWorkHistoryRepository _workHistoryRepository;

        public WorkHistoryApplication(IWorkHistoryRepository fileRepository)
        {
            _workHistoryRepository = fileRepository;
        }

        public OperationResult Create(CreateWorkHistory command)
        {
            var operation = new OperationResult();

            var fromDate = new DateTime();
            fromDate = command.FromDate.ToGeorgianDateTime();

            var toDate = new DateTime();
            toDate = command.ToDate.ToGeorgianDateTime();

            //TODO if
            //if (_BoardRepository.Exists(x => x.Branch == command.Branch))
            //        operation.Failed("fail message")

            var workHistory = new WorkHistory(fromDate, toDate, command.WorkingHoursPerDay == null ? null : int.Parse(command.WorkingHoursPerDay), command.WorkingHoursPerWeek == null ? null : int.Parse(command.WorkingHoursPerWeek), command.Description, command.Petition_Id);
            _workHistoryRepository.Create(workHistory);
            _workHistoryRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult Edit(EditWorkHistory command)
        {
            var operation = new OperationResult();
            var workHistory = _workHistoryRepository.Get(command.Id);

            //var fromDate = new DateTime();
            //fromDate = command.FromDate.ToGeorgian();

            //var toDate = new DateTime();
            //toDate = command.ToDate.ToGeorgian();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            //workHistory.Edit(fromDate, toDate, command.WorkingHoursPerDay, command.WorkingHoursPerWeek, command.Description,command.Petition_Id);
            //_workHistoryRepository.SaveChanges();

            return operation.Succcedded();
        }

        public List<EditWorkHistory> Search(long petitionId)
        {
            return _workHistoryRepository.Search(petitionId);
        }

        public OperationResult CreateWorkHistories(List<EditWorkHistory> workHistories, long petitionId)
        {
            var operation = new OperationResult();

            RemoveWorkHistories(petitionId);

            foreach (var obj in workHistories)
            {
                if(obj.FromDate != null || obj.ToDate != null || obj.Description != null)
                {
                    obj.Petition_Id = petitionId;
                    obj.Id = 0;

                    Create(obj);
                }
            }

            return operation.Succcedded();
        }

        public void RemoveWorkHistories(long petitionId)
        {
            var objects = Search(petitionId);

            _workHistoryRepository.RemoveWorkHistories(objects);
        }

    }
}
