using CompanyManagment.App.Contracts.MasterPetition;

namespace CompanyManagment.App.Contracts.File1
{
    public class FileSummary
    {
        public EditFile File { get; set; }
        public EditMasterPetition DiagnosisMasterPetition { get; set; }
        public EditMasterPetition DisputeResolutionMasterPetition { get; set; }
    }
}
