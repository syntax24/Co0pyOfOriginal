using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
