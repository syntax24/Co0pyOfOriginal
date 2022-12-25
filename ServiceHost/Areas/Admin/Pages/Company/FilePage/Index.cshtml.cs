using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.Evidence;
using CompanyManagment.App.Contracts.EvidenceDetail;
using CompanyManagment.App.Contracts.File1;
//using CompanyManagment.App.Contracts.FileAlert;
using CompanyManagment.App.Contracts.FileTiming;
using CompanyManagment.App.Contracts.FileTitle;
using CompanyManagment.App.Contracts.MasterPenaltyTitle;
using CompanyManagment.App.Contracts.MasterPetition;
using CompanyManagment.App.Contracts.MasterWorkHistory;
using CompanyManagment.App.Contracts.PenaltyTitle;
using CompanyManagment.App.Contracts.Petition;
using CompanyManagment.App.Contracts.ProceedingSession;
using CompanyManagment.App.Contracts.WorkHistory;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Company.FilePage
{
    public class IndexModel : PageModel
    {
        public FileSearchModel fileSearchModel;
        public List<FileViewModel> viewModels;

        private readonly IFileApplication _fileApplication;
        private readonly IBoardApplication _boardApplication;
        private readonly IPetitionApplication _petitionApplication;
        private readonly IWorkHistoryApplication _workHistoryApplication;
        private readonly IPenaltyTitleApplication _penaltyTitleApplication;
        private readonly IProceedingSessionApplication _proceedingSessionApplication;
        private readonly IMasterPetitionApplication _masterPetitionApplication;
        private readonly IMasterWorkHistoryApplication _masterWorkHistoryApplication;
        private readonly IMasterPenaltyTitleApplication _masterPenaltyTitleApplication;
        private readonly IEvidenceApplication _evidenceApplication;
        private readonly IEvidenceDetailApplication _evidenceDetailApplication;
        private readonly IFileTitleApplication _fileTitleApplication;
        private readonly IFileTimingApplication _fileTimingApplication;


        public IndexModel(
            IFileApplication fileApplication,
            IBoardApplication boardApplication,
            IPetitionApplication petitionApplication,
            IWorkHistoryApplication workHistoryApplication,
            IPenaltyTitleApplication penaltyTitleApplication,
            IProceedingSessionApplication proceedingSessionApplication,
            IMasterPetitionApplication masterPetitionApplication,
            IMasterWorkHistoryApplication masterWorkHistoryApplication,
            IMasterPenaltyTitleApplication masterPenaltyTitleApplication,
            IEvidenceApplication evidenceApplication,
            IEvidenceDetailApplication evidenceDetailApplication,
            IFileTitleApplication fileTitleApplication,
            IFileTimingApplication fileTimingApplication
         )
        {
            _fileApplication = fileApplication;
            _boardApplication = boardApplication;
            _petitionApplication = petitionApplication;
            _workHistoryApplication = workHistoryApplication;
            _penaltyTitleApplication = penaltyTitleApplication;
            _proceedingSessionApplication = proceedingSessionApplication;
            _masterPetitionApplication = masterPetitionApplication;
            _masterWorkHistoryApplication = masterWorkHistoryApplication;
            _masterPenaltyTitleApplication = masterPenaltyTitleApplication;
            _evidenceApplication = evidenceApplication;
            _evidenceDetailApplication = evidenceDetailApplication;
            _fileTitleApplication = fileTitleApplication;
            _fileTimingApplication = fileTimingApplication;
        }

        public void OnGet(FileSearchModel fileSearchModel)
        {
            if (fileSearchModel.diagnosisBoard == null)
                fileSearchModel.diagnosisBoard = new BoardSearchModel();

            if (fileSearchModel.diagnosisProceedingSession == null)
                fileSearchModel.diagnosisProceedingSession = new ProceedingSessionSearchModel();

            if (fileSearchModel.disputeResolutionBoard == null)
                fileSearchModel.disputeResolutionBoard = new BoardSearchModel();

            if (fileSearchModel.disputeResolutionProceedingSession == null)
                fileSearchModel.disputeResolutionProceedingSession =
                    new ProceedingSessionSearchModel();


            var allFiles = _fileApplication.Search(new FileSearchModel());

            if (this.fileSearchModel == null)
            {
                this.fileSearchModel = new FileSearchModel
                {
                   ArchiveNo_FileClass_UserIdList = allFiles.Select(x => new ArchiveNo_FileClass_UserIdList { ArchiveNo = x.ArchiveNo.ToString(), FileClass = x.FileClass, UserId = x.Client == 1 ? x.Reqester : x.Summoned }).ToList(),
                    UsersList = _fileApplication.GetAllEmploees().Select(x => new Users { Id = x.Id, FullName = x.EmployeeFullName }).ToList(),
                };

                this.fileSearchModel.UsersList.AddRange(_fileApplication.GetAllEmployers().Select(x => new Users { Id = x.Id, FullName = x.FullName }).ToList());
            }
            else
            {
                this.fileSearchModel.ArchiveNo_FileClass_UserIdList = allFiles.Select(x => new ArchiveNo_FileClass_UserIdList { ArchiveNo = x.ArchiveNo.ToString(), FileClass = x.FileClass, UserId = x.Client == 1 ? x.Reqester : x.Summoned }).ToList();
                this.fileSearchModel.UsersList = _fileApplication.GetAllEmploees().Select(x => new Users { Id = x.Id, FullName = x.EmployeeFullName }).ToList();
                this.fileSearchModel.UsersList.AddRange(_fileApplication.GetAllEmployers().Select(x => new Users { Id = x.Id, FullName = x.FullName }).ToList());
            }


            var files = _fileApplication.Search(fileSearchModel);

            foreach (var item in files)
            {
                item.ReqesterFullname = _fileApplication.GetEmployeeFullNameById(item.Reqester);
                item.SummonedFullname = _fileApplication.GetEmployerFullNameById(item.Summoned);
            }

            viewModels = files;

            var i = 0;
            foreach (var file in files.ToList())
            {
                var tempViewModel = new FileViewModel();
                tempViewModel = _fileApplication.GetFileDetails(file);

                if (_fileApplication.FilterFileDetails(tempViewModel, fileSearchModel))
                {
                    viewModels[i] = tempViewModel;
                    i++;
                }
                else
                    viewModels.RemoveAt(i);
            }
        }

        public IActionResult OnGetCreateFile()
        {
            var archiveNo = _fileApplication.FindLastArchiveNumber();
            
            var createFile = new CreateFile
            {
                ArchiveNo = archiveNo + 1,
                Employees = _fileApplication.GetAllEmploees(),
                Employers = _fileApplication.GetAllEmployers()
            };


            return Partial("./CreateFile", createFile);
        }

        public IActionResult OnPostCreateFile(CreateFile command)
        {
            var result = _fileApplication.Create(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetEditFile(long id = -1)
        {
            if (id == -1)
            {
                var file = _fileApplication.Search(new FileSearchModel()).FirstOrDefault();
                if (file != null) id = file.Id;
            }

            var editFile = _fileApplication.GetDetails(id);
            var diagnosisBoard =
                _boardApplication.GetDetails(editFile.Id, 1)
                ?? new EditBoard { File_Id = editFile.Id, BoardType_Id = 1 };

            var PsSearchModel = new ProceedingSessionSearchModel { Board_Id = diagnosisBoard.Id };
            var diagnosisPS = _proceedingSessionApplication.Search(PsSearchModel);
            diagnosisPS =
                diagnosisPS.Count != 0
                    ? diagnosisPS
                    : new List<EditProceedingSession> { new EditProceedingSession() };

            var diagnosisPetition = _petitionApplication.GetDetails(editFile.Id, 1);

            var disputeResolutionBoard =
                _boardApplication.GetDetails(editFile.Id, 2)
                ?? new EditBoard { File_Id = editFile.Id, BoardType_Id = 2 };

            PsSearchModel.Board_Id = disputeResolutionBoard.Id;
            var disputeResolutionPS = _proceedingSessionApplication.Search(PsSearchModel);
            disputeResolutionPS =
                disputeResolutionPS.Count != 0
                    ? disputeResolutionPS
                    : new List<EditProceedingSession> { new EditProceedingSession() };

            var disputeResolutionPetition = _petitionApplication.GetDetails(editFile.Id, 2);

            editFile.createDiagnosisBoard = diagnosisBoard;
            editFile.createDiagnosisPS = diagnosisPS;
            editFile.createDiagnosisPetition = diagnosisPetition;

            editFile.createDisputeResolutionBoard = disputeResolutionBoard;
            editFile.createDisputeResolutionPS = disputeResolutionPS;
            editFile.createDisputeResolutionPetition = disputeResolutionPetition;
            editFile.Employees = _fileApplication.GetAllEmploees();
            editFile.Employers = _fileApplication.GetAllEmployers();

            return Partial("Edit", editFile);
        }

        public IActionResult OnPostEditFile(EditFile command)
        {
            var result = _fileApplication.Edit(command);

            if (!result.IsSuccedded)
                return new JsonResult(result);

            if (
                command.createDiagnosisBoard.BoardChairman != null
                || command.createDiagnosisBoard.Branch != null
                || command.createDiagnosisBoard.DisputeResolutionPetitionDate != null
                || command.createDiagnosisBoard.ExpertReport != null
            )
            {
                if (command.createDiagnosisBoard.Id == 0)
                {
                    result = _boardApplication.Create(command.createDiagnosisBoard);
                }
                else
                {
                    result = _boardApplication.Edit(command.createDiagnosisBoard);
                }

                if (!result.IsSuccedded)
                    return new JsonResult(result);

                result = _proceedingSessionApplication.CreateProceedingSessions(
                    command.createDiagnosisPS,
                    result.EntityId
                );

                if (!result.IsSuccedded)
                    return new JsonResult(result);
            }

            if (
                command.createDisputeResolutionBoard.BoardChairman != null
                || command.createDisputeResolutionBoard.Branch != null
                || command.createDisputeResolutionBoard.DisputeResolutionPetitionDate != null
                || command.createDisputeResolutionBoard.ExpertReport != null
            )
            {
                if (command.createDisputeResolutionBoard.Id == 0)
                {
                    result = _boardApplication.Create(command.createDisputeResolutionBoard);
                }
                else
                {
                    result = _boardApplication.Edit(command.createDisputeResolutionBoard);
                }

                if (!result.IsSuccedded)
                    return new JsonResult(result);

                result = _proceedingSessionApplication.CreateProceedingSessions(
                    command.createDisputeResolutionPS,
                    result.EntityId
                );

                if (!result.IsSuccedded)
                    return new JsonResult(result);
            }

            return new JsonResult(result);
        }

        public IActionResult OnGetCreateOrEditPetition(long fileId, int boardTypeId)
        {
            var file = _fileApplication.GetDetails(fileId);

            var petition = _petitionApplication.GetDetails(fileId, boardTypeId) ?? new EditPetition();
            var workHistories = _workHistoryApplication.Search(petition.Id);
            workHistories =
                workHistories.Count != 0
                    ? workHistories
                    : new List<EditWorkHistory> { new EditWorkHistory() };

            var PenaltyTitles = _penaltyTitleApplication.Search(petition.Id);
            PenaltyTitles =
                PenaltyTitles.Count != 0
                    ? PenaltyTitles
                    : new List<EditPenaltyTitle> { new EditPenaltyTitle() };

            petition.File_Id = fileId;
            petition.BoardType_Id = boardTypeId;
            petition.FileData = file;
            petition.CreateWorkHistory = workHistories;
            petition.CreatePenaltyTitle = PenaltyTitles;

            return Partial("./CreateOrEditPetition", petition);
        }

        public IActionResult OnPostCreateOrEditPetition(EditPetition command)
        {
            var petitionResult = new OperationResult();
            
            if (command.Id == 0)
            {
                petitionResult = _petitionApplication.Create(command);
            }
            else
            {
                petitionResult = _petitionApplication.Edit(command);
            }

            if (!petitionResult.IsSuccedded)
                return new JsonResult(petitionResult);

            var workResult = _workHistoryApplication.CreateWorkHistories(
                command.CreateWorkHistory,
                petitionResult.EntityId
            );

            if (!workResult.IsSuccedded)
                return new JsonResult(workResult);

            var penaltyResult = _penaltyTitleApplication.CreatePenaltyTitles(
                command.CreatePenaltyTitle,
                petitionResult.EntityId
            );

            if (!penaltyResult.IsSuccedded)
                return new JsonResult(penaltyResult);

            return new JsonResult(penaltyResult);
        }

        public IActionResult OnGetCreateOrEditMasterPetition(long fileId, int boardTypeId)
        {
            var file = _fileApplication.GetDetails(fileId);

            var masterPetition = _masterPetitionApplication.GetDetails(fileId, boardTypeId) ?? new EditMasterPetition();
            var workHistories = _masterWorkHistoryApplication.Search(masterPetition.Id);
            workHistories =
                workHistories.Count != 0
                    ? workHistories
                    : new List<EditMasterWorkHistory> { new EditMasterWorkHistory() };

            var PenaltyTitles = _masterPenaltyTitleApplication.Search(masterPetition.Id);
            PenaltyTitles =
                PenaltyTitles.Count != 0
                    ? PenaltyTitles
                    : new List<EditMasterPenaltyTitle> { new EditMasterPenaltyTitle() };

            masterPetition.File_Id = fileId;
            masterPetition.BoardType_Id = boardTypeId;
            masterPetition.FileData = file;
            masterPetition.CreateMasterWorkHistory = workHistories;
            masterPetition.CreateMasterPenaltyTitle = PenaltyTitles;

            return Partial("./CreateOrEditMasterPetition", masterPetition);
        }

        public IActionResult OnPostCreateOrEditMasterPetition(EditMasterPetition command)
        {
            var masterPetitionResult = new OperationResult();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();

            //}

            //var result = _fileApplication.Edit(command.FileData);

            //if (!result.IsSuccedded)
            //    return new JsonResult(result);

            if (command.Id == 0)
            {
                masterPetitionResult = _masterPetitionApplication.Create(command);
            }
            else
            {
                masterPetitionResult = _masterPetitionApplication.Edit(command);
            }

            if (!masterPetitionResult.IsSuccedded)
                return new JsonResult(masterPetitionResult);

            var workResult = _masterWorkHistoryApplication.CreateMasterWorkHistories(
                command.CreateMasterWorkHistory,
                masterPetitionResult.EntityId
            );

            if (!workResult.IsSuccedded)
                return new JsonResult(workResult);

            var penaltyResult = _masterPenaltyTitleApplication.CreateMasterPenaltyTitles(
                command.CreateMasterPenaltyTitle,
                masterPetitionResult.EntityId
            );

            if (!penaltyResult.IsSuccedded)
                return new JsonResult(penaltyResult);

            return new JsonResult(penaltyResult);
        }

        public IActionResult OnGetCreateOrEditEvidence(long fileId, int boardTypeId)
        {
            var file = _fileApplication.GetDetails(fileId);

            var evidence = _evidenceApplication.GetDetails(fileId, boardTypeId) ?? new EditEvidence();
            var evidenceDetails = _evidenceDetailApplication.Search(evidence.Id);
            evidenceDetails =
                evidenceDetails.Count != 0
                    ? evidenceDetails
                    : new List<EditEvidenceDetail> { new EditEvidenceDetail() };


            evidence.File_Id = fileId;
            evidence.BoardType_Id = boardTypeId;
            evidence.FileData = file;
            evidence.CreateEvidenceDetail = evidenceDetails;

            return Partial("./CreateOrEditEvidence", evidence);
        }

        public IActionResult OnPostCreateOrEditEvidence(EditEvidence command)
        {
            var evidenceResult = new OperationResult();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();

            //}

            //var result = _fileApplication.Edit(command.FileData);

            //if (!result.IsSuccedded)
            //    return new JsonResult(result);

            if (command.Id == 0)
            {
                evidenceResult = _evidenceApplication.Create(command);
            }
            else
            {
                evidenceResult = _evidenceApplication.Edit(command);
            }

            if (!evidenceResult.IsSuccedded)
                return new JsonResult(evidenceResult);

            var evidenceDetail = _evidenceDetailApplication.CreateEvidenceDetail(
                command.CreateEvidenceDetail,
                evidenceResult.EntityId
            );

            if (!evidenceDetail.IsSuccedded)
                return new JsonResult(evidenceDetail);

            return new JsonResult(evidenceDetail);
        }

        public IActionResult OnGetCreateOrEditFileTitle(string type)
        {
            var EditFileTitle = new EditFileTitle();
            EditFileTitle.FileTitlesList = _fileTitleApplication.Search(new FileTitleSearchModel { Type = type });

            return Partial("./CreateOrEditFileTitle", EditFileTitle);
        }

        public IActionResult OnPostCreateOrEditFileTitle(EditFileTitle command)
        {
            var result = new OperationResult();

            if (_fileTitleApplication.Search(new FileTitleSearchModel { Title = command.Title, Type = command.Type }).Count != 0)
                result.Failed("این عنوان قبلا ثبت شده است");
            else
            {
                if (command.Id == 0)
                    result = _fileTitleApplication.Create(command);

                else
                {
                    var fileTitle = _fileTitleApplication.Search(new FileTitleSearchModel { Id = command.Id }).FirstOrDefault();
                    fileTitle.Title = command.Title;
                    result = _fileTitleApplication.Edit(fileTitle);
                }
            }

            var res = new
            {
                result = result,
                type = command.Type
            };

            return new JsonResult(res);
        }

        public IActionResult OnGetCreateOrEditFileTiming(string type)
        {
            var FileTimings = _fileTimingApplication.Search(new FileTimingSearchModel());

            if (FileTimings.Count == 0)
                FileTimings = Enumerable.Repeat(new EditFileTiming(), 6).ToList();

            return Partial("./CreateOrEditFileTiming", FileTimings);
        }

        public IActionResult OnPostCreateOrEditFileTiming(List<EditFileTiming> command)
        {
            var result = new OperationResult();

            foreach (var item in command)
            {
                if (item.Id == 0)
                    _fileTimingApplication.Create(item);

                else
                    _fileTimingApplication.Edit(item);
            }

            return new JsonResult(result.Succcedded());
        }

        public IActionResult OnGetFileSummary(long id)
        {
            var summary = _fileApplication.GetFileSummary(id);

            return Partial("FileSummary", summary);
        }

        public JsonResult OnPostCheckUniqueArchiveNo(string archiveNo)
        {
            var sModel = new FileSearchModel { ArchiveNo = archiveNo };
            var vModel = _fileApplication.Search(sModel);

            return new JsonResult(
                new
                {
                    stat = vModel.Count() == 0 ? true : false,
                    message = vModel == null ? "" : "شماره بایگانی تکراری است"
                }
            );
        }

        public JsonResult OnPostRemoveMasterPetition(long id)
        {
            _masterPenaltyTitleApplication.RemoveMasterPenaltyTitles(id);
            _masterWorkHistoryApplication.RemoveMasterWorkHistories(id);
            var result = _masterPetitionApplication.Remove(id);

            return new JsonResult(result);
        }
        public JsonResult OnGetGetFileTitles(string type)
        {
            var fileTitlesList = _fileTitleApplication.Search(new FileTitleSearchModel { Type = type }).Select(x => x.Title).ToList();

            return new JsonResult(fileTitlesList);
        }

        public JsonResult OnPostRemoveFileTitle(long id)
        {
            var result = _fileTitleApplication.Remove(id);

            return new JsonResult(result);
        }

        public JsonResult OnPostRemoveEvidence(long id)
        {
            _evidenceDetailApplication.RemoveEvidenceDetails(id);
            var result = _evidenceApplication.Remove(id);

            return new JsonResult(result);
        }

        public JsonResult OnPostSetFileStatus(long id)
        {
            var result = new OperationResult();
            var file = _fileApplication.GetDetails(id);

            switch (file.Status)
            {
                case 1:

                    file.Status = 2;
                    result = _fileApplication.Edit(file);
                    result.Message = "پرونده با موفقیت فعال شد";
                    break;

                case 2:
                    file.Status = 1;
                    result = _fileApplication.Edit(file);
                    result.Message = "پرونده با موفقیت غیرفعال شد";
                    break;
            }

            return new JsonResult(result);
        }

        
    }
}
