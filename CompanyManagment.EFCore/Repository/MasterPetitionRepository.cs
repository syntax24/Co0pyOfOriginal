using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.MasterPetition;
using CompanyManagment.App.Contracts.MasterPetition;


namespace CompanyManagment.EFCore.Repository
{
    public class MasterPetitionRepository : RepositoryBase<long, MasterPetition>, IMasterPetitionRepository
    {
        private readonly CompanyContext _context;
        public MasterPetitionRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditMasterPetition GetDetails(long id)
        {
            return _context.MasterPetitions.Select(x => new EditMasterPetition
            {
                Id = x.id,
                MasterName = x.MasterName,
                //TotalPenalty = x.TotalPenalty,
                //TotalPenaltyTitles = x.TotalPenaltyTitles,
                Description = x.Description,
                WorkHistoryDescription = x.WorkHistoryDescreption,
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public EditMasterPetition GetDetails(long fileId, int boardTypeId)
        {
            return _context.MasterPetitions.Select(x => new EditMasterPetition
            {
                Id = x.id,
                MasterName = x.MasterName,
                //TotalPenalty = x.TotalPenalty,
                //TotalPenaltyTitles = x.TotalPenaltyTitles,
                Description = x.Description,
                WorkHistoryDescription = x.WorkHistoryDescreption,
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id
            }).FirstOrDefault(x => x.File_Id == fileId && x.BoardType_Id == boardTypeId);
        }

        public void Remove(long id)
        {
            var petition = _context.MasterPetitions.Where(x => x.id == id).FirstOrDefault();

            Remove(petition);
        }

        public List<EditMasterPetition> Search(MasterPetitionSearchModel searchModel)
        {
            var query = _context.MasterPetitions.Select(x => new EditMasterPetition
            {
                Id = x.id,
                MasterName = x.MasterName,
                //TotalPenalty = x.TotalPenalty,
                //TotalPenaltyTitles = x.TotalPenaltyTitles,
                Description = x.Description,
                WorkHistoryDescription = x.WorkHistoryDescreption,
                BoardType_Id = x.BoardType_Id,
                File_Id = x.File_Id,
            });

            //TODO if
            if (searchModel.File_Id != 0)
            {
                query = query.Where(x => x.File_Id == searchModel.File_Id);
            }
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
