﻿namespace CompanyManagment.App.Contracts.MasterPetition
{
    public class MasterPetitionSearchModel
    {
        //public string PetitionIssuanceDate { get; set; }
        //public string NotificationPetitionDate { get; set; }
        //public string TotalPenalty { get; set; }
        //public string TotalPenaltyTitles { get; set; }
        public string Description { get; set; }
        public string WorkHistoryDescription { get; set; }
        public long Board_Id { get; set; }
        public long File_Id { get; set; }
    }
}