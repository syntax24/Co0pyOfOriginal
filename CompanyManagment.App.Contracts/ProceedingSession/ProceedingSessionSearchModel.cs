using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.File1;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.ProceedingSession
{
    public class ProceedingSessionSearchModel
    {
        public ProceedingSessionSearchModel()
        {
            Status = 1;
            File = new EditFile { ArchiveNo = -1 };
            Board = new EditBoard();
            UsersList = new List<Users>();
            ArchiveNo_FileClass_UserIdList = new List<ArchiveNo_FileClass_UserIdList>();
        }

        public long Id { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long Board_Id { get; set; }
        public int Status { get; set; }
        public long UserId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Time { get; set; }

        public List<Users> UsersList { get; set; }
        public List<ArchiveNo_FileClass_UserIdList> ArchiveNo_FileClass_UserIdList { get; set; }

        public EditFile File { get; set; }
        public EditBoard Board { get; set; }
    }

    public class ArchiveNo_FileClass_UserIdList
    {
        public string ArchiveNo { get; set; }
        public string FileClass { get; set; }
        public long UserId { get; set; }
    }

    public class Users
    {
        public long Id { get; set; }
        public string FullName { get; set; }
    }
}
