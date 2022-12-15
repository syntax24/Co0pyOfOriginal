
using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.FileTiming
{
    public class FileTiming : EntityBase
    {
        public FileTiming()
        {
        }

        public FileTiming(int deadline, string title, string tips)
        {
            Deadline = deadline;
            Title = title;
            Tips = tips;

            FileStates = new List<FileState.FileState>();
        }

        public int Deadline { get; private set; }
        public string Title { get; private set; }
        public string Tips { get; private set; }

        public List<FileState.FileState> FileStates { get; private set; }


        public void Edit(int deadline)
        {
            Deadline = deadline;
        }
    }
}