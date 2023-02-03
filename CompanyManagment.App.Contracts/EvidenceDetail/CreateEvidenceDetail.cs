namespace CompanyManagment.App.Contracts.EvidenceDetail
{
    public class CreateEvidenceDetail
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Title { get; set; }
        public string Day { get; set; }
        public long Evidence_Id { get; set; }
        public string Description { get; set; }

    }
}
