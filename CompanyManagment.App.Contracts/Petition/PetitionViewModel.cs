using System;

namespace CompanyManagment.App.Contracts.Petition
{
    public class PetitionViewModel
    {
        public long Id { get; set; }
        public DateTime PetitionIssuanceDate { get; set; }
        public DateTime NotificationPetitionDate { get; set; }
        public string TotalPenalty { get; set; }
        public string TotalPenaltyTitles { get; set; }
        public string Description { get; set; }
        public long BoardType_Id { get; set; }
        public long File_Id { get; set; }
    }
}