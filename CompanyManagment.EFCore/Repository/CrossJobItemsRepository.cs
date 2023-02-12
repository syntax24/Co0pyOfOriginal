using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.CrossJobAgg;
using Company.Domain.CrossJobItemsAgg;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobItems;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class CrossJobItemsRepository : RepositoryBase<long, CrossJobItems>, ICrossJobItemsRepository
    {
        private readonly CompanyContext _context;

        public CrossJobItemsRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<CrossJobItemsViewModel> GetCrossJobItems(long idCrossJob)
        {
            return _context.CrossJobItems.Where(x => x.CrossJob.CrossJobGuildId == idCrossJob).Include(c => c.Job).Include(c => c.CrossJob)
                .Select(x => new CrossJobItemsViewModel
                {
                    Id = x.id,
                    crossJobId = x.CrossJobId,
                    jobId = x.JobId,
                    job = new App.Contracts.Job.JobViewModel
                    {
                        Id = x.Job.id,
                        JobName = x.Job.JobName
                    },
                    crossJob = new App.Contracts.CrossJob.CrossJobViewModel
                    {
                        Id = x.CrossJob.id,
                        SalaryRatioOver = x.CrossJob.SalaryRatioOver,
                        SalaryRatioUnder = x.CrossJob.SalaryRatioUnder,
                        EquivalentRialOver = x.CrossJob.EquivalentRialOver,
                        EquivalentRialUnder = x.CrossJob.EquivalentRialUnder,
                        CrossJobGuildId = x.CrossJob.CrossJobGuildId
                    }
                }).ToList();
        }



        public CrossJobItemsViewModel GetDetails(long id)
        {
            return _context.CrossJobItems.Include(c => c.Job).Include(d => d.CrossJob).Select(x => new CrossJobItemsViewModel
            {
                Id = x.id,
                crossJobId = x.CrossJobId,
                jobId = x.JobId,
                job = new App.Contracts.Job.JobViewModel
                {
                    Id = x.Job.id,
                    JobName = x.Job.JobName
                },
                crossJob = new App.Contracts.CrossJob.CrossJobViewModel
                {
                    Id = x.CrossJob.id,
                    SalaryRatioOver = x.CrossJob.SalaryRatioOver,
                    SalaryRatioUnder = x.CrossJob.SalaryRatioUnder,
                    EquivalentRialOver = x.CrossJob.EquivalentRialOver,
                    EquivalentRialUnder = x.CrossJob.EquivalentRialUnder,
                    CrossJobGuildId = x.CrossJob.CrossJobGuildId
                }
            })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<CrossJobItemsViewModel> Search(CrossJobItemsSearchModel searchModel)
        {
            var query = _context.CrossJobItems.Include(c => c.Job).Include(c=>c.CrossJob).Select(x => new CrossJobItemsViewModel
            {
                Id = x.id,
                crossJobId = x.CrossJobId,
                jobId = x.JobId,
                job = new App.Contracts.Job.JobViewModel
                {
                    Id = x.Job.id,
                    JobName = x.Job.JobName
                },
                crossJob = new App.Contracts.CrossJob.CrossJobViewModel
                {
                    Id = x.CrossJob.id,
                    SalaryRatioOver = x.CrossJob.SalaryRatioOver,
                    SalaryRatioUnder = x.CrossJob.SalaryRatioUnder,
                    EquivalentRialOver = x.CrossJob.EquivalentRialOver,
                    EquivalentRialUnder = x.CrossJob.EquivalentRialUnder,
                    CrossJobGuildId = x.CrossJob.CrossJobGuildId
                }
            });
            if (searchModel.crossJobId != 0)
                query = query.Where(x => x.crossJobId == searchModel.crossJobId);

            if (searchModel.jobId != 0)
                query = query.Where(x => x.jobId == searchModel.jobId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
        public void Remove(long id)
        {
            var query = _context.CrossJobItems.Where(x => x.id == id).FirstOrDefault();
            Remove(query);
        }

        public void RemoveRange(long idcrossJob)
        {
            var query = _context.CrossJobItems.Where(x => x.CrossJobId == idcrossJob);
            RemoveRange(query);
        }


    }
}
