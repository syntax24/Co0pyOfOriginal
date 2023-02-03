using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.InfraStructure;
using Company.Domain.JobAgg;
using CompanyManagment.App.Contracts.Job;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class JobRepository: RepositoryBase<long, Job>, IJobRepository
    {
        private readonly CompanyContext _context;
        public JobRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<JobViewModel> GetJob()
        {
            return _context.Jobs.Select(x => new JobViewModel
            {
                Id = x.id,
                JobName = x.JobName,
                JobCode = x.JobCode
         

            }).ToList();
        }

        public EditJob GetDetails(long id)
        {
            return _context.Jobs.Select(x => new EditJob
                {
                    Id = x.id,
                    JobName = x.JobName,
                    JobCode = x.JobCode
         


                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<JobViewModel> Search(JobSearchModel searchModel)
        {
            var query = _context.Jobs.Select(x => new JobViewModel
            {
                Id = x.id,

                JobName = x.JobName,
                JobCode = x.JobCode

            });

            if (!string.IsNullOrWhiteSpace(searchModel.JobName))
                query = query.Where(x => x.JobName.Contains(searchModel.JobName));
            if (!string.IsNullOrWhiteSpace(searchModel.JobCode))
                query = query.Where(x => x.JobCode.Contains(searchModel.JobCode));

            return query.OrderBy(x => x.Id).ToList();
        }
    }
}
