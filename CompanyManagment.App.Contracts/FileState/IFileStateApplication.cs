using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.File1;

namespace CompanyManagment.App.Contracts.FileState
{
    public interface IFileStateApplication
    {
        OperationResult Create(CreateFileState command);
        OperationResult Edit(EditFileState command);
        FileStateViewModel GetDetails(long id);
        //OperationResult Remove(long id);
        List<EditFileState> Search(FileStateSearchModel searchModel);
        int GetFileState(FileViewModel file);
        DateTime? GetFileStateDate(FileViewModel file);
    }
}
