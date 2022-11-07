using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Board;


namespace Company.Domain.Board
{
    public interface IBoardRepository : IRepository<long, Board>
    {
        EditBoard GetDetails(long id);
        EditBoard GetDetails(long fileId, int boardTypeId);
        List<EditBoard> Search(BoardSearchModel searchModel);
    }
}
