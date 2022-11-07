using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Job;

namespace Company.Domain.JobAgg
{
    public interface IJobRepository : IRepository<long, Job>
    {
        List<JobViewModel> GetJob();
        EditJob GetDetails(long id);
        List<JobViewModel> Search(JobSearchModel searchModel);
    }
}
