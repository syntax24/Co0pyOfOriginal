using System;

namespace CompanyManagment.App.Contracts.FileTiming
{
    public class FileTimingViewModel
    {
        public long Id { get; set; }
        public int Deadline { get; set; }
        public string Title { get; set; }
    }
}