using System;
using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.Task
{
    public interface ITaskApplication
    {
        OperationResult Create(CreateTask command);
        OperationResult Edit(EditTask command);
        OperationResult Remove(long id);
        EditTask GetDetails(long id);
        string GetDate(int type);
        List<TaskViewModel> Search(TaskSearchModel searchModel);
        List<TaskViewModel> GetTaskDetails(List<TaskViewModel> tasks);
        List<TaskViewModel> FilterData(List<TaskViewModel> viewModels, TaskSearchModel searchModel);

    }
}
