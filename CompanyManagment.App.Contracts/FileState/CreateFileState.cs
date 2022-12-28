using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.FileState
{
    public class CreateFileState
    {
        public int State { get; set; }
        public long FileTiming_Id { get; set; }
        public string Title { get; set; }
    }
}
