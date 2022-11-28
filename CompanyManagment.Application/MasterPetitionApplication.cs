using System;
using System.Collections.Generic;
using _0_Framework.Application;
using Company.Domain.MasterPetition;
using Company.Domain.MasterWorkHistory;
using CompanyManagment.App.Contracts.MasterPetition;

namespace CompanyManagment.Application
{
    public class MasterPetitionApplication : IMasterPetitionApplication
    {
        private readonly IMasterPetitionRepository _masterPetitionRepository;
        private readonly IMasterWorkHistoryRepository _MasterWorkHistoryRepository;

        public MasterPetitionApplication(IMasterPetitionRepository MasterPetitionRepository)
        {
            _masterPetitionRepository = MasterPetitionRepository;
        }

        public OperationResult Create(CreateMasterPetition command)
        {
            var operation = new OperationResult();
            //var petitionIssuanceDate = new DateTime();
            //var notificationPetitionDate = new DateTime();

            //petitionIssuanceDate = command.PetitionIssuanceDate.ToGeorgianDateTime();
            //notificationPetitionDate = command.NotificationPetitionDate.ToGeorgianDateTime();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var masterPetition = new MasterPetition(command.MasterName,
                command.Description, command.WorkHistoryDescription, command.BoardType_Id, command.File_Id);
            _masterPetitionRepository.Create(masterPetition);
            _masterPetitionRepository.SaveChanges();

            

            return operation.Succcedded(entityId: masterPetition.id);
        }

        public OperationResult Edit(EditMasterPetition command)
        {
            var operation = new OperationResult();
            var MasterPetition = _masterPetitionRepository.Get(command.Id);
            //var petitionIssuanceDate = new DateTime();
            //var notificationPetitionDate = new DateTime();

            //petitionIssuanceDate = command.PetitionIssuanceDate.ToGeorgianDateTime();
            //notificationPetitionDate = command.NotificationPetitionDate.ToGeorgianDateTime();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            MasterPetition.Edit(command.MasterName,
                command.Description, command.WorkHistoryDescription, command.BoardType_Id, command.File_Id);
            _masterPetitionRepository.SaveChanges();

            return operation.Succcedded(entityId: MasterPetition.id);
        }

        public EditMasterPetition GetDetails(long id)
        {
            return _masterPetitionRepository.GetDetails(id);
        }
        
        public EditMasterPetition GetDetails(long fileId, int boardTypeId)
        {
            return _masterPetitionRepository.GetDetails(fileId, boardTypeId);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            
            _masterPetitionRepository.Remove(id);
            _masterPetitionRepository.SaveChanges();

            return operation.Succcedded("اطلاعات کارشناسی با موفقیت حذف شد");
        }

        public List<EditMasterPetition> Search(MasterPetitionSearchModel searchModel)
        {
            return _masterPetitionRepository.Search(searchModel);
        }
    }
}
