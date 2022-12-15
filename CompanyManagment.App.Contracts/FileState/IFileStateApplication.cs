using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.FileState
{
    public interface IFileStateApplication
    {
        OperationResult Create(CreateFileState command);
        OperationResult Edit(EditFileState command);
        //OperationResult Remove(long id);
        List<EditFileState> Search(FileStateSearchModel searchModel);
    }
}
