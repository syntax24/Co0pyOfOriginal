using CompanyManagment.App.Contracts.FileState;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.FileAlert
{
    public class FileAlertSearchModel
    {
        public long File_Id { get; set; }
        public long FileState_Id { get; set; }
        public long UserId { get; set; }
        public string ArchiveNo { get; set; }
        public string FileClass { get; set; }
        public List<Users> UsersList { get; set; }
        public List<ArchiveNo_FileClass_UserIdList> ArchiveNo_FileClass_UserIdList { get; set; }
        public List<EditFileState> FileStatesList { get; set; }

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