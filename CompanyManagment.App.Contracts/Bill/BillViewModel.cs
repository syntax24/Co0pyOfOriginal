
namespace CompanyManagment.App.Contracts.Bill
{

    public class BillViewModel
    {
        public long Id { get; set; }
        public string SubjectBill { get; set; }
        public string Description { get; set; }
        public string Appointed { get; set; }
        public string Contact { get; set; }
        public string ProcessingStage { get; set; }
        public byte Status { get; set; }
    }
}
