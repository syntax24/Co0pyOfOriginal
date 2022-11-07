using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.File1
{
    public class File1 : EntityBase
    {
        public File1(long archiveNo, DateTime clientVisitDate, string proceederReference, long reqester, long summoned, int client, string fileClass, int hasMandate, string description)
        {
            ArchiveNo = archiveNo;
            ClientVisitDate = clientVisitDate;
            ProceederReference = proceederReference;
            Reqester = reqester;
            Summoned = summoned;
            Client = client;
            FileClass = fileClass;
            HasMandate = hasMandate;
            Description = description;
            BoardsList = new List<Board.Board>();
            PetitionsList = new List<Petition.Petition>();
        }


        public long ArchiveNo { get; private set; }
        public DateTime ClientVisitDate { get; private set; }
        public string ProceederReference { get; private set; }
        public long Reqester { get; private set; }
        public long Summoned { get; private set; }
        public int Client { get; private set; } // 1-> Requester , 2-> Summoned
        public string FileClass { get; private set; }
        public int HasMandate { get; private set; } // 1-> has not , 2-> has
        public string Description { get; private set; }

        public List<Board.Board> BoardsList { get; set; }
        public List<Petition.Petition> PetitionsList { get; set; }

        //public File()
        //{
        //    BoardsList = new List<Board.Board>();
        //}

        public void Edit(long archiveNo, DateTime clientVisitDate, string proceederReference, long reqester, long summoned, int client, string fileClass, int hasMandate, string description)
        {
            ArchiveNo = archiveNo;
            ClientVisitDate = clientVisitDate;
            ProceederReference = proceederReference;
            Reqester = reqester;
            Summoned = summoned;
            Client = client;
            FileClass = fileClass;
            HasMandate = hasMandate;
            Description = description;
        }
    }
}
