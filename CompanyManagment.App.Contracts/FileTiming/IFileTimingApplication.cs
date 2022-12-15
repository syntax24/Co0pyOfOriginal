using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.FileTiming
{
    public interface IFileTimingApplication
    {
        OperationResult Create(CreateFileTiming command);
        OperationResult Edit(EditFileTiming command);
        //OperationResult Remove(long id);
        List<EditFileTiming> Search(FileTimingSearchModel searchModel);
    }
}
