using System;
using System.Collections.Generic;
using _0_Framework.Application;
using Company.Domain.MasterWorkHistory;
using CompanyManagment.App.Contracts.MasterWorkHistory;

namespace CompanyManagment.Application
{
    public class MasterWorkHistoryApplication : IMasterWorkHistoryApplication
    {
        private readonly IMasterWorkHistoryRepository _masterWorkHistoryRepository;

        public MasterWorkHistoryApplication(IMasterWorkHistoryRepository fileRepository)
        {
            _masterWorkHistoryRepository = fileRepository;
        }

        public OperationResult Create(CreateMasterWorkHistory command)
        {
            var operation = new OperationResult();

            var fromDate = new DateTime();
            fromDate = command.FromDate.ToGeorgianDateTime();

            var toDate = new DateTime();
            toDate = command.ToDate.ToGeorgianDateTime();

            //TODO if
            //if (_BoardRepository.Exists(x => x.Branch == command.Branch))
            //        operation.Failed("fail message")

            var masterWorkHistory = new MasterWorkHistory(fromDate, toDate, command.WorkingHoursPerDay == null ? null : int.Parse(command.WorkingHoursPerDay), command.WorkingHoursPerWeek == null ? null : int.Parse(command.WorkingHoursPerWeek), command.Description, command.MasterPetition_Id);
            _masterWorkHistoryRepository.Create(masterWorkHistory);
            _masterWorkHistoryRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult Edit(EditMasterWorkHistory command)
        {
            var operation = new OperationResult();
            var masterWorkHistory = _masterWorkHistoryRepository.Get(command.Id);

            //var fromDate = new DateTime();
            //fromDate = command.FromDate.ToGeorgian();

            //var toDate = new DateTime();
            //toDate = command.ToDate.ToGeorgian();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            //masterWorkHistory.Edit(fromDate, toDate, command.WorkingHoursPerDay, command.WorkingHoursPerWeek, command.Description,command.Petition_Id);
            //_masterWorkHistoryRepository.SaveChanges();

            return operation.Succcedded();
        }

        public List<EditMasterWorkHistory> Search(long masterPetitionId)
        {
            return _masterWorkHistoryRepository.Search(masterPetitionId);
        }

        public OperationResult CreateMasterWorkHistories(List<EditMasterWorkHistory> masterWorkHistories, long masterPetitionId)
        {
            var operation = new OperationResult();

            RemoveMasterWorkHistories(masterPetitionId);

            foreach (var obj in masterWorkHistories)
            {
                if(obj.FromDate != null || obj.ToDate != null)
                {
                    obj.MasterPetition_Id = masterPetitionId;
                    obj.Id = 0;

                    Create(obj);
                }
            }

            return operation.Succcedded();
        }

        public void RemoveMasterWorkHistories(long masterPetitionId)
        {
            var objects = Search(masterPetitionId);

            _masterWorkHistoryRepository.RemoveMasterWorkHistories(objects);
        }

    }
}
