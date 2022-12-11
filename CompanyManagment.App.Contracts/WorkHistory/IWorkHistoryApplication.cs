using System.Collections.Generic;
using _0_Framework_b.Application;


namespace CompanyManagment.App.Contracts.WorkHistory
{
    public interface IWorkHistoryApplication
    {
        OperationResult Create(CreateWorkHistory command);
        OperationResult Edit(EditWorkHistory command);
        List<EditWorkHistory> Search(long petitionId);
        OperationResult CreateWorkHistories(List<EditWorkHistory> workHistories, long petitionId);
        void RemoveWorkHistories(long petitionId);
    }
}
