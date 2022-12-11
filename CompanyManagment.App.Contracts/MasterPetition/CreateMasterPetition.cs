using System.Collections.Generic;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.MasterPenaltyTitle;
using CompanyManagment.App.Contracts.MasterWorkHistory;

namespace CompanyManagment.App.Contracts.MasterPetition
{
    public class CreateMasterPetition
    {
        public string MasterName { get; set; }
        //public string TotalPenalty { get; set; }
        //public string TotalPenaltyTitles { get; set; }
        public string Description { get; set; }
        public string WorkHistoryDescription { get; set; }
        public int BoardType_Id { get; set; }
        public long File_Id { get; set; }

        public bool BoardProcessingStage { get; set; }
        public EditFile FileData { get; set; }
        public List<EditMasterWorkHistory> CreateMasterWorkHistory { get; set; }
        public List<EditMasterPenaltyTitle> CreateMasterPenaltyTitle { get; set; }

    }
}
