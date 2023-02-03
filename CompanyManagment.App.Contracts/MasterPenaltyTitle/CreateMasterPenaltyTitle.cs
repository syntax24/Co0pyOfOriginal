namespace CompanyManagment.App.Contracts.MasterPenaltyTitle
{
    public class CreateMasterPenaltyTitle
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Title { get; set; }
        public string Day { get; set; }
        public long MasterPetition_Id { get; set; }
        public string PaidAmount { get; set; }
        public string RemainingAmount { get; set; }

    }
}
