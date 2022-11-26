using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.Board
{
    public interface IBoardApplication
    {
        OperationResult Create(CreateBoard command);
        OperationResult Edit(EditBoard command);
        EditBoard GetDetails(long id); 
        EditBoard GetDetails(long fileId, int boardTypeId);
        List<EditBoard> Search(BoardSearchModel searchModel);
    }
}
