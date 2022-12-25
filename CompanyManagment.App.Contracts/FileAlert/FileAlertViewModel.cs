using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.FileState;
using CompanyManagment.App.Contracts.FileTiming;
using System;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.FileAlert
{
    public class FileAlertViewModel
    {
        public long Id { get; set; }
        public long File_Id { get; set; }
        public long FileState_Id { get; set; }
        public int AdditionalDeadline { get; set; }
        public bool IsExpired { get; set; }
        public CreateFile File { get; set; }
        public FileStateViewModel FileState { get; set; }

        
    }
}