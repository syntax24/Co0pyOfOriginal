using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.ProceedingSession;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.ProceedingSession
{
    public class ProceedingSessionViewModel
    {
        public string FullDate { get; set; }
        public List<File_Board_PS> SessionsList { get; set; }
    }

    public class File_Board_PS
    {
        public FileViewModel File { get; set; }
        public EditBoard Board { get; set; }
        public EditProceedingSession Session { get; set; }
    }

}
