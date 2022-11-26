using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Petition
{
    public class Petition : EntityBase
    {
        public Petition(DateTime petitionIssuanceDate, DateTime notificationPetitionDate, string totalPenalty, string totalPenaltyTitles, string description, int boardType_Id, long file_Id)
        {
            PetitionIssuanceDate = petitionIssuanceDate;
            NotificationPetitionDate = notificationPetitionDate;
            TotalPenalty = totalPenalty;
            TotalPenaltyTitles = totalPenaltyTitles;
            Description = description;
            BoardType_Id = boardType_Id;
            File_Id = file_Id;
            WorkHistoriesList = new List<WorkHistory.WorkHistory>();
            PenaltyTitlesList = new List<PenaltyTitle.PenaltyTitle>();
        }

        public DateTime PetitionIssuanceDate { get; private set; }
        public DateTime NotificationPetitionDate { get; private set; }
        public string TotalPenalty { get; private set; }
        public string TotalPenaltyTitles { get; private set; }
        public string Description { get; private set; }

        public int BoardType_Id { get; private set; }
        public long File_Id { get; private set; }
        public File1.File1 File1 { get; set; }
        public BoardType.BoardType BoardType { get; set; }

        public List<WorkHistory.WorkHistory> WorkHistoriesList { get; set; }
        public List<PenaltyTitle.PenaltyTitle> PenaltyTitlesList { get; set; }

        public void Edit(DateTime petitionIssuanceDate, DateTime notificationPetitionDate, string totalPenalty, string totalPenaltyTitles, string description, int boardType_Id, long file_Id)
        {
            PetitionIssuanceDate = petitionIssuanceDate;
            NotificationPetitionDate = notificationPetitionDate;
            TotalPenalty = totalPenalty;
            TotalPenaltyTitles = totalPenaltyTitles;
            Description = description;
            BoardType_Id = boardType_Id;
            File_Id = file_Id;
        }
    }
}
