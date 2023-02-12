using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.TaskTitle;
using CompanyManagment.App.Contracts.TaskTitle;
using MD.PersianDateTime;

namespace CompanyManagment.Application
{
    public class TaskTitleApplication : ITaskTitleApplication
    {
        private readonly ITaskTitleRepository _taskTitleRepository;

        public TaskTitleApplication(ITaskTitleRepository taskTitleRepository)
        {
            _taskTitleRepository = taskTitleRepository;
        }

        public OperationResult Create(CreateTaskTitle command)
        {
            var result = new OperationResult();

            _taskTitleRepository.Create(new TaskTitle(command.Title));
            _taskTitleRepository.SaveChanges();

            return result.Succcedded();
        }

        public OperationResult Edit(EditTaskTitle command)
        {
            var result = new OperationResult();

            var taskTitle = _taskTitleRepository.Get(command.Id);

            taskTitle.Edit(command.Title);

            _taskTitleRepository.SaveChanges();

            return result.Succcedded();
        }

        public OperationResult Remove(long id)
        {
            return null;
        }

        public EditTaskTitle GetDetails(long id)
        {
            return _taskTitleRepository.GetDetails(id);
        }

        public List<TaskTitleViewModel> Search(TaskTitleSearchModel searchModel)
        {

            return _taskTitleRepository.Search(searchModel);
        }


    }
}
