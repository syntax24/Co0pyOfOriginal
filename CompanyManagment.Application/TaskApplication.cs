using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework_b.Application;
using AccountManagement.Application.Contracts.Account;
using Company.Domain.Task;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.Task;
using CompanyManagment.App.Contracts.TaskStatus;
using CompanyManagment.App.Contracts.TaskTitle;
using MD.PersianDateTime;
using MD.PersianDateTime.Standard;

namespace CompanyManagment.Application
{
    public class TaskApplication : ITaskApplication
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IFileApplication _fileApplication;
        private readonly ITaskTitleApplication _taskTitleApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly ITaskStatusApplication _taskStatusApplication;
        private readonly _0_Framework.Application.IAuthHelper _authHelper;

        public TaskApplication(
            ITaskRepository taskRepository,
            IFileApplication fileApplication,
            ITaskTitleApplication TaskTitleApplication,
            IAccountApplication accountApplication,
            ITaskStatusApplication taskStatusApplication,
            _0_Framework.Application.IAuthHelper authHelper
        )
        {
            _taskRepository = taskRepository;
            _fileApplication = fileApplication;
            _taskTitleApplication = TaskTitleApplication;
            _accountApplication = accountApplication;
            _taskStatusApplication = taskStatusApplication;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateTask createTask)
        {
            var oprtaion = new OperationResult();

            if (createTask.TaskDate != null)
            {
                var task = new Task(createTask.Commander_Id, createTask.SeniorUser_Id, createTask.TaskTitle_Id,
                                createTask.Customer, createTask.Customer_Id, createTask.TaskDate.ToGeorgianDateTime(), createTask.Description);

                _taskRepository.Create(task);

                var taskStatus = new EditTaskStatus
                {
                    DeadlineExtentionDate = createTask.TaskDate.ToGeorgianDateTime(),
                    DeadlineExtentionRegDate = DateTime.Now,
                    DeadlineExtentionRegUserId = _authHelper.CurrentAccountId(),
                    Task_Id = task.id
                };

                _taskStatusApplication.CreateOrUpdateTaskStatus(taskStatus);

            }

            if (createTask.TaskFromDate != null)
            {
                for (var i = 0; i < createTask.TaskDuration; i++)
                {
                    var task = new Task(createTask.Commander_Id, createTask.SeniorUser_Id, createTask.TaskTitle_Id,
                                createTask.Customer, createTask.Customer_Id, createTask.TaskFromDate.ToGeorgianDateTime().AddMonths(i), createTask.Description);

                    _taskRepository.Create(task);

                    var taskStatus = new EditTaskStatus
                    {
                        DeadlineExtentionDate = createTask.TaskFromDate.ToGeorgianDateTime().AddMonths(i),
                        DeadlineExtentionRegDate = DateTime.Now,
                        DeadlineExtentionRegUserId = _authHelper.CurrentAccountId(),
                        Task_Id = task.id
                    };

                    _taskStatusApplication.CreateOrUpdateTaskStatus(taskStatus);
                }
            }

            _taskRepository.SaveChanges();
            return oprtaion.Succcedded();
        }

        public OperationResult Edit(EditTask command)
        {
            var result = new OperationResult();

            var task = _taskRepository.Get(command.Id);

            task.Edit(command.Commander_Id, command.SeniorUser_Id, command.TaskTitle_Id, command.Customer, command.Customer_Id, command.TaskDate.ToGeorgianDateTime(), command.Description);

            _taskRepository.SaveChanges();

            return result.Succcedded();
        }

        public OperationResult Remove(long id)
        {
            var result = new OperationResult();

            _taskRepository.Remove(id);

            return result.Succcedded();
        }

        public EditTask GetDetails(long id)
        {
            var task = _taskRepository.Get(id);
            var editTask = new EditTask
            {
                Id = task.id,
                Commander_Id = task.Commander_Id,
                SeniorUser_Id = task.SeniorUser_Id,
                Customer = task.Customer,
                Customer_Id = task.Customer_Id,
                Description = task.Description,
                TaskTitle_Id = task.TaskTitle_Id,
                TaskDate = task.TaskDate.ToFarsi(),

            };

            return editTask;
        }

        public List<TaskViewModel> Search(TaskSearchModel searchModel)
        {
            var tasks = _taskRepository.Search(searchModel);

            foreach (var task in tasks)
            {
                task.CommanderName = _accountApplication.GetAccountBy(task.Commander_Id).Fullname;
                task.SeniorUserName = _accountApplication.GetAccountBy(task.SeniorUser_Id).Fullname;

                if (task.CustomerName == null)
                    task.CustomerName = _fileApplication.GetEmployerFullNameById(task.Customer_Id);

                task.TaskTitle = _taskTitleApplication.GetDetails(task.TaskTitle_Id).Title;

                var statuses = _taskStatusApplication.Search(new TaskStatusSearchModel { TaskId = task.Id });

                if (statuses.Count != 0)
                    task.TaskStatus = statuses[0];

                task.TaskStatus.DeadlineExtentionFarsiDate = task.TaskStatus.DeadlineExtentionDate.ToFarsi();

                task.ReferralRecipientName = (task.TaskStatus.ReferralUserId != 0 && task.TaskStatus.ReferralStatus != TaskStatusEnums.REJECTED)
                    ? _accountApplication.GetAccountBy(task.TaskStatus.ReferralUserId).Fullname
                    : null;
            }


            return tasks;
        }

        public string GetDate(int type)
        {
            var persianDateTime = PersianDateTime.Today;
            switch (type)
            {
                case 0: //فردا
                    return persianDateTime.AddDays(1).ToString(); ;
                    break;

                case 1: //پسفردا
                    return persianDateTime.AddDays(2).ToString(); ;
                    break;

                case 2: //اول هفته
                    return persianDateTime.AddDays(7).GetFirstDayOfWeek().ToString(); ;
                    break;

                case 3: //آخر هفته
                    return persianDateTime.GetFirstDayOfWeek().AddDays(6 + 7).ToString(); ;
                    break;

                case 4: //وسط هفته                    
                    return persianDateTime.GetFirstDayOfWeek().AddDays(3 + 7).ToString(); ;
                    break;

                default:
                    return persianDateTime.ToString(); ;
            }

        }

        public List<TaskViewModel> GetTaskDetails(List<TaskViewModel> tasks)
        {
            foreach (var task in tasks)
            {
                task.TaskStatus = _taskStatusApplication.Search(new TaskStatusSearchModel { TaskId = task.Id }).FirstOrDefault() ?? new EditTaskStatus();
            }

            return tasks;
        }

        public List<TaskViewModel> FilterData(List<TaskViewModel> viewModels, TaskSearchModel searchModel)
        {
            if (searchModel.Commander_Id != 0)
                viewModels = viewModels.Where(x => x.Commander_Id == searchModel.Commander_Id).ToList();

            if (searchModel.SeniorUser_Id != 0)
                viewModels = viewModels.Where(x => x.SeniorUser_Id == searchModel.SeniorUser_Id || x.TaskStatus.ReferralUserId == searchModel.SeniorUser_Id).ToList();

            if (searchModel.TaskTitle_Id != 0)
                viewModels = viewModels.Where(x => x.TaskTitle_Id == searchModel.TaskTitle_Id).ToList();

            if (searchModel.Customer != null)
                viewModels = viewModels.Where(x => x.CustomerName.Contains(searchModel.Customer)).ToList();

            if (searchModel.Description != null)
                viewModels = viewModels.Where(x => x.Description != null && x.Description.Contains(searchModel.Description)).ToList();

            if (searchModel.TaskDateFrom != null)
                viewModels = viewModels.Where(x => x.TaskDate.ToGeorgianDateTime() >= searchModel.TaskDateFrom.ToGeorgianDateTime()).ToList();

            if (searchModel.TaskDateTo != null)
                viewModels = viewModels.Where(x => x.TaskDate.ToGeorgianDateTime() <= searchModel.TaskDateTo.ToGeorgianDateTime()).ToList();

            if (searchModel.ReferralStatus == TaskStatusEnums.NOTSET)
                viewModels = viewModels.Where(x => x.TaskStatus.ReferralStatus == TaskStatusEnums.NOTSET || x.TaskStatus.ReferralStatus == TaskStatusEnums.REJECTED).ToList();
            
            if (searchModel.ReferralStatus == TaskStatusEnums.UNAPPROVED)
                viewModels = viewModels.Where(x => x.TaskStatus.ReferralStatus == TaskStatusEnums.UNAPPROVED).ToList();
            
            if (searchModel.ReferralStatus == TaskStatusEnums.REJECTED)
                viewModels = viewModels.Where(x => x.TaskStatus.ReferralStatus == TaskStatusEnums.REJECTED).ToList();
            
            if (searchModel.ReferralStatus == TaskStatusEnums.SENIOR_APPROVAL || searchModel.ReferralStatus == TaskStatusEnums.MANAGER_APPROVAL)
                viewModels = viewModels.Where(x => x.TaskStatus.ReferralStatus == TaskStatusEnums.SENIOR_APPROVAL || x.TaskStatus.ReferralStatus == TaskStatusEnums.MANAGER_APPROVAL).ToList();

            if (searchModel.DeadlineExtensionStatus == TaskStatusEnums.NOTSET)
                viewModels = viewModels.Where(x => x.TaskStatus.DeadlineExtentionStatus == TaskStatusEnums.NOTSET || x.TaskStatus.DeadlineExtentionStatus == TaskStatusEnums.REJECTED).ToList();

            if (searchModel.DeadlineExtensionStatus == TaskStatusEnums.UNAPPROVED)
                viewModels = viewModels.Where(x => x.TaskStatus.DeadlineExtentionStatus == TaskStatusEnums.UNAPPROVED).ToList();

            if (searchModel.DeadlineExtensionStatus == TaskStatusEnums.REJECTED)
                viewModels = viewModels.Where(x => x.TaskStatus.DeadlineExtentionStatus == TaskStatusEnums.REJECTED).ToList();

            if (searchModel.DeadlineExtensionStatus == TaskStatusEnums.SENIOR_APPROVAL || searchModel.DeadlineExtensionStatus == TaskStatusEnums.MANAGER_APPROVAL)
                viewModels = viewModels.Where(x => x.TaskStatus.DeadlineExtentionStatus == TaskStatusEnums.SENIOR_APPROVAL || x.TaskStatus.DeadlineExtentionStatus == TaskStatusEnums.MANAGER_APPROVAL).ToList();

            if (searchModel.ImpossibilityStatus == TaskStatusEnums.NOTSET)
                viewModels = viewModels.Where(x => x.TaskStatus.ImpossibilityStatus == TaskStatusEnums.NOTSET || x.TaskStatus.ImpossibilityStatus == TaskStatusEnums.REJECTED).ToList();

            if (searchModel.ImpossibilityStatus == TaskStatusEnums.UNAPPROVED)
                viewModels = viewModels.Where(x => x.TaskStatus.ImpossibilityStatus == TaskStatusEnums.UNAPPROVED).ToList();

            if (searchModel.ImpossibilityStatus == TaskStatusEnums.REJECTED)
                viewModels = viewModels.Where(x => x.TaskStatus.ImpossibilityStatus == TaskStatusEnums.REJECTED).ToList();

            if (searchModel.ImpossibilityStatus == TaskStatusEnums.SENIOR_APPROVAL || searchModel.ImpossibilityStatus == TaskStatusEnums.MANAGER_APPROVAL)
                viewModels = viewModels.Where(x => x.TaskStatus.ImpossibilityStatus == TaskStatusEnums.SENIOR_APPROVAL || x.TaskStatus.ImpossibilityStatus == TaskStatusEnums.MANAGER_APPROVAL).ToList();

            if (searchModel.DoneStatus == TaskStatusEnums.NOTSET)
                viewModels = viewModels.Where(x => x.TaskStatus.DoneStatus == TaskStatusEnums.NOTSET || x.TaskStatus.DoneStatus == TaskStatusEnums.REJECTED).ToList();

            if (searchModel.DoneStatus == TaskStatusEnums.UNAPPROVED)
                viewModels = viewModels.Where(x => x.TaskStatus.DoneStatus == TaskStatusEnums.UNAPPROVED).ToList();

            if (searchModel.DoneStatus == TaskStatusEnums.REJECTED)
                viewModels = viewModels.Where(x => x.TaskStatus.DoneStatus == TaskStatusEnums.REJECTED).ToList();

            if (searchModel.DoneStatus == TaskStatusEnums.SENIOR_APPROVAL || searchModel.DoneStatus == TaskStatusEnums.MANAGER_APPROVAL)
                viewModels = viewModels.Where(x => x.TaskStatus.DoneStatus == TaskStatusEnums.SENIOR_APPROVAL || x.TaskStatus.DoneStatus == TaskStatusEnums.MANAGER_APPROVAL).ToList();

            return viewModels;
        }
    }
}
