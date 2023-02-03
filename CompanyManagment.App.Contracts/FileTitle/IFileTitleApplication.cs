using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.FileTitle
{
    public interface IFileTitleApplication
    {
        OperationResult Create(CreateFileTitle command);
        OperationResult Edit(EditFileTitle command);
        OperationResult Remove(long id);
        List<EditFileTitle> Search(FileTitleSearchModel searchModel);
    }
}
