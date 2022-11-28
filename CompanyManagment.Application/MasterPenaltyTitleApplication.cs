using System;
using System.Collections.Generic;
using _0_Framework.Application;
using Company.Domain.MasterPenaltyTitle;
using CompanyManagment.App.Contracts.MasterPenaltyTitle;

namespace CompanyManagment.Application
{
    public class MasterPenaltyTitleApplication : IMasterPenaltyTitleApplication
    {
        private readonly IMasterPenaltyTitleRepository _masterPenaltyTitleRepository;

        public MasterPenaltyTitleApplication(IMasterPenaltyTitleRepository masterPenaltyTitleRepository)
        {
            _masterPenaltyTitleRepository = masterPenaltyTitleRepository;
        }

        public OperationResult Create(CreateMasterPenaltyTitle command)
        {
            var operation = new OperationResult();
            DateTime? FromDate = null;
            DateTime? ToDate = null;

            if (command.FromDate != null)
            {
                //FromDate = new DateTime();
                FromDate = command.FromDate.ToGeorgianDateTime();
            }

            if (command.ToDate != null)
            {
                //var ToDate = new DateTime();
                ToDate = command.ToDate.ToGeorgianDateTime();
            }

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var masterPenaltyTitle = new MasterPenaltyTitle(FromDate, ToDate, command.Title, command.Day, command.MasterPetition_Id, command.PaidAmount, command.RemainingAmount);
            _masterPenaltyTitleRepository.Create(masterPenaltyTitle);
            _masterPenaltyTitleRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult CreateMasterPenaltyTitles(List<EditMasterPenaltyTitle> masterPenaltyTitles, long masterPetitionId)
        {
            var operation = new OperationResult();

            RemoveMasterPenaltyTitles(masterPetitionId);

            foreach (var obj in masterPenaltyTitles)
            {
                if(obj.PaidAmount != null || obj.RemainingAmount != null || obj.Title != null || obj.FromDate != null || obj.ToDate != null || obj.Day != null )
                {
                    if ((obj.FromDate == null && obj.ToDate != null) || (obj.FromDate != null && obj.ToDate == null))
                        return operation.Failed("لطفا تاریخ جزئیات دادنامه را وارد نمایید");

                    obj.MasterPetition_Id = masterPetitionId;
                    obj.Id = 0;

                    Create(obj);
                }
            }

            return operation.Succcedded();
        }

        public OperationResult Edit(EditMasterPenaltyTitle command)
        {
            var operation = new OperationResult();
            var masterPenaltyTitle = _masterPenaltyTitleRepository.Get(command.Id);

            var FromDate = new DateTime();
            FromDate = command.FromDate.ToGeorgianDateTime();

            var ToDate = new DateTime();
            ToDate = command.ToDate.ToGeorgianDateTime();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            masterPenaltyTitle.Edit(FromDate, ToDate, command.Title, command.Day, command.MasterPetition_Id, command.PaidAmount, command.RemainingAmount);
            _masterPenaltyTitleRepository.SaveChanges();

            return operation.Succcedded();
        }

        public void RemoveMasterPenaltyTitles(long masterPetitionId)
        {
            var objects = Search(masterPetitionId);

            _masterPenaltyTitleRepository.RemoveMasterPenaltyTitles(objects);
            _masterPenaltyTitleRepository.SaveChanges();
        }

        public List<EditMasterPenaltyTitle> Search(long masterPetitionId)
        {
            return _masterPenaltyTitleRepository.Search(masterPetitionId);
        }
    }
}
