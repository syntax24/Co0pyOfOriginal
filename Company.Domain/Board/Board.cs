using _0_Framework.Domain;
using System;
using System.Collections.Generic;


namespace Company.Domain.Board
{
    public class Board : EntityBase
    {
        public Board(DateTime disputeResolutionPetitionDate, string branch, string boardChairman, string expertReport, long file_Id, int boardType_Id)
        {
            DisputeResolutionPetitionDate = disputeResolutionPetitionDate;
            Branch = branch;
            BoardChairman = boardChairman;
            ExpertReport = expertReport;
            File_Id = file_Id;
            BoardType_Id = boardType_Id;
            ProceedingSessionsList = new List<ProceedingSession.ProceedingSession>();
            //PetitionsList = new List<Petition.Petition>();
        }

        public DateTime DisputeResolutionPetitionDate { get; private set; }
        public string Branch { get; private set; }
        public string BoardChairman { get; private set; }
        public string ExpertReport { get; private set; }
        public long File_Id { get; private set; }
        public int BoardType_Id { get; private set; }

        public File1.File1 File1 { get; set; }
        public BoardType.BoardType BoardType { get; set; }
        public List<ProceedingSession.ProceedingSession> ProceedingSessionsList { get; set; }
        //public List<Petition.Petition> PetitionsList { get; set; }

        public void Edit(DateTime disputeResolutionPetitionDate, string branch, string boardChairman, string expertReport, long file_Id, int boardType_Id)
        {
            DisputeResolutionPetitionDate = disputeResolutionPetitionDate;
            Branch = branch;
            BoardChairman = boardChairman;
            ExpertReport = expertReport;
            File_Id = file_Id;
            BoardType_Id = boardType_Id;
        }
    }
}
