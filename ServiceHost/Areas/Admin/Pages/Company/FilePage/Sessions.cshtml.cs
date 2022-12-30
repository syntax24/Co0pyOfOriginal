using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.ProceedingSession;
using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Areas.Admin.Pages.Company.FilePage
{
    public class SessionsModel : PageModel
    {
        public List<ProceedingSessionViewModel> viewModels = new List<ProceedingSessionViewModel>();
        public ProceedingSessionSearchModel searchModel;

        private readonly IFileApplication _fileApplication;
        private readonly IProceedingSessionApplication _proceedingSessionApplication;
        //private readonly IBoardApplication _boardApplication;

        public SessionsModel
        (
            IFileApplication fileApplication,
            IProceedingSessionApplication proceedingSessionApplication
            //IBoardApplication boardApplication
        )
        {
            _fileApplication = fileApplication;
            _proceedingSessionApplication = proceedingSessionApplication;
            //_boardApplication = boardApplication;
        }
        
        public void OnGet(ProceedingSessionSearchModel searchModel)
        {
            viewModels = _proceedingSessionApplication.FilterSessions(searchModel);



            var files = _fileApplication.Search(new FileSearchModel ());

            if (this.searchModel == null)
            {
                this.searchModel = new ProceedingSessionSearchModel
                {
                    ArchiveNo_FileClass_UserIdList = files.Select(x => new CompanyManagment.App.Contracts.ProceedingSession.ArchiveNo_FileClass_UserIdList { ArchiveNo = x.ArchiveNo.ToString(), FileClass = x.FileClass, UserId = x.Client == 1 ? x.Reqester : x.Summoned }).ToList(),
                    UsersList = _fileApplication.GetAllEmploees().Select(x => new CompanyManagment.App.Contracts.ProceedingSession.Users { Id = x.Id, FullName = x.EmployeeFullName }).ToList(),
                    
                };

                this.searchModel.UsersList.AddRange(_fileApplication.GetAllEmployers().Select(x => new CompanyManagment.App.Contracts.ProceedingSession.Users { Id = x.Id, FullName = x.FullName }).ToList());
            }
            else
            {
                this.searchModel.ArchiveNo_FileClass_UserIdList = files.Select(x => new CompanyManagment.App.Contracts.ProceedingSession.ArchiveNo_FileClass_UserIdList { ArchiveNo = x.ArchiveNo.ToString(), FileClass = x.FileClass, UserId = x.Client == 1 ? x.Reqester : x.Summoned }).ToList();
                this.searchModel.UsersList = _fileApplication.GetAllEmploees().Select(x => new CompanyManagment.App.Contracts.ProceedingSession.Users { Id = x.Id, FullName = x.EmployeeFullName }).ToList();
                this.searchModel.UsersList.AddRange(_fileApplication.GetAllEmployers().Select(x => new CompanyManagment.App.Contracts.ProceedingSession.Users { Id = x.Id, FullName = x.FullName }).ToList());
            }

        }

        public JsonResult OnPostSetSessionStatus(long PsId, int status)
        {

            var Ps = _proceedingSessionApplication.Search(new ProceedingSessionSearchModel { Id = PsId }).FirstOrDefault(); 

            Ps.Status = status;

            var operationResult = _proceedingSessionApplication.Edit(Ps);

            return new JsonResult(operationResult);

        }

        
    }
}
