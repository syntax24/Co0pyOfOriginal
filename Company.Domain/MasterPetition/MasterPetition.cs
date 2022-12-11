using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.MasterPetition
{
    public class MasterPetition : EntityBase
    {
        public MasterPetition(string masterName, string description, string workHistoryDescreption, int boardType_Id, long file_Id)
        {
            MasterName = masterName;
            //TotalPenalty = totalPenalty;
            //TotalPenaltyTitles = totalPenaltyTitles;
            Description = description;
            WorkHistoryDescreption = workHistoryDescreption;
            BoardType_Id = boardType_Id;
            File_Id = file_Id;
            MasterWorkHistoriesList = new List<MasterWorkHistory.MasterWorkHistory>();
            MasterPenaltyTitlesList = new List<MasterPenaltyTitle.MasterPenaltyTitle>();
        }

        public string MasterName { get; private set; }
        //public string TotalPenalty { get; private set; }
        //public string TotalPenaltyTitles { get; private set; }
        public string Description { get; private set; }
        public string WorkHistoryDescreption { get; private set; }

        public int BoardType_Id { get; private set; }
        public long File_Id { get; private set; }
        
        public File1.File1 File1 { get; private set; }
        public BoardType.BoardType BoardType { get; private set; }
        public List<MasterPenaltyTitle.MasterPenaltyTitle> MasterPenaltyTitlesList { get; private set; }
        public List<MasterWorkHistory.MasterWorkHistory> MasterWorkHistoriesList { get; private set; }


        public void Edit(string masterName, string description, string workHistoryDescreption, int boardType_Id, long file_Id)
        {
            MasterName = masterName;
            //TotalPenalty = totalPenalty;
            //TotalPenaltyTitles = totalPenaltyTitles;
            Description = description;
            WorkHistoryDescreption = workHistoryDescreption;
            BoardType_Id = boardType_Id;
            File_Id = file_Id;
        }
    }
}