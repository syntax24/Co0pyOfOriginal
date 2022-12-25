using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework_b.Application;
using Company.Domain.File1;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Evidence;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.MasterPenaltyTitle;
using CompanyManagment.App.Contracts.MasterPetition;
using CompanyManagment.App.Contracts.MasterWorkHistory;
using CompanyManagment.App.Contracts.PenaltyTitle;
using CompanyManagment.App.Contracts.Petition;
using CompanyManagment.App.Contracts.ProceedingSession;
using CompanyManagment.App.Contracts.WorkHistory;

namespace CompanyManagment.Application
{
    public class FileApplication : IFileApplication
    {
        private readonly IFileRepository _fileRepository;
        private readonly IBoardApplication _boardApplication;
        private readonly IPetitionApplication _petitionApplication;
        private readonly IProceedingSessionApplication _proceedingSessionApplication;
        private readonly IMasterPetitionApplication _masterPetitionApplication;
        private readonly IEvidenceApplication _evidenceApplication;
        private readonly IWorkHistoryApplication _workHistoryApplication;
        private readonly IPenaltyTitleApplication _penaltyTitleApplication;
        private readonly IMasterWorkHistoryApplication _masterWorkHistoryApplication;
        private readonly IMasterPenaltyTitleApplication _masterPenaltyTitleApplication;


        public FileApplication
        (
            IFileRepository fileRepository,
            IBoardApplication boardApplication,
            IPetitionApplication petitionApplication,
            IProceedingSessionApplication proceedingSessionApplication,
            IMasterPetitionApplication masterPetitionApplication,
            IEvidenceApplication evidenceApplication,
            IWorkHistoryApplication workHistoryApplication,
            IPenaltyTitleApplication penaltyTitleApplication,
            IMasterWorkHistoryApplication masterWorkHistoryApplication,
            IMasterPenaltyTitleApplication masterPenaltyTitleApplication
        )
        {
            _fileRepository = fileRepository;
            _boardApplication = boardApplication;
            _petitionApplication = petitionApplication;
            _proceedingSessionApplication = proceedingSessionApplication;
            _masterPetitionApplication = masterPetitionApplication;
            _evidenceApplication = evidenceApplication;
            _workHistoryApplication = workHistoryApplication;
            _penaltyTitleApplication = penaltyTitleApplication;
            _masterWorkHistoryApplication = masterWorkHistoryApplication;
            _masterPenaltyTitleApplication = masterPenaltyTitleApplication;


        }

        public OperationResult Create(CreateFile command)
        {
            var operation = new OperationResult();
            var clientVisitDate = new DateTime();

            clientVisitDate = command.ClientVisitDate.ToGeorgianDateTime();

            //TODO if
            if(_fileRepository.Exists(x=>x.ArchiveNo == command.ArchiveNo))
                return operation.Failed("شماره بایگانی تکراری است");

            var file = new Company.Domain.File1.File1(command.ArchiveNo, clientVisitDate, command.ProceederReference,
                command.Reqester, command.Summoned, command.Client, command.FileClass, command.HasMandate,
                command.Description);
            _fileRepository.Create(file);
            _fileRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult Edit(EditFile command)
        {
            var operation = new OperationResult();
            var file = _fileRepository.Get(command.Id);
            var clientVisitDate = new DateTime();

            if (command.ClientVisitDate != null)
            {
                
                clientVisitDate = command.ClientVisitDate.ToGeorgianDateTime();
            }
            else
            {
                clientVisitDate = file.ClientVisitDate;
            }


            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            file.Edit(command.ArchiveNo, clientVisitDate, command.ProceederReference,
                command.Reqester, command.Summoned, command.Client, command.FileClass, command.HasMandate,
                command.Description, command.Status);
            _fileRepository.SaveChanges();

            return operation.Succcedded();
        }

        public EditFile GetDetails(long id)
        {
            var file = _fileRepository.GetDetails(id);

            if (file.Client == 1)
            {
                file.ClientFullName = GetEmployeeFullNameById(file.Reqester);
                file.OppositePersonFullName = GetEmployerFullNameById(file.Summoned);
            }
            else
            {
                file.ClientFullName = GetEmployerFullNameById(file.Summoned);
                file.OppositePersonFullName = GetEmployeeFullNameById(file.Reqester);
            }

            return file;
        }

        public List<FileViewModel> Search(FileSearchModel searchModel)
        {
            return _fileRepository.Search(searchModel);
        }

        public FileViewModel GetLastArchiveNumber(FileSearchModel searchModel)
        {
            var model = Search(searchModel);

           return model.Count != 0 ? model.OrderByDescending(x => x.ArchiveNo).FirstOrDefault() : new FileViewModel { ArchiveNo = 0 };
        }
        public long FindLastArchiveNumber()
        {
            return _fileRepository.FindLastArchiveNumber();
        }

        public string GetEmployeeFullNameById(long id)
        {
            return _fileRepository.GetEmployeeFullNameById(id);
        }

        public string GetEmployerFullNameById(long id)
        {
            return _fileRepository.GetEmployerFullNameById(id);
        }

        public List<EmployeeViewModel> GetAllEmploees()
        {
            return _fileRepository.GetAllEmploees();
        }

        public List<EmployerViewModel> GetAllEmployers()
        {
            return _fileRepository.GetAllEmployers();
        }

        public FileViewModel GetFileDetails(FileViewModel file)
        {
            var viewModel = new FileViewModel();
            var searchModel = new FileSearchModel();

            if (searchModel.diagnosisBoard == null)
                searchModel.diagnosisBoard = new BoardSearchModel();

            if (searchModel.diagnosisProceedingSession == null)
                searchModel.diagnosisProceedingSession = new ProceedingSessionSearchModel();

            if (searchModel.disputeResolutionBoard == null)
                searchModel.disputeResolutionBoard = new BoardSearchModel();

            if (searchModel.disputeResolutionProceedingSession == null)
                searchModel.disputeResolutionProceedingSession =
                    new ProceedingSessionSearchModel();

            viewModel = file;

            searchModel.diagnosisBoard.File_Id = file.Id;
            searchModel.diagnosisBoard.BoardType_Id = 1;
            var diagnosisBoard =
                _boardApplication.Search(searchModel.diagnosisBoard).FirstOrDefault()
                ?? new EditBoard();

            searchModel.diagnosisProceedingSession.Board_Id = diagnosisBoard.Id;
            var diagnosisProceedingSessionList = _proceedingSessionApplication.Search(
                searchModel.diagnosisProceedingSession
            );

            //var diagnosisPsListCount = _proceedingSessionApplication.Search(searchModel.diagnosisProceedingSession).Count();
            var diagnosisPsListCount = diagnosisProceedingSessionList.Count();
            var firstDiagnosisProceedingSession = new EditProceedingSession();
            var lastDiagnosisProceedingSession = new EditProceedingSession();
            if (diagnosisProceedingSessionList.Count != 0)
            {
                firstDiagnosisProceedingSession = diagnosisProceedingSessionList.First();
                lastDiagnosisProceedingSession = diagnosisProceedingSessionList.Last();
            }

            var diagnosisPetition =
                _petitionApplication.GetDetails(file.Id, 1) ?? new EditPetition();

            searchModel.disputeResolutionBoard.File_Id = file.Id;
            searchModel.disputeResolutionBoard.BoardType_Id = 2;
            var disputeResolutionBoard =
                _boardApplication.Search(searchModel.disputeResolutionBoard).FirstOrDefault()
                ?? new EditBoard();

            searchModel.disputeResolutionProceedingSession.Board_Id = disputeResolutionBoard.Id;
            var disputeResolutionProceedingSessionList = _proceedingSessionApplication.Search(
                searchModel.disputeResolutionProceedingSession
            );

            var disputeResolutionPsListCount = disputeResolutionProceedingSessionList.Count();
            var firstDisputeResolutionProceedingSession = new EditProceedingSession();
            var lastDisputeResolutionProceedingSession = new EditProceedingSession();
            if (disputeResolutionProceedingSessionList.Count != 0)
            {
                firstDisputeResolutionProceedingSession =
                    disputeResolutionProceedingSessionList.First();
                lastDisputeResolutionProceedingSession =
                    disputeResolutionProceedingSessionList.Last();
            }

            var disputeResolutionPetition =
                _petitionApplication.GetDetails(file.Id, 2) ?? new EditPetition();

            viewModel.DiagnosisBoard = diagnosisBoard;
            viewModel.DiagnosisPsCount =
                firstDiagnosisProceedingSession.Id == lastDiagnosisProceedingSession.Id
                    ? diagnosisPsListCount
                    : diagnosisPsListCount - 1;
            viewModel.FirstDiagnosisPS = firstDiagnosisProceedingSession;
            viewModel.LastDiagnosisPS = lastDiagnosisProceedingSession;
            viewModel.DiagnosisPetition = diagnosisPetition;

            viewModel.DisputeResolutionBoard = disputeResolutionBoard;
            viewModel.DisputeResolutionPsCount =
                firstDisputeResolutionProceedingSession.Id
                == lastDisputeResolutionProceedingSession.Id
                    ? disputeResolutionPsListCount
                    : disputeResolutionPsListCount - 1;
            viewModel.FirstDisputeResolutionPS = firstDisputeResolutionProceedingSession;
            viewModel.LastDisputeResolutionPS = lastDisputeResolutionProceedingSession;
            viewModel.DisputeResolutionPetition = disputeResolutionPetition;

            var masterPetitions = _masterPetitionApplication.Search(new MasterPetitionSearchModel { File_Id = file.Id }).ToList();
            viewModel.DiagnosisMasterPetitionId = masterPetitions.Where(x => x.BoardType_Id == 1).FirstOrDefault() != null
                ? masterPetitions.Where(x => x.BoardType_Id == 1).FirstOrDefault().Id
                : 0;
            viewModel.DisputeResolutionMasterPetitionId = masterPetitions.Where(x => x.BoardType_Id == 2).FirstOrDefault() != null
                ? masterPetitions.Where(x => x.BoardType_Id == 2).FirstOrDefault().Id
                : 0;

            var evidences = _evidenceApplication.Search(new EvidenceSearchModel { File_Id = file.Id }).ToList();
            viewModel.DiagnosisEvidenceId = evidences.Where(x => x.BoardType_Id == 1).FirstOrDefault() != null
                ? evidences.Where(x => x.BoardType_Id == 1).FirstOrDefault().Id
                : 0;
            viewModel.DisputeResolutionEvidenceId = evidences.Where(x => x.BoardType_Id == 2).FirstOrDefault() != null
                ? evidences.Where(x => x.BoardType_Id == 2).FirstOrDefault().Id
                : 0;

            return viewModel;
        }

        public int GetFileState(FileViewModel file)
        {
            if (file.FileClass == null || (file.FileClass != null && file.DiagnosisBoard.DisputeResolutionPetitionDate == null))
                return 1;

            if (file.HasMandate != 2 || (file.HasMandate == 2 && file.DiagnosisBoard.DisputeResolutionPetitionDate == null))
                return 2;

            if (file.DiagnosisBoard.DisputeResolutionPetitionDate != null && file.DiagnosisPsCount == 0)
                return 3;

            if (file.DiagnosisPsCount != 0 && (file.DiagnosisPetition == null || file.DiagnosisPetition.Id == 0))
                return 4;

            if ((file.DiagnosisPetition != null || file.DiagnosisPetition.Id != 0) && file.DisputeResolutionBoard.DisputeResolutionPetitionDate == null)
                return 5;

            if (file.DisputeResolutionBoard.DisputeResolutionPetitionDate != null && file.DisputeResolutionPsCount == 0)
                return 6;

            if (file.DisputeResolutionPetition == null || file.DisputeResolutionPetition.Id == 0)
                return 7;

            return 0;
        }

        public DateTime? GetFileStateDate(FileViewModel file)
        {
            switch (file.State)
            {
                case 1:
                    return file.ClientVisitDate.ToGeorgianDateTime();

                case 2:
                    return file.ClientVisitDate.ToGeorgianDateTime();

                case 3:
                    return file.DiagnosisBoard.DisputeResolutionPetitionDate.ToGeorgianDateTime();

                case 4:
                    return file.LastDiagnosisPS.Date.ToGeorgianDateTime();

                case 5:
                    return file.DiagnosisPetition.NotificationPetitionDate.ToGeorgianDateTime();

                case 6:
                    return file.DisputeResolutionBoard.DisputeResolutionPetitionDate.ToGeorgianDateTime();

                case 7:
                    return file.LastDisputeResolutionPS.Date.ToGeorgianDateTime();

                default:
                    return null;
            }
        }

        public bool FilterFileDetails(FileViewModel tempViewModel, FileSearchModel fileSearchModel)
        {
            if (fileSearchModel == null)
                return true;

            if (fileSearchModel.ArchiveNo != null && !CheckValue(tempViewModel.ArchiveNo.ToString(), fileSearchModel.ArchiveNo))
                return false;

            if (fileSearchModel.FileClass != null && !CheckValue(tempViewModel.FileClass, fileSearchModel.FileClass))
                return false;

            if (fileSearchModel.UserId != 0 && !(fileSearchModel.UserId == tempViewModel.Summoned || fileSearchModel.UserId == tempViewModel.Reqester))
                return false;

            if (fileSearchModel.diagnosisBoard.Branch != null && !CheckValue(tempViewModel.DiagnosisBoard.Branch, fileSearchModel.diagnosisBoard.Branch))
                return false;

            if (fileSearchModel.disputeResolutionBoard.Branch != null && !CheckValue(tempViewModel.DisputeResolutionBoard.Branch, fileSearchModel.disputeResolutionBoard.Branch))
                return false;

            if (fileSearchModel.diagnosisProceedingSession.FromDate != null)
            {
                if (tempViewModel.FirstDiagnosisPS.Date == null)
                    return false;
                if (tempViewModel.FirstDiagnosisPS.Date.ToGeorgianDateTime() < fileSearchModel.diagnosisProceedingSession.FromDate.ToGeorgianDateTime())
                    return false;
            }

            if (fileSearchModel.disputeResolutionProceedingSession.FromDate != null)
            {
                if (tempViewModel.FirstDisputeResolutionPS.Date == null)
                    return false;
                if (tempViewModel.FirstDisputeResolutionPS.Date.ToGeorgianDateTime() < fileSearchModel.disputeResolutionProceedingSession.FromDate.ToGeorgianDateTime())
                    return false;
            }

            if (fileSearchModel.diagnosisProceedingSession.ToDate != null)
            {
                if (tempViewModel.LastDiagnosisPS.Date == null)
                    return false;
                if (fileSearchModel.diagnosisProceedingSession.ToDate.ToGeorgianDateTime() < tempViewModel.LastDiagnosisPS.Date.ToGeorgianDateTime())
                    return false;
            }

            if (fileSearchModel.disputeResolutionProceedingSession.ToDate != null)
            {
                if (tempViewModel.LastDisputeResolutionPS.Date == null)
                    return false;
                if (fileSearchModel.disputeResolutionProceedingSession.ToDate.ToGeorgianDateTime() < tempViewModel.LastDisputeResolutionPS.Date.ToGeorgianDateTime())
                    return false;
            }

            return true;
        }

        public FileSummary GetFileSummary(long id)
        {
            var summary = new FileSummary();

            summary.File = GetDetails(id);
            summary.File.ClientFullName = GetEmployeeFullNameById(summary.File.Reqester);
            summary.File.OppositePersonFullName = GetEmployerFullNameById(summary.File.Summoned);

            summary.DiagnosisMasterPetition = _masterPetitionApplication.GetDetails(id, 1) ?? new EditMasterPetition();
            var masterPetitionId = summary.DiagnosisMasterPetition != null ? summary.DiagnosisMasterPetition.Id : 0;
            summary.DiagnosisMasterPetition.CreateMasterPenaltyTitle = _masterPenaltyTitleApplication.Search(masterPetitionId);
            summary.DiagnosisMasterPetition.CreateMasterWorkHistory = _masterWorkHistoryApplication.Search(masterPetitionId);

            summary.File.createDiagnosisBoard = _boardApplication.GetDetails(id, 1) ?? new EditBoard();
            summary.File.createDiagnosisPS = _proceedingSessionApplication.Search(new ProceedingSessionSearchModel { Board_Id = summary.File.createDiagnosisBoard != null ? summary.File.createDiagnosisBoard.Id : 0 });

            summary.File.createDiagnosisPetition = _petitionApplication.GetDetails(id, 1) ?? new EditPetition();
            var petitionId = summary.File.createDiagnosisPetition != null ? summary.File.createDiagnosisPetition.Id : 0;
            summary.File.createDiagnosisPetition.CreatePenaltyTitle = _penaltyTitleApplication.Search(petitionId);
            summary.File.createDiagnosisPetition.CreateWorkHistory = _workHistoryApplication.Search(petitionId);
            summary.File.createDiagnosisPetition.TotalPaidAmounts = summary.File.createDiagnosisPetition.CreatePenaltyTitle.Sum(x => x.PaidAmount != null ? Int32.Parse(x.PaidAmount.Replace(",", "")) : 0).ToString();


            summary.DisputeResolutionMasterPetition = _masterPetitionApplication.GetDetails(id, 2) ?? new EditMasterPetition();
            masterPetitionId = summary.DisputeResolutionMasterPetition != null ? summary.DisputeResolutionMasterPetition.Id : 0;
            summary.DisputeResolutionMasterPetition.CreateMasterPenaltyTitle = _masterPenaltyTitleApplication.Search(masterPetitionId);
            summary.DisputeResolutionMasterPetition.CreateMasterWorkHistory = _masterWorkHistoryApplication.Search(masterPetitionId);

            summary.File.createDisputeResolutionBoard = _boardApplication.GetDetails(id, 2) ?? new EditBoard();
            summary.File.createDisputeResolutionPS = _proceedingSessionApplication.Search(new ProceedingSessionSearchModel { Board_Id = summary.File.createDisputeResolutionBoard != null ? summary.File.createDisputeResolutionBoard.Id : 0 });

            summary.File.createDisputeResolutionPetition = _petitionApplication.GetDetails(id, 2) ?? new EditPetition();
            petitionId = summary.File.createDisputeResolutionPetition != null ? summary.File.createDisputeResolutionPetition.Id : 0;
            summary.File.createDisputeResolutionPetition.CreatePenaltyTitle = _penaltyTitleApplication.Search(summary.File.createDisputeResolutionPetition != null ? summary.File.createDisputeResolutionPetition.Id : 0);
            summary.File.createDisputeResolutionPetition.CreateWorkHistory = _workHistoryApplication.Search(summary.File.createDisputeResolutionPetition != null ? summary.File.createDisputeResolutionPetition.Id : 0);
            summary.File.createDisputeResolutionPetition.TotalPaidAmounts = summary.File.createDisputeResolutionPetition.CreatePenaltyTitle.Sum(x => x.PaidAmount != null ? Int32.Parse(x.PaidAmount.Replace(",", "")) : 0).ToString();

            return summary;
        }

        private bool CheckValue(string viewModel, string searchModel)
        {
            if (!string.IsNullOrEmpty(viewModel) && viewModel.Contains(searchModel))
                return true;

            return false;
        }
    }
}
