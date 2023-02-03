using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.FileState
{
    public class EditFileState : CreateFileState
    {
        public long Id { get; set; }
        public int Deadline { get; set; }

    }
}