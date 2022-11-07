using System;
using System.Collections.Generic;
using _0_Framework.Application;
using Company.Domain.Board;
using CompanyManagment.App.Contracts.Board;


namespace CompanyManagment.Application
{
    public class BoardApplication : IBoardApplication
    {
        private readonly IBoardRepository _boardRepository;

        public BoardApplication(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public OperationResult2 Create(CreateBoard command)
        {
            var operation = new OperationResult2();

            var disputeResolutionPetitionDate = new DateTime();

            disputeResolutionPetitionDate = command.DisputeResolutionPetitionDate.ToGeorgianDateTime();
            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var board = new Board(disputeResolutionPetitionDate, command.Branch, command.BoardChairman,
                command.ExpertReport,command.File_Id, command.BoardType_Id);
            _boardRepository.Create(board);
            _boardRepository.SaveChanges();

            return operation.Succcedded(board.id);
        }

        public OperationResult2 Edit(EditBoard command)
        {
            var operation = new OperationResult2();
            var board = _boardRepository.Get(command.Id);

            var disputeResolutionPetitionDate = new DateTime();
            disputeResolutionPetitionDate = command.DisputeResolutionPetitionDate.ToGeorgianDateTime();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            board.Edit(disputeResolutionPetitionDate, command.Branch, command.BoardChairman,
                command.ExpertReport,command.File_Id,command.BoardType_Id);
            _boardRepository.SaveChanges();

            return operation.Succcedded(board.id);
        }

        public EditBoard GetDetails(long id)
        {
            return _boardRepository.GetDetails(id);
        }

        public EditBoard GetDetails(long fileId, int boardTypeId)
        {
            return _boardRepository.GetDetails(fileId, boardTypeId);
        }

        public List<EditBoard> Search(BoardSearchModel searchModel)
        {
            return _boardRepository.Search(searchModel);
        }
    }
}
