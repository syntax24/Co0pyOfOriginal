using System.Collections.Generic;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.PenaltyTitle;
using CompanyManagment.App.Contracts.WorkHistory;

namespace CompanyManagment.App.Contracts.Petition
{
    public class CreatePetition
    {
        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string PetitionIssuanceDate { get; set; }
        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string NotificationPetitionDate { get; set; }
        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string TotalPenalty { get; set; }
        public string TotalPenaltyTitles { get; set; }
        public string TotalPaidAmounts { get; set; }
        public string Description { get; set; }
        public string WorkHistoryDescription { get; set; }
        public int BoardType_Id { get; set; }
        public long File_Id { get; set; }

        public bool BoardProcessingStage { get; set; }
        public EditFile FileData { get; set; }
        public List<EditWorkHistory> CreateWorkHistory { get; set; }
        public List<EditPenaltyTitle> CreatePenaltyTitle { get; set; }

    }
}
