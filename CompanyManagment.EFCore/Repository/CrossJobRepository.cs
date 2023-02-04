using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.CrossJobAgg;
using CompanyManagment.App.Contracts.CrossJob;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class CrossJobRepository : RepositoryBase<long, CrossJob>, ICrossJobRepository
    {
        private readonly CompanyContext _context;

        public CrossJobRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<CrossJobViewModel> GetCrossJob(long idGuild)
        {
            return _context.CrossJobs.Where(x=>x.CrossJobGuildId == idGuild)
                .Select(x => new CrossJobViewModel
            {
                Id = x.id,
                Title =x.Title,
                SalaryRatioOver= x.SalaryRatioOver,
                SalaryRatioUnder=x.SalaryRatioUnder,
                EquivalentRialOver=x.EquivalentRialOver,
                EquivalentRialUnder=x.EquivalentRialUnder,
                CrossJobGuildId = x.CrossJobGuildId,
                parentRowId = x.ParentRowId
            }).ToList();
        }

      

        public EditCrossJob GetDetails(long id)
        {
            return _context.CrossJobs.Select(x => new EditCrossJob
            {
                Id = x.id,
                Title = x.Title,
                SalaryRatioOver = x.SalaryRatioOver,
                SalaryRatioUnder = x.SalaryRatioUnder,
                EquivalentRialOver = x.EquivalentRialOver,
                EquivalentRialUnder = x.EquivalentRialUnder,
                CrossJobGuildId = x.CrossJobGuildId,
                parentRowId = x.ParentRowId
            })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<CrossJobViewModel> Search(CrossJobSearchModel searchModel)
        {
            var query = _context.CrossJobs.Select(x => new CrossJobViewModel
            {
                Id = x.id,
                Title = x.Title,
                SalaryRatioOver = x.SalaryRatioOver,
                SalaryRatioUnder = x.SalaryRatioUnder,
                EquivalentRialOver = x.EquivalentRialOver,
                EquivalentRialUnder = x.EquivalentRialUnder,
                CrossJobGuildId = x.CrossJobGuildId,
                parentRowId = x.ParentRowId
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            if (searchModel.CrossJobGuildId != 0)
                query = query.Where(x => x.CrossJobGuildId==searchModel.CrossJobGuildId);
            if (searchModel.parentRowId != 0)
                query = query.Where(x => x.parentRowId == searchModel.parentRowId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
        public void Remove(long id)
        {
            var query = _context.CrossJobs.Where(x => x.id == id).FirstOrDefault();
            Remove(query);
        }
        public void RemoveRange(long id)
        {
            var query = _context.CrossJobs.Where(x => x.CrossJobGuildId == id);
            RemoveRange(query);
        }


    }
}
