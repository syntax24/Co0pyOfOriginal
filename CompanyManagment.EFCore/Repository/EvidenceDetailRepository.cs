using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.EvidenceDetail;
using CompanyManagment.App.Contracts.EvidenceDetail;


namespace CompanyManagment.EFCore.Repository
{
    public class EvidenceDetailRepository : RepositoryBase<long, EvidenceDetail>, IEvidenceDetailRepository
    {
        private readonly CompanyContext _context;
        public EvidenceDetailRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public void RemoveEvidenceDetails(List<EditEvidenceDetail> evidences)
        {
            foreach (var obj in evidences)
            {
                var evidence = Get(obj.Id);

                Remove(evidence);
            }
        }

        public List<EditEvidenceDetail> Search(long evidenceId)
        {
            var query = _context.EvidenceDetails.Select(x => new EditEvidenceDetail
            {
                Id = x.id,
                FromDate = x.FromDate.ToFarsi(),
                ToDate = x.ToDate.ToFarsi(),
                Title = x.Title,
                Day = x.Day,
                Description = x.Description,
                Evidence_Id = x.Evidence_Id
            }).Where(x => x.Evidence_Id == evidenceId);

            //TODO if

            return query.ToList();
        }
    }
}
