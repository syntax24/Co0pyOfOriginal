using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.PenaltyTitle;
using CompanyManagment.App.Contracts.PenaltyTitle;


namespace CompanyManagment.EFCore.Repository
{
    public class PenaltyTitleRepository : RepositoryBase<long, PenaltyTitle>, IPenaltyTitleRepository
    {
        private readonly CompanyContext _context;
        public PenaltyTitleRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public void RemovePenaltyTitles(List<EditPenaltyTitle> penaltyTitles)
        {
            foreach (var obj in penaltyTitles)
            {
                var penaltyTitle = Get(obj.Id);

                Remove(penaltyTitle);
            }
        }

        public List<EditPenaltyTitle> Search(long petitionId)
        {
            var query = _context.PenaltyTitles.Select(x => new EditPenaltyTitle
            {
                Id = x.id,
                FromDate = x.FromDate.ToFarsi(),
                ToDate = x.ToDate.ToFarsi(),
                Title = x.Title,
                Day = x.Day,
                PaidAmount = x.PaidAmount,
                RemainingAmount = x.RemainingAmount,
                Petition_Id = petitionId
            }).Where(x => x.Petition_Id == petitionId);

            //TODO if

            return query.ToList();
        }
    }
}
