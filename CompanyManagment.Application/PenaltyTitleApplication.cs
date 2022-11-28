using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.PenaltyTitle;
using CompanyManagment.App.Contracts.PenaltyTitle;

namespace CompanyManagment.Application
{
    public class PenaltyTitleApplication : IPenaltyTitleApplication
    {
        private readonly IPenaltyTitleRepository _penaltyTitleRepository;

        public PenaltyTitleApplication(IPenaltyTitleRepository penaltyTitleRepository)
        {
            _penaltyTitleRepository = penaltyTitleRepository;
        }

        public OperationResult Create(CreatePenaltyTitle command)
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

            var penaltyTitle = new PenaltyTitle(FromDate, ToDate, command.Title, command.Day, command.Petition_Id, command.PaidAmount, command.RemainingAmount);
            _penaltyTitleRepository.Create(penaltyTitle);
            _penaltyTitleRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult CreatePenaltyTitles(List<EditPenaltyTitle> penaltyTitles, long petitionId)
        {
            var operation = new OperationResult();

            RemovePenaltyTitles(petitionId);

            foreach (var obj in penaltyTitles)
            {
                if(obj.PaidAmount != null || obj.RemainingAmount != null || obj.Title != null || obj.FromDate != null || obj.ToDate != null || obj.Day != null )
                {
                    if ((obj.FromDate == null && obj.ToDate != null) || (obj.FromDate != null && obj.ToDate == null))
                        return operation.Failed("لطفا تاریخ جزئیات دادنامه را وارد نمایید");

                    obj.Petition_Id = petitionId;
                    obj.Id = 0;

                    Create(obj);
                }
            }

            return operation.Succcedded();
        }

        public OperationResult Edit(EditPenaltyTitle command)
        {
            var operation = new OperationResult();
            var penaltyTitle = _penaltyTitleRepository.Get(command.Id);

            var FromDate = new DateTime();
            FromDate = command.FromDate.ToGeorgianDateTime();

            var ToDate = new DateTime();
            ToDate = command.ToDate.ToGeorgianDateTime();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            penaltyTitle.Edit(FromDate, ToDate, command.Title, command.Day, command.Petition_Id, command.PaidAmount, command.RemainingAmount);
            _penaltyTitleRepository.SaveChanges();

            return operation.Succcedded();
        }

        public void RemovePenaltyTitles(long petitionId)
        {
            var objects = Search(petitionId);

            _penaltyTitleRepository.RemovePenaltyTitles(objects);
        }

        public List<EditPenaltyTitle> Search(long petitionId)
        {
            return _penaltyTitleRepository.Search(petitionId);
        }
    }
}
