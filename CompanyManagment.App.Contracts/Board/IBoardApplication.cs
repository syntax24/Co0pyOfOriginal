using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Board
{
    public interface IBoardApplication
    {
        OperationResult2 Create(CreateBoard command);
        OperationResult2 Edit(EditBoard command);
        EditBoard GetDetails(long id); 
        EditBoard GetDetails(long fileId, int boardTypeId);
        List<EditBoard> Search(BoardSearchModel searchModel);
    }
}
