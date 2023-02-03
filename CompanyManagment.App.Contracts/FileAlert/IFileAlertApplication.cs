using System.Collections.Generic;
using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.File1;

namespace CompanyManagment.App.Contracts.FileAlert
{
    public interface IFileAlertApplication
    {
        FileAlertViewModel GetDetails(long id);
        OperationResult Create(CreateFileAlert command);
        OperationResult Edit(EditFileAlert command);
        OperationResult Remove(long id);
        List<EditFileAlert> Search(FileAlertSearchModel searchModel);
        List<FileAlertViewModel> GetFilesAlerts(List<FileViewModel> files);
        int getMaximumAdditionalDeadlineTimes(int additionalDeadline);
    }
}
