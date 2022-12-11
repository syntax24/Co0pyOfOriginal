using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.Evidence;
using CompanyManagment.App.Contracts.Evidence;


namespace CompanyManagment.EFCore.Repository
{
    public class EvidenceRepository : RepositoryBase<long, Evidence>, IEvidenceRepository
    {
        private readonly CompanyContext _context;
        public EvidenceRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditEvidence GetDetails(long id)
        {
            return _context.Evidences.Select(x => new EditEvidence
            {
                Id = x.id,
                Description = x.Description,
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public EditEvidence GetDetails(long fileId, int boardTypeId)
        {
            return _context.Evidences.Select(x => new EditEvidence
            {
                Id = x.id,
                Description = x.Description,
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id
            }).FirstOrDefault(x => x.File_Id == fileId && x.BoardType_Id == boardTypeId);
        }

        public void Remove(long id)
        {
            var evidence = _context.Evidences.Where(x => x.id == id).FirstOrDefault();

            Remove(evidence);
        }

        public List<EditEvidence> Search(EvidenceSearchModel searchModel)
        {
            var query = _context.Evidences.Select(x => new EditEvidence
            {
                Id = x.id,
                Description = x.Description,
                BoardType_Id = x.BoardType_Id,
                File_Id = x.File_Id,
            });

            //TODO if
            if (searchModel.File_Id != 0)
            {
                query = query.Where(x => x.File_Id == searchModel.File_Id);
            }
            //if(!string.IsNullOrEmpty(searchModel.EvidenceIssuanceDate))
            //{
            //    query = query.Where(x => x.EvidenceIssuanceDate == searchModel.EvidenceIssuanceDate);
            //}

            //if(!string.IsNullOrEmpty(searchModel.NotificationEvidenceDate))
            //{
            //    query = query.Where(x => x.NotificationEvidenceDate == searchModel.NotificationEvidenceDate);
            //}

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
