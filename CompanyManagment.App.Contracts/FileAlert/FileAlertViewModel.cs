using System;

namespace CompanyManagment.App.Contracts.FileAlert
{
    public class FileAlertViewModel
    {
        public int File_Id { get; private set; }
        public int FileState_Id { get; private set; }
        public int AdditionalDeadline { get; private set; }
    }
}