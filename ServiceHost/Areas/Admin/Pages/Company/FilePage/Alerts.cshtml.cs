using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.FileAlert;
using CompanyManagment.App.Contracts.FileState;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Areas.Admin.Pages.Company.FilePage
{
    public class AlertsModel : PageModel
    {
        public List<FileAlertViewModel> viewModels;
        public FileAlertSearchModel searchModel;

        private readonly IFileApplication _fileApplication;
        private readonly IFileAlertApplication _fileAlertApplication;
        private readonly IFileStateApplication _fileStateApplication;

        public AlertsModel
        (
            IFileApplication fileApplication,
            IFileAlertApplication fileAlertApplication,
            IFileStateApplication fileStateApplication
        )
        {
            _fileApplication = fileApplication;
            _fileAlertApplication = fileAlertApplication;
            _fileStateApplication = fileStateApplication;
        }

        public void OnGet(FileAlertSearchModel searchModel)
        {
            var files = _fileApplication.Search(new FileSearchModel { ArchiveNo = searchModel.ArchiveNo, FileClass = searchModel.FileClass});

            viewModels = _fileAlertApplication.GetFilesAlerts(files);

            if (searchModel.FileState_Id != 0)
                viewModels = viewModels.Where(x => x.FileState_Id == searchModel.FileState_Id).ToList();

            var filesId = viewModels.Select(y => y.File_Id).ToList();

            files = files.Where(x => filesId.Contains(x.Id)).ToList();

            

            if (this.searchModel == null)
            {
                this.searchModel = new FileAlertSearchModel
                {
                    ArchiveNo_FileClass_UserIdList = files.Select(x => new CompanyManagment.App.Contracts.FileAlert.ArchiveNo_FileClass_UserIdList { ArchiveNo = x.ArchiveNo.ToString(), FileClass = x.FileClass, UserId = x.Client == 1 ? x.Reqester : x.Summoned }).ToList(),
                    UsersList = _fileApplication.GetAllEmploees().Select(x => new CompanyManagment.App.Contracts.FileAlert.Users { Id = x.Id, FullName = x.EmployeeFullName }).ToList(),
                    FileStatesList = _fileStateApplication.Search(new FileStateSearchModel()).OrderBy(x => x.Id).ToList()
                };

                this.searchModel.UsersList.AddRange(_fileApplication.GetAllEmployers().Select(x => new CompanyManagment.App.Contracts.FileAlert.Users { Id = x.Id, FullName = x.FullName }).ToList());
            }
            else
            {
                this.searchModel.ArchiveNo_FileClass_UserIdList = files.Select(x => new CompanyManagment.App.Contracts.FileAlert.ArchiveNo_FileClass_UserIdList { ArchiveNo = x.ArchiveNo.ToString(), FileClass = x.FileClass, UserId = x.Client == 1 ? x.Reqester : x.Summoned }).ToList();
                this.searchModel.UsersList = _fileApplication.GetAllEmploees().Select(x => new CompanyManagment.App.Contracts.FileAlert.Users { Id = x.Id, FullName = x.EmployeeFullName }).ToList();
                this.searchModel.UsersList.AddRange(_fileApplication.GetAllEmployers().Select(x => new CompanyManagment.App.Contracts.FileAlert.Users { Id = x.Id, FullName = x.FullName }).ToList());
                this.searchModel.FileStatesList = _fileStateApplication.Search(new FileStateSearchModel()).OrderBy(x => x.Id).ToList();
            }
        }

        public JsonResult OnPostSetAdditionalDeadline(EditFileAlert fileAlert)
        {
            var operationResult = new OperationResult();
            var fileAdditionalDeadlines = _fileAlertApplication.Search(new FileAlertSearchModel { File_Id = fileAlert.File_Id, FileState_Id = fileAlert.FileState_Id });

            if (fileAdditionalDeadlines.Where(x => x.AdditionalDeadline == fileAlert.AdditionalDeadline).Count() >= _fileAlertApplication.getMaximumAdditionalDeadlineTimes(fileAlert.AdditionalDeadline))

                return new JsonResult(operationResult.Failed("تعداد دفعات مجاز تمدید " + fileAlert.AdditionalDeadline + " روزه به پایان رسیده است."));

            _fileAlertApplication.Create(fileAlert);

            return new JsonResult(operationResult.Succcedded());
        }
    }
}
