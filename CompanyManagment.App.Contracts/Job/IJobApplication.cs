using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Job
{
    public interface IJobApplication
    {
        OperationResult Create(CreateJob command);
        OperationResult Edit(EditJob command);
        EditJob GetDetails(long id);
        List<JobViewModel> GetJob();
        List<JobViewModel> Search(JobSearchModel searchModel);
    }
}
