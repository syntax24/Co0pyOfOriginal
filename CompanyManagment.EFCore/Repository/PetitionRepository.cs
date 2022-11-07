using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.Petition;
using CompanyManagment.App.Contracts.Petition;


namespace CompanyManagment.EFCore.Repository
{
    public class PetitionRepository : RepositoryBase<long, Petition>, IPetitionRepository
    {
        private readonly CompanyContext _context;
        public PetitionRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditPetition GetDetails(long id)
        {
            return _context.Petitions.Select(x => new EditPetition
            {
                Id = x.id,
                PetitionIssuanceDate = x.PetitionIssuanceDate.ToFarsi(),
                NotificationPetitionDate = x.NotificationPetitionDate.ToFarsi(),
                TotalPenalty = x.TotalPenalty,
                TotalPenaltyTitles = x.TotalPenaltyTitles,
                Description = x.Description,
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public EditPetition GetDetails(long fileId, int boardTypeId)
        {
            return _context.Petitions.Select(x => new EditPetition
            {
                Id = x.id,
                PetitionIssuanceDate = x.PetitionIssuanceDate.ToFarsi(),
                NotificationPetitionDate = x.NotificationPetitionDate.ToFarsi(),
                TotalPenalty = x.TotalPenalty,
                TotalPenaltyTitles = x.TotalPenaltyTitles,
                Description = x.Description,
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id
            }).FirstOrDefault(x => x.File_Id == fileId && x.BoardType_Id == boardTypeId);
        }

        public List<EditPetition> Search(PetitionSearchModel searchModel)
        {
            var query = _context.Petitions.Select(x => new EditPetition
            {
                Id = x.id,
                PetitionIssuanceDate = x.PetitionIssuanceDate.ToFarsi(),
                NotificationPetitionDate = x.NotificationPetitionDate.ToFarsi(),
                TotalPenalty = x.TotalPenalty,
                TotalPenaltyTitles = x.TotalPenaltyTitles,
                Description = x.Description,
                BoardType_Id = x.BoardType_Id,
                File_Id = x.File_Id,
            });

            //TODO if
            //if(!string.IsNullOrEmpty(searchModel.PetitionIssuanceDate))
            //{
            //    query = query.Where(x => x.PetitionIssuanceDate == searchModel.PetitionIssuanceDate);
            //}

            //if(!string.IsNullOrEmpty(searchModel.NotificationPetitionDate))
            //{
            //    query = query.Where(x => x.NotificationPetitionDate == searchModel.NotificationPetitionDate);
            //}

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
