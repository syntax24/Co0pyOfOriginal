
using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.FileAlert
{
    public class FileAlert : EntityBase
    {
        public FileAlert(long file_Id, long fileState_Id, int additionalDeadline)
        {
            File_Id = file_Id;
            FileState_Id = fileState_Id;
            AdditionalDeadline = additionalDeadline;
        }

        public long File_Id { get; private set; }
        public long FileState_Id { get; private set; }
        public int AdditionalDeadline { get; private set; }

        public File1.File1 File { get; private set; }
        public FileState.FileState FileState { get; private set; }


        public void Edit(long file_Id, long fileState_Id, int additionalDeadline)
        {
            File_Id = file_Id;
            FileState_Id = fileState_Id;
            AdditionalDeadline = additionalDeadline;
        }
    }
}