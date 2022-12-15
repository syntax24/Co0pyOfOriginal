using System.Collections.Generic;
using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.FileAlert
{
    public interface IFileAlertApplication
    {
        OperationResult Create(CreateFileAlert command);
        OperationResult Edit(EditFileAlert command);
        OperationResult Remove(long id);
        List<EditFileAlert> Search(FileAlertSearchModel searchModel);
    }
}
