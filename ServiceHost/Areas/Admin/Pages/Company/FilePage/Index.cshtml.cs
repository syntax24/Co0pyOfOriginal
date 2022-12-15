using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.Evidence;
using CompanyManagment.App.Contracts.EvidenceDetail;
using CompanyManagment.App.Contracts.File1;
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

            //var files = _fileApplication.Search(fileSearchModel);
           
            //viewModels = files;

            //var i = 0; 

            //foreach (var file in files.ToList())
            //{
            //    var tempViewModel = new FileViewModel();
            //    tempViewModel = GetFileDetails(file);

            //    if(FilterFileDetails(tempViewModel, fileSearchModel))
            //    {
            //        viewModels[i] = tempViewModel;
            //        i++;
            //    }
            //    else
            //        viewModels.RemoveAt(i);
            //}

            var allFiles = _fileApplication.Search(new FileSearchModel());

            if (this.fileSearchModel == null)
            {
                this.fileSearchModel = new FileSearchModel
                {
                    //ArchiveNoList = allFiles.Count != 0 ? allFiles.Select(x => x.ArchiveNo.ToString()).ToList() : null,
                    //ArchiveNo_FileClassList.ArchiveNo = allFiles.Select(x => x.ArchiveNo.ToString()).ToList(),
                    ArchiveNo_FileClass_UserIdList = allFiles.Select(x => new ArchiveNo_FileClass_UserIdList { ArchiveNo = x.ArchiveNo.ToString(), FileClass = x.FileClass,  UserId = x.Client == 1 ? x.Reqester : x.Summoned }).ToList(),
                    UsersList = _fileApplication.GetAllEmploees().Select(x => new Users { Id = x.Id, FullName = x.EmployeeFullName }).ToList(),
                };

                this.fileSearchModel.UsersList.AddRange(_fileApplication.GetAllEmployers().Select(x => new Users { Id = x.Id, FullName = x.FullName }).ToList());
            }
            else
            {
                //this.fileSearchModel.ArchiveNoList = allFiles.Select(x => x.ArchiveNo.ToString()).ToList();
                //this.fileSearchModel.FileClassList = allFiles.Select(x => x.FileClass).ToList();

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
                tempViewModel = GetFileDetails(file);

                if (FilterFileDetails(tempViewModel, fileSearchModel))
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
            //fileSearchModel = new FileSearchModel();
            //var archiveNo = _fileApplication.GetLastArchiveNumber(fileSearchModel).ArchiveNo;
            var archiveNo = _fileApplication.FindLastArchiveNumber();
            //archiveNo = archiveNo != 0 ? archiveNo : (long)1;

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

            if (file.Client == 1)
            {
                file.ClientFullName = _fileApplication.GetEmployeeFullNameById(file.Reqester);
                file.OppositePersonFullName = _fileApplication.GetEmployerFullNameById(file.Summoned);
            }
            else
            {
                file.ClientFullName = _fileApplication.GetEmployerFullNameById(file.Summoned);
                file.OppositePersonFullName = _fileApplication.GetEmployeeFullNameById(file.Reqester);
            }
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
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();

            //}

            //var result = _fileApplication.Edit(command.FileData);

            //if (!result.IsSuccedded)
            //    return new JsonResult(result);

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

            if (file.Client == 1)
            {
                file.ClientFullName = _fileApplication.GetEmployeeFullNameById(file.Reqester);
                file.OppositePersonFullName = _fileApplication.GetEmployerFullNameById(file.Summoned);
            }
            else
            {
                file.ClientFullName = _fileApplication.GetEmployerFullNameById(file.Summoned);
                file.OppositePersonFullName = _fileApplication.GetEmployeeFullNameById(file.Reqester);
            }
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

            if (file.Client == 1)
            {
                file.ClientFullName = _fileApplication.GetEmployeeFullNameById(file.Reqester);
                file.OppositePersonFullName = _fileApplication.GetEmployerFullNameById(file.Summoned);
            }
            else
            {
                file.ClientFullName = _fileApplication.GetEmployerFullNameById(file.Summoned);
                file.OppositePersonFullName = _fileApplication.GetEmployeeFullNameById(file.Reqester);
            }
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

            foreach(var item in command)
            {
                if (item.Id == 0)
                    _fileTimingApplication.Create(item);

                else
                    _fileTimingApplication.Edit(item);
            }

            return new JsonResult(result.Succcedded());
        }

        public IActionResult OnGetDetails(long id)
        {
            var editJob = _fileApplication.GetDetails(id);

            return Partial("Details", editJob);
        }
        
        public IActionResult OnGetFileSummary(long id)
        {
            var summary = new FileSummary();

            summary.File = _fileApplication.GetDetails(id);
            summary.File.ClientFullName = _fileApplication.GetEmployeeFullNameById(summary.File.Reqester);
            summary.File.OppositePersonFullName = _fileApplication.GetEmployerFullNameById(summary.File.Summoned);

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
            summary.File.createDiagnosisPetition.TotalPaidAmounts = summary.File.createDiagnosisPetition.CreatePenaltyTitle.Sum(x => x.PaidAmount !=null ? Int32.Parse(x.PaidAmount.Replace(",", "")) : 0).ToString();


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

            switch(file.Status)
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

        private FileViewModel GetFileDetails(FileViewModel file)
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

        private bool CheckValue(string viewModel, string searchModel)
        {
            if (!string.IsNullOrEmpty(viewModel) && viewModel.Contains(searchModel))
                return true;

            return false;
        }

        private bool FilterFileDetails(FileViewModel tempViewModel, FileSearchModel fileSearchModel)
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
    }
}
