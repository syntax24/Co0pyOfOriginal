using _0_Framework_b.Application;
using AccountManagement.Application.Contracts.Account;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.Task;
using CompanyManagment.App.Contracts.TaskStatus;
using CompanyManagment.App.Contracts.TaskTitle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Areas.Admin.Pages.Company.TaskManager
{
    public class IndexModel : PageModel
    {
        public TaskSearchModel searchModel;
        public List<TaskViewModel> viewModels;
        public List<AccountViewModel> refferalUsers;

        private readonly IFileApplication _fileApplication;
        private readonly ITaskTitleApplication _taskTitleApplication;
        private readonly ITaskApplication _taskApplication;
        private readonly ITaskStatusApplication _taskStatusApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly _0_Framework.Application.IAuthHelper _authHelper;

        public IndexModel(
            IFileApplication fileApplication, 
            ITaskTitleApplication taskTitleApplication, 
            ITaskApplication taskApplication,
            ITaskStatusApplication taskStatusApplication,
            IAccountApplication accountApplication,
            _0_Framework.Application.IAuthHelper authHelper)
        {
            _fileApplication = fileApplication;
            _taskTitleApplication = taskTitleApplication;
            _taskApplication = taskApplication;
            _taskStatusApplication = taskStatusApplication;
            _accountApplication = accountApplication;
            _authHelper = authHelper;
            _accountApplication = accountApplication;
        }

        public void OnGet(TaskSearchModel searchModel)
        {
            var currentAccount = _authHelper.CurrentAccountInfo();
            var url = Request.GetDisplayUrl();

            this.searchModel = new TaskSearchModel();

            this.searchModel = searchModel;

            var accounts = _accountApplication.Search(new AccountSearchModel());

            this.searchModel.Commanders = accounts.Where(x => x.RoleId == 1).ToList();
            this.searchModel.SeniorUsers = accounts.Where(x => x.RoleId != 1).ToList();
            this.searchModel.TaskTitles = _taskTitleApplication.Search(new TaskTitleSearchModel());

            viewModels = _taskApplication.Search(new TaskSearchModel { AccountId = currentAccount.Id, RoleId = currentAccount.RoleId });

            if(url.Contains("?"))
                viewModels = _taskApplication.FilterData(viewModels, searchModel);

            refferalUsers = _accountApplication.GetAccounts();
        }


        public IActionResult OnGetCreateOrEdit(long? Id)
        {
            var editTask = new EditTask();

            if (Id != null)
            {
                editTask = _taskApplication.GetDetails((long) Id);
                editTask.IsEditMode = true;
            }

            editTask.SeniorUsers = _accountApplication.GetAccounts().Where(x => x.RoleId != 1).ToList();
            editTask.Customers = _fileApplication.GetAllEmployers();
            editTask.TaskTitles = _taskTitleApplication.Search(new TaskTitleSearchModel());
            return Partial("./CreateOrEdit", editTask);
        }

        public IActionResult OnPostCreateOrEdit(EditTask createTask)
        {
            var result = new OperationResult();

            if (createTask.TaskFromDate == null && createTask.TaskDate == null)
                return new JsonResult(result.Failed("هردو فیلد تاریخ نباید خالی باشد"));

            if(createTask.Id == 0)
                result = _taskApplication.Create(createTask);

            else
            {
                //var task = _taskApplication.GetDetails(createTask.Id);
                result = _taskApplication.Edit(createTask);
            }

            return new JsonResult(result.Succcedded());
        }

        public JsonResult OnPostDeleteTask(int Id)
        {
            var result = _taskApplication.Remove(Id);

            return new JsonResult(result);
        }

        public JsonResult OnPostDate(int type)
        {   

            return new JsonResult(new
            {
                date = _taskApplication.GetDate(type).Substring(0, 10)
            });
        }
        
        public JsonResult OnPostSetRefferalUser(int refferalUserId, int taskId)
        {
            var taskStatus = new EditTaskStatus
            {
                ReferralStatus = TaskStatusEnums.UNAPPROVED,
                ReferralUserId = refferalUserId,
                ReferralRegDate = DateTime.Now,
                ReferralRegUserId = _authHelper.CurrentAccountId(),
                Task_Id = taskId
            };


            var result = _taskStatusApplication.SetRefferal(taskStatus);

            return new JsonResult(result);
        }
        
        public JsonResult OnPostSetRefferalUserApproval(int taskId, bool approval)
        {
            var taskStatus = new EditTaskStatus
            {
                ReferralStatus = approval == true ? TaskStatusEnums.MANAGER_APPROVAL : TaskStatusEnums.REJECTED,
                Task_Id = taskId,
                IsApproval = true
            };

            if (approval == false)
                taskStatus.ReferralUserId = 0;

            var result = _taskStatusApplication.SetRefferal(taskStatus);

            return new JsonResult(result);
        }
        
        public JsonResult OnPostSetDeadlineDate(int taskId, string date)
        {
            try
            {
                var dateTime = date.ToGeorgianDateTime();
            }
            catch(Exception e)
            {
                var ex =  new JsonResult(new OperationResult().Failed("لطفا تاریخ را صحیح وارد کنید"));
                ex.StatusCode = 410;

                return ex;
            }

            var taskStatus = new EditTaskStatus
            {
                DeadlineExtentionStatus = TaskStatusEnums.UNAPPROVED,
                DeadlineExtentionDate = date.ToGeorgianDateTime(),
                Task_Id = taskId,
            };

            var result = _taskStatusApplication.SetDeadline(taskStatus);

            return new JsonResult(result);
        }

        public JsonResult OnPostSetDeadlineExtentionApproval(int taskId, bool approval)
        {
            var taskStatus = new EditTaskStatus
            {
                DeadlineExtentionStatus = approval == true ? TaskStatusEnums.MANAGER_APPROVAL : TaskStatusEnums.REJECTED,
                Task_Id = taskId,
                IsApproval = true,
                Approval = approval
            };

            //if (approval == false)
            //    taskStatus.DeadlineExtentionDate = null;

            var result = _taskStatusApplication.SetDeadline(taskStatus);

            return new JsonResult(result);
        }


        public JsonResult OnPostSetImpossibility(string impossibilityDescription, int taskId)
        {
            var taskStatus = new EditTaskStatus
            {
                ImpossibilityStatus = TaskStatusEnums.UNAPPROVED,
                ImpossibilityDescription = impossibilityDescription,
                ImpossibilityRegDate = DateTime.Now,
                ImpossibilityRegUserId = _authHelper.CurrentAccountId(),
                Task_Id = taskId
            };


            var result = _taskStatusApplication.SetImpossibility(taskStatus);

            return new JsonResult(result);
        }

        public JsonResult OnPostSetImpossibilityApproval(int taskId, bool approval)
        {
            var taskStatus = new EditTaskStatus
            {
                ImpossibilityStatus = approval == true ? TaskStatusEnums.MANAGER_APPROVAL : TaskStatusEnums.REJECTED,
                Task_Id = taskId,
                IsApproval = true,
                Approval = approval
            };

            var result = _taskStatusApplication.SetImpossibility(taskStatus);

            return new JsonResult(result);
        }

        public JsonResult OnPostSetDone(int taskId)
        {
            var taskStatus = new EditTaskStatus
            {
                DoneStatus = TaskStatusEnums.UNAPPROVED,
                DoneRegDate = DateTime.Now,
                DoneRegUserId = _authHelper.CurrentAccountId(),
                Task_Id = taskId
            };


            var result = _taskStatusApplication.SetDone(taskStatus);

            return new JsonResult(result);
        }

        public JsonResult OnPostSetDoneApproval(int taskId, bool approval)
        {
            var taskStatus = new EditTaskStatus
            {
                DoneStatus = approval == true ? TaskStatusEnums.MANAGER_APPROVAL : TaskStatusEnums.REJECTED,
                Task_Id = taskId,
                IsApproval = true,
                Approval = approval
            };

            var result = _taskStatusApplication.SetDone(taskStatus);

            return new JsonResult(result);
        }

    }
}
