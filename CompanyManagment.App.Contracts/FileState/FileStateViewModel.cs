using System;

namespace CompanyManagment.App.Contracts.FileState
{
    public class FileStateViewModel
    {
        public long Id { get; set; }
        public int State { get; set; }
        public long FileTiming_Id { get; set; }
        public string Title { get; set; }
    }
}