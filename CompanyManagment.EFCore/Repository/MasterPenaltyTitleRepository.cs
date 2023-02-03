using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.MasterPenaltyTitle;
using CompanyManagment.App.Contracts.MasterPenaltyTitle;


namespace CompanyManagment.EFCore.Repository
{
    public class MasterPenaltyTitleRepository : RepositoryBase<long, MasterPenaltyTitle>, IMasterPenaltyTitleRepository
    {
        private readonly CompanyContext _context;
        public MasterPenaltyTitleRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public void RemoveMasterPenaltyTitles(List<EditMasterPenaltyTitle> masterPenaltyTitles)
        {
            foreach (var obj in masterPenaltyTitles)
            {
                var penaltyTitle = Get(obj.Id);

                Remove(penaltyTitle);
            }
        }

        public List<EditMasterPenaltyTitle> Search(long masterPetitionId)
        {
            var query = _context.MasterPenaltyTitles.Select(x => new EditMasterPenaltyTitle
            {
                Id = x.id,
                FromDate = x.FromDate.ToFarsi(),
                ToDate = x.ToDate.ToFarsi(),
                Title = x.Title,
                Day = x.Day,
                PaidAmount = x.PaidAmount,
                RemainingAmount = x.RemainingAmount,
                MasterPetition_Id = x.MasterPetition_Id
            }).Where(x => x.MasterPetition_Id == masterPetitionId);

            //TODO if

            return query.ToList();
        }
    }
}
