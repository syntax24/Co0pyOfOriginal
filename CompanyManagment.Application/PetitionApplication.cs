using System;
using System.Collections.Generic;
using _0_Framework.Application;
using Company.Domain.Petition;
using Company.Domain.WorkHistory;
using CompanyManagment.App.Contracts.Petition;

namespace CompanyManagment.Application
{
    public class PetitionApplication : IPetitionApplication
    {
        private readonly IPetitionRepository _petitionRepository;
        private readonly IWorkHistoryRepository _workHistoryRepository;

        public PetitionApplication(IPetitionRepository petitionRepository)
        {
            _petitionRepository = petitionRepository;
        }

        public OperationResult Create(CreatePetition command)
        {
            var operation = new OperationResult();
            var petitionIssuanceDate = new DateTime();
            var notificationPetitionDate = new DateTime();

            petitionIssuanceDate = command.PetitionIssuanceDate.ToGeorgianDateTime();
            notificationPetitionDate = command.NotificationPetitionDate.ToGeorgianDateTime();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var petition = new Petition(petitionIssuanceDate, notificationPetitionDate,
                command.TotalPenalty, command.TotalPenaltyTitles, command.Description, command.BoardType_Id, command.File_Id);
            _petitionRepository.Create(petition);
            _petitionRepository.SaveChanges();

            

            return operation.Succcedded(entityId: petition.id);
        }

        public OperationResult Edit(EditPetition command)
        {
            var operation = new OperationResult();
            var petition = _petitionRepository.Get(command.Id);
            var petitionIssuanceDate = new DateTime();
            var notificationPetitionDate = new DateTime();

            petitionIssuanceDate = command.PetitionIssuanceDate.ToGeorgianDateTime();
            notificationPetitionDate = command.NotificationPetitionDate.ToGeorgianDateTime();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            petition.Edit(petitionIssuanceDate, notificationPetitionDate,
                command.TotalPenalty, command.TotalPenaltyTitles, command.Description, command.BoardType_Id, command.File_Id);
            _petitionRepository.SaveChanges();

            return operation.Succcedded(entityId: petition.id);
        }

        public EditPetition GetDetails(long id)
        {
            return _petitionRepository.GetDetails(id);
        }
        
        public EditPetition GetDetails(long fileId, int boardTypeId)
        {
            return _petitionRepository.GetDetails(fileId, boardTypeId);
        }

        public List<EditPetition> Search(PetitionSearchModel searchModel)
        {
            return _petitionRepository.Search(searchModel);
        }
    }
}
