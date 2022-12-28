using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.EvidenceDetail;
using CompanyManagment.App.Contracts.EvidenceDetail;

namespace CompanyManagment.Application
{
    public class EvidenceDetailApplication : IEvidenceDetailApplication
    {
        private readonly IEvidenceDetailRepository _evidenceDetailRepository;

        public EvidenceDetailApplication(IEvidenceDetailRepository evidenceDetailRepository)
        {
            _evidenceDetailRepository = evidenceDetailRepository;
        }

        public OperationResult Create(CreateEvidenceDetail command)
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

            var evidenceDetail = new EvidenceDetail(FromDate, ToDate, command.Title, command.Day, command.Evidence_Id, command.Description);
            _evidenceDetailRepository.Create(evidenceDetail);
            _evidenceDetailRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult CreateEvidenceDetail(List<EditEvidenceDetail> evidenceDetails, long evidenceId)
        {
            var operation = new OperationResult();

            RemoveEvidenceDetails(evidenceId);

            foreach (var obj in evidenceDetails)
            {
                if(obj.Title != null || obj.FromDate != null || obj.ToDate != null || obj.Day != null || obj.Description != null )
                {
                    if ((obj.FromDate == null && obj.ToDate != null) || (obj.FromDate != null && obj.ToDate == null))
                        return operation.Failed("لطفا تاریخ جزئیات مدرک را وارد نمایید");

                    obj.Evidence_Id = evidenceId;
                    obj.Id = 0;

                    Create(obj);
                }
            }

            return operation.Succcedded();
        }

        public OperationResult Edit(EditEvidenceDetail command)
        {
            var operation = new OperationResult();
            var evidenceDetail = _evidenceDetailRepository.Get(command.Id);

            var FromDate = new DateTime();
            FromDate = command.FromDate.ToGeorgianDateTime();

            var ToDate = new DateTime();
            ToDate = command.ToDate.ToGeorgianDateTime();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            evidenceDetail.Edit(FromDate, ToDate, command.Title, command.Day, command.Evidence_Id, command.Description);
            _evidenceDetailRepository.SaveChanges();

            return operation.Succcedded();
        }

        public void RemoveEvidenceDetails(long evidenceId)
        {
            var objects = Search(evidenceId);

            _evidenceDetailRepository.RemoveEvidenceDetails(objects);
        }

        public List<EditEvidenceDetail> Search(long evidenceId)
        {
            return _evidenceDetailRepository.Search(evidenceId);
        }
    }
}
