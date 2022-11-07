using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.Board;
using CompanyManagment.App.Contracts.Board;


namespace CompanyManagment.EFCore.Repository
{
    public class BoardRepository : RepositoryBase<long, Board>, IBoardRepository
    {
        private readonly CompanyContext _context;
        public BoardRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditBoard GetDetails(long id)
        {
            return _context.Boards.Select(x => new EditBoard
            {
                Id = x.id,
                BoardChairman = x.BoardChairman,
                Branch = x.Branch,
                ExpertReport = x.ExpertReport,
                DisputeResolutionPetitionDate = x.DisputeResolutionPetitionDate.ToFarsi(),
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id,
            }).FirstOrDefault(x => x.Id == id);
        }

        public EditBoard GetDetails(long fileId, int boardTypeId)
        {
            return _context.Boards.Select(x => new EditBoard
            {
                Id = x.id,
                BoardChairman = x.BoardChairman,
                Branch = x.Branch,
                ExpertReport = x.ExpertReport,
                DisputeResolutionPetitionDate = x.DisputeResolutionPetitionDate.ToFarsi(),
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id,
            }).FirstOrDefault(x => x.File_Id == fileId && x.BoardType_Id == boardTypeId);
        }

        public List<EditBoard> Search(BoardSearchModel searchModel)
        {
            var query = _context.Boards.Select(x => new EditBoard
            {
                Id = x.id,
                BoardChairman = x.BoardChairman,
                Branch = x.Branch,
                ExpertReport = x.ExpertReport,
                DisputeResolutionPetitionDate = x.DisputeResolutionPetitionDate.ToFarsi(),
                File_Id = x.File_Id,
                BoardType_Id = x.BoardType_Id,
            }).Where(x => x.File_Id == searchModel.File_Id && x.BoardType_Id == searchModel.BoardType_Id);

            //TODO if
            if (!string.IsNullOrEmpty(searchModel.Branch))
            {
                query = query.Where(x => x.Branch.Contains(searchModel.Branch));
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
