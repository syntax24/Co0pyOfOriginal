using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
