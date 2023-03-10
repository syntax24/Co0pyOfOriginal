using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.File1
{
    public class File1 : EntityBase
    {
        public File1(long archiveNo, DateTime clientVisitDate, string proceederReference, long reqester, long summoned, int client, string fileClass, int hasMandate, string description, int status = 2)
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
            MasterPetitionsList = new List<MasterPetition.MasterPetition>();
            Status = status;
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
        public int Status { get; private set; } // 1-> deactive , 2 -> active 

        public List<Board.Board> BoardsList { get; private set; }
        public List<Petition.Petition> PetitionsList { get; private set; }
        public List<MasterPetition.MasterPetition> MasterPetitionsList { get; private set; }
        public List<Evidence.Evidence> EvidencesList { get; set; }
        public List<FileAlert.FileAlert> FileAlertsList { get; set; }

        //public File()
        //{
        //    BoardsList = new List<Board.Board>();
        //}

        public void Edit(long archiveNo, DateTime clientVisitDate, string proceederReference, long reqester, long summoned, int client, string fileClass, int hasMandate, string description, int status = 2)
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
            Status = status;
        }
    }
}
