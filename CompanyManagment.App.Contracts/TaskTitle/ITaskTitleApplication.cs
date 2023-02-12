using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using MD.PersianDateTime;

namespace CompanyManagment.App.Contracts.TaskTitle
{
    public interface ITaskTitleApplication
    {
        OperationResult Create(CreateTaskTitle command);
        OperationResult Edit(EditTaskTitle command);
        OperationResult Remove(long id);
        EditTaskTitle GetDetails(long id);       
        List<TaskTitleViewModel> Search(TaskTitleSearchModel searchModel);
    }
}
