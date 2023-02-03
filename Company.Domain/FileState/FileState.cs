
using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.FileState
{
    public class FileState : EntityBase
    {
        public FileState(int state, long fileTiming_Id, string title)
        {
            State = state;
            FileTiming_Id = fileTiming_Id;
            Title = title;
        }

        public int State { get; private set; }
        public long FileTiming_Id { get; private set; }
        public string Title { get; private set; }
        //public int State { get; private set; }

        public FileTiming.FileTiming FileTiming { get; private set; }
        public List<FileAlert.FileAlert> FileAlertsList { get; private set; }

        public void Edit(int state, long fileTiming_Id, string title)
        {
            State = state;
            FileTiming_Id = fileTiming_Id;
            Title = title;
        }
    }
}