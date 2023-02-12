using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.TaskStatus
{
    public interface ITaskStatusApplication
    {
        OperationResult Create(CreateTaskStatus command);
        OperationResult Edit(EditTaskStatus command);
        OperationResult Remove(long id);
        EditTaskStatus GetDetails(long id);
        EditTaskStatus GetDetails(long fileId, int boardTypeId);
        List<EditTaskStatus> Search(TaskStatusSearchModel searchModel);
        void CreateOrUpdateTaskStatus(EditTaskStatus editTaskStatus);
        OperationResult SetRefferal(EditTaskStatus editTaskStatus);
        OperationResult SetDeadline(EditTaskStatus editTaskStatus);
        OperationResult SetImpossibility(EditTaskStatus editTaskStatus);
        OperationResult SetDone(EditTaskStatus editTaskStatus);
    }
}
