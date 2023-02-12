using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using AccountManagement.Application.Contracts.Account;
using Company.Domain.Task;
using Company.Domain.TaskStatus;
using CompanyManagment.App.Contracts.TaskStatus;

namespace CompanyManagment.Application
{
    public class TaskStatusApplication : ITaskStatusApplication
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly IAccountApplication _accountApplication;
        private readonly _0_Framework.Application.IAuthHelper _authHelper;

        public TaskStatusApplication
        (
            ITaskRepository taskRepository, 
            ITaskStatusRepository taskStatusRepository,
            IAccountApplication accountApplication,
            _0_Framework.Application.IAuthHelper authHelper
        )
        {
            _taskRepository = taskRepository;
            _taskStatusRepository = taskStatusRepository;
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateTaskStatus command)
        {

            return null;
        }

        public OperationResult Edit(EditTaskStatus command)
        {
            return null;
        }

        public OperationResult Remove(long id)
        {
            return null;
        }

        public EditTaskStatus GetDetails(long id)
        {
            return null;
        }

        public EditTaskStatus GetDetails(long fileId, int boardTypeId)
        {
            return null;
        }

        public List<EditTaskStatus> Search(TaskStatusSearchModel searchModel)
        {
            var taskStatuses = _taskStatusRepository.Search(searchModel);

            foreach(var taskStatus in taskStatuses)
            {
                taskStatus.ReferralUserFullName = taskStatus.ReferralUserId != 0
                    ? _accountApplication.GetAccountBy(taskStatus.ReferralUserId).Fullname
                    : null;

                taskStatus.ReferralRegUserFullName = taskStatus.ReferralRegUserId != 0
                    ? _accountApplication.GetAccountBy(taskStatus.ReferralRegUserId).Fullname
                    : null;

                taskStatus.DeadlineExtentionRegUserFullName = taskStatus.DeadlineExtentionRegUserId != 0
                    ? _accountApplication.GetAccountBy(taskStatus.DeadlineExtentionRegUserId).Fullname
                    : null;

                taskStatus.ImpossibilityRegUserFullName = taskStatus.ImpossibilityRegUserId != 0 
                    ? _accountApplication.GetAccountBy(taskStatus.ImpossibilityRegUserId).Fullname
                    : null;

                taskStatus.DoneRegUserFullName = taskStatus.DoneRegUserId != 0
                    ? _accountApplication.GetAccountBy(taskStatus.DoneRegUserId).Fullname
                    : null;
            }

            return taskStatuses;
        }


        public OperationResult SetRefferal(EditTaskStatus editTaskStatus)
        {
            var result = new OperationResult();
            EditTaskStatus taskStatus = new EditTaskStatus();

            var taskStatuses = _taskStatusRepository.Search(new TaskStatusSearchModel { TaskId = editTaskStatus.Task_Id });

            if (taskStatuses.Count != 0)
                taskStatus = taskStatuses[0];

            taskStatus.ReferralStatus = editTaskStatus.ReferralStatus;
            taskStatus.Task_Id = editTaskStatus.Task_Id;

            if (!editTaskStatus.IsApproval)
            {
                taskStatus.ReferralUserId = editTaskStatus.ReferralUserId;
                taskStatus.ReferralRegUserId = _authHelper.CurrentAccountId();
                taskStatus.ReferralRegDate = DateTime.Now;
            }

            _taskStatusRepository.CreateOrUpdateTaskStatus(taskStatus);
            //_taskRepository.UpdateTaskStatus(refferal.ReferralUserId, refferal.TaskId);

            return result.Succcedded();
        }
        
        public OperationResult SetDeadline(EditTaskStatus editTaskStatus)
        {
            var result = new OperationResult();
            EditTaskStatus taskStatus = new EditTaskStatus();

            var taskStatuses = _taskStatusRepository.Search(new TaskStatusSearchModel { TaskId = editTaskStatus.Task_Id });

            if (taskStatuses.Count != 0)
                taskStatus = taskStatuses[0];

            taskStatus.DeadlineExtentionStatus = editTaskStatus.DeadlineExtentionStatus;
            taskStatus.Task_Id = editTaskStatus.Task_Id;

            if (!editTaskStatus.IsApproval)
            {
                taskStatus.DeadlineExtentionDate = editTaskStatus.DeadlineExtentionDate;
                taskStatus.DeadlineExtentionRegUserId = _authHelper.CurrentAccountId();
                taskStatus.DeadlineExtentionRegDate = DateTime.Now;
            }

            _taskStatusRepository.CreateOrUpdateTaskStatus(taskStatus);

            if (editTaskStatus.IsApproval && editTaskStatus.Approval)
            {
                var task = _taskRepository.Get(taskStatus.Task_Id);
                task.Edit(task.Commander_Id, task.SeniorUser_Id, task.TaskTitle_Id, task.Customer, task.Customer_Id, taskStatus.DeadlineExtentionDate, task.Description);
                _taskRepository.SaveChanges();
            }


            return result.Succcedded();
        }

        public void CreateOrUpdateTaskStatus(EditTaskStatus editTaskStatus)
        {
            _taskStatusRepository.CreateOrUpdateTaskStatus(editTaskStatus);
        }

        public OperationResult SetImpossibility(EditTaskStatus editTaskStatus)
        {
            var result = new OperationResult();
            EditTaskStatus taskStatus = new EditTaskStatus();

            var taskStatuses = _taskStatusRepository.Search(new TaskStatusSearchModel { TaskId = editTaskStatus.Task_Id });

            if (taskStatuses.Count != 0)
                taskStatus = taskStatuses[0];

            taskStatus.ImpossibilityStatus = editTaskStatus.ImpossibilityStatus;
            taskStatus.Task_Id = editTaskStatus.Task_Id;

            if (!editTaskStatus.IsApproval)
            {
                taskStatus.ImpossibilityDescription = editTaskStatus.ImpossibilityDescription;
                taskStatus.ImpossibilityRegUserId = _authHelper.CurrentAccountId();
                taskStatus.ImpossibilityRegDate = DateTime.Now;
            }

            _taskStatusRepository.CreateOrUpdateTaskStatus(taskStatus);

            return result.Succcedded();
        }
        
        public OperationResult SetDone(EditTaskStatus editTaskStatus)
        {
            var result = new OperationResult();
            EditTaskStatus taskStatus = new EditTaskStatus();

            var taskStatuses = _taskStatusRepository.Search(new TaskStatusSearchModel { TaskId = editTaskStatus.Task_Id });

            if (taskStatuses.Count != 0)
                taskStatus = taskStatuses[0];

            taskStatus.DoneStatus = editTaskStatus.DoneStatus;
            taskStatus.Task_Id = editTaskStatus.Task_Id;

            if (!editTaskStatus.IsApproval)
            {
                taskStatus.DoneRegUserId = _authHelper.CurrentAccountId();
                taskStatus.DoneRegDate = DateTime.Now;
            }

            _taskStatusRepository.CreateOrUpdateTaskStatus(taskStatus);

            return result.Succcedded();
        }
    }
}
