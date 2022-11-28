using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.MasterWorkHistory;
using CompanyManagment.App.Contracts.MasterWorkHistory;
using CompanyManagment.EFCore;


namespace File.EfCore.Repository
{
    public class MasterWorkHistoryRepository : RepositoryBase<long, MasterWorkHistory>, IMasterWorkHistoryRepository
    {
        private readonly CompanyContext _context;
        public MasterWorkHistoryRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<EditMasterWorkHistory> Search(long masterPetitionId)
        {
            var query = _context.MasterWorkHistories.Select(x => new EditMasterWorkHistory
            {
                Id = x.id,
                FromDate = x.FromDate.ToFarsi(),
                ToDate = x.ToDate.ToFarsi(),
                WorkingHoursPerDay = x.WorkingHoursPerDay.ToString(),
                WorkingHoursPerWeek = x.WorkingHoursPerWeek.ToString(),
                Description = x.Description,
                MasterPetition_Id = x.MasterPetition_Id
            }).Where(x => x.MasterPetition_Id == masterPetitionId);

            //TODO if

            return query.ToList();
        }

        public void RemoveMasterWorkHistories(IEnumerable<EditMasterWorkHistory> masterWorkHistories)
        {
            foreach (var obj in masterWorkHistories)
            {
                var masterWorkHistory = Get(obj.Id);

                Remove(masterWorkHistory);
            }
        }
    }
}
