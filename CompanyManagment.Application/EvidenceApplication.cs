using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.Evidence;
using Company.Domain.EvidenceDetail;
using CompanyManagment.App.Contracts.Evidence;

namespace CompanyManagment.Application
{
    public class EvidenceApplication : IEvidenceApplication
    {
        private readonly IEvidenceRepository _evidenceRepository;

        public EvidenceApplication(IEvidenceRepository evidenceRepository)
        {
            _evidenceRepository = evidenceRepository;
        }

        public OperationResult Create(CreateEvidence command)
        {
            var operation = new OperationResult();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var evidence = new Evidence(command.Description, command.BoardType_Id, command.File_Id);
            _evidenceRepository.Create(evidence);
            _evidenceRepository.SaveChanges();

            

            return operation.Succcedded(entityId: evidence.id);
        }

        public OperationResult Edit(EditEvidence command)
        {
            var operation = new OperationResult();
            var evidence = _evidenceRepository.Get(command.Id);

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            evidence.Edit(command.Description, command.BoardType_Id, command.File_Id);
            _evidenceRepository.SaveChanges();

            return operation.Succcedded(entityId: evidence.id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            _evidenceRepository.Remove(id);
            _evidenceRepository.SaveChanges();

            return operation.Succcedded("اطلاعات مدارک با موفقیت حذف شد");
        }

        public EditEvidence GetDetails(long id)
        {
            return _evidenceRepository.GetDetails(id);
        }
        
        public EditEvidence GetDetails(long fileId, int boardTypeId)
        {
            return _evidenceRepository.GetDetails(fileId, boardTypeId);
        }

        public List<EditEvidence> Search(EvidenceSearchModel searchModel)
        {
            return _evidenceRepository.Search(searchModel);
        }
    }
}
