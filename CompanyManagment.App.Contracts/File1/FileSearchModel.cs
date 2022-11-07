using System.Collections.Generic;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.ProceedingSession;

namespace CompanyManagment.App.Contracts.File1
{
    public class FileSearchModel
    {

        public string ArchiveNo { get; set; }

        //public string ClientVisitDate { get; set; }
        //public string ProceederReference { get; set; }

        public long Reqester { get; set; }
        public long Summoned { get; set; }
        public long UserId { get; set; }
        public string FileClass { get; set; }
        public int HasMandate { get; set; }
        public string Description { get; set; }
        public List<ArchiveNo_FileClassList> ArchiveNo_FileClassList { get; set; }

        //public List<User> Users { get; set; }
        public BoardSearchModel diagnosisBoard { get; set; }
        public BoardSearchModel disputeResolutionBoard { get; set; }
        public ProceedingSessionSearchModel diagnosisProceedingSession { get; set; }
        public ProceedingSessionSearchModel disputeResolutionProceedingSession { get; set; }

    }


    public class ArchiveNo_FileClassList
    {
        public string ArchiveNo { get; set; }
        public string FileClass { get; set; }
    }
}