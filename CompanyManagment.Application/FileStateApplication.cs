using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.FileState;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.FileState;

namespace CompanyManagment.Application
{
    public class FileStateApplication : IFileStateApplication
    {
        private readonly IFileStateRepository _fileStateRepository;

        public FileStateApplication(IFileStateRepository fileStateRepository)
        {
            _fileStateRepository = fileStateRepository;
        }

        public OperationResult Create(CreateFileState command)
        {
            var operation = new OperationResult();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var fileState = new FileState(command.State, command.FileTiming_Id, command.Title);
            //_fileStateRepository.Create(fileState);
            _fileStateRepository.SaveChanges();

            

            return operation.Succcedded(entityId: fileState.id);
        }

        public OperationResult Edit(EditFileState command)
        {
            var operation = new OperationResult();
            var fileState = _fileStateRepository.Get(command.Id);

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            //fileState.Edit(command.State, command.Type);
            _fileStateRepository.SaveChanges();

            return operation.Succcedded(entityId: fileState.id);
        }

        //public OperationResult Remove(long id)
        //{
        //    var operation = new OperationResult();

        //    _fileStateRepository.Remove(id);
        //    _fileStateRepository.SaveChanges();

        //    return operation.Succcedded("عنوان با موفقیت حذف شد");
        //}

        public FileStateViewModel GetDetails(long id)
        {
            return _fileStateRepository.GetDetails(id);
        }

        public List<EditFileState> Search(FileStateSearchModel searchModel)
        {
            return _fileStateRepository.Search(searchModel);
        }

        public int GetFileState(FileViewModel file)
        {
            //if (file.FileClass == null || (file.FileClass != null && file.DiagnosisBoard.DisputeResolutionPetitionDate == null))
            if (file.FileClass == null)
                return FileStateEnums.FILE_CLASS_NOT_REGISTERED;

            //if (file.HasMandate != 2 || (file.HasMandate == 2 && file.DiagnosisBoard.DisputeResolutionPetitionDate == null))
            if (file.HasMandate != 2)
                return FileStateEnums.MANDATE_NOT_REGISTERED;
            
            if (file.DiagnosisBoard.DisputeResolutionPetitionDate == null)
                return FileStateEnums.NO_PETITION_DATE_ISSUED;

            if (file.DiagnosisBoard.DisputeResolutionPetitionDate != null && file.DiagnosisPsCount == 0)
                return FileStateEnums.NO_DIAGNOSIS_INVITATION_ISSUED;

            if (file.DiagnosisPsCount != 0 && (file.DiagnosisPetition == null || file.DiagnosisPetition.Id == 0))
                return FileStateEnums.NO_DIAGNOSIS_PETITION_ISSUED;

            if ((file.DiagnosisPetition != null || file.DiagnosisPetition.Id != 0) && file.DisputeResolutionBoard.DisputeResolutionPetitionDate == null)
                return FileStateEnums.PROTEST_NOT_REGISTERED;

            if (file.DisputeResolutionBoard.DisputeResolutionPetitionDate != null && file.DisputeResolutionPsCount == 0)
                return FileStateEnums.NO_DISPUTE_INVITATION_ISSUED;

            if (file.DisputeResolutionPetition == null || file.DisputeResolutionPetition.Id == 0)
                return FileStateEnums.NO_DISPUTE_PETITION_ISSUED;

            return 0;
        }

        public DateTime? GetFileStateDate(FileViewModel file)
        {
            switch (file.State)
            {
                case FileStateEnums.FILE_CLASS_NOT_REGISTERED:
                    return file.ClientVisitDate.ToGeorgianDateTime();

                case FileStateEnums.MANDATE_NOT_REGISTERED:
                    return file.ClientVisitDate.ToGeorgianDateTime();
                
                case FileStateEnums.NO_PETITION_DATE_ISSUED:
                    return file.ClientVisitDate.ToGeorgianDateTime();

                case FileStateEnums.NO_DIAGNOSIS_INVITATION_ISSUED:
                    return file.DiagnosisBoard.DisputeResolutionPetitionDate.ToGeorgianDateTime();

                case FileStateEnums.NO_DIAGNOSIS_PETITION_ISSUED:
                    return file.LastDiagnosisPS.Date.ToGeorgianDateTime();

                case FileStateEnums.PROTEST_NOT_REGISTERED:
                    return file.DiagnosisPetition.NotificationPetitionDate.ToGeorgianDateTime();

                case FileStateEnums.NO_DISPUTE_INVITATION_ISSUED:
                    return file.DisputeResolutionBoard.DisputeResolutionPetitionDate.ToGeorgianDateTime();

                case FileStateEnums.NO_DISPUTE_PETITION_ISSUED:
                    return file.LastDisputeResolutionPS.Date.ToGeorgianDateTime();

                default:
                    return null;
            }
        }
    }
}
