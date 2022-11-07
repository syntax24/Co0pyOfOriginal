using _0_Framework.Domain;


namespace Company.Domain.BillAgg
{
    public class EntityBill : EntityBase
    {
        public EntityBill(string subjectBill, string description, string appointed, string processingStage, string contact, byte status)
        {
            SubjectBill = subjectBill;
            Description = description;
            Appointed = appointed;
            ProcessingStage = processingStage;
            Contact = contact;
            Status = status;
        }
        public string SubjectBill { get; private set; }
        public string Description { get; private set; }
        public string Contact { get; private set; }
        public string Appointed { get; private set; }
        public string ProcessingStage { get; private set; }
        public byte Status { get; private set; }
        public void Edit( string subjectBill, string description, string appointed, string processingStage, string contact, byte status)
        {
            SubjectBill = subjectBill;
            Description = description;
            Appointed = appointed;
            ProcessingStage = processingStage;
            Contact = contact;
            Status = status;
        }
    }
}
