using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.WorkHistory;
using CompanyManagment.App.Contracts.WorkHistory;
using CompanyManagment.EFCore;


namespace File.EfCore.Repository
{
    public class WorkHistoryRepository : RepositoryBase<long, WorkHistory>, IWorkHistoryRepository
    {
        private readonly CompanyContext _context;
        public WorkHistoryRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<EditWorkHistory> Search(long petitionId)
        {
            var query = _context.WorkHistory.Select(x => new EditWorkHistory
            {
                Id = x.id,
                FromDate = x.FromDate.ToFarsi(),
                ToDate = x.ToDate.ToFarsi(),
                WorkingHoursPerDay = x.WorkingHoursPerDay.ToString(),
                WorkingHoursPerWeek = x.WorkingHoursPerWeek.ToString(),
                Description = x.Description,
                Petition_Id = petitionId
            }).Where(x => x.Petition_Id == petitionId);

            //TODO if

            return query.ToList();
        }

        public void RemoveWorkHistories(List<EditWorkHistory> workHistories)
        {
            foreach(var obj in workHistories)
            {
                var workHistory = Get(obj.Id);

                Remove(workHistory);
            }
        }
    }
}
