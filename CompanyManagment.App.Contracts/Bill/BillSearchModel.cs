namespace CompanyManagment.App.Contracts.Bill
{

    public class BillSearchModel
    {
        public string SubjectBill { get; set; }
        public string Description { get; set; }
        public long Contact_Id { get; set; }
        public long Appointed_Id { get; set; }
        public long ProcessingStage_Id { get; set; }
        public byte Status { get; set; }
        public string Contact { get; set; }   
        public string Appointed { get; set; }
        public string ProcessingStage { get; set; }
      


    }
 
}
