namespace CompanyManagment.App.Contracts.YearlySalaryItems
{
    public class YearlysalaryItemViewModel
    {
        public long Id { get; set; }
        public string ItemName { get; set; }

        public double ItemValue { get; set; }
        public string ValueType { get; set; }
        public int ParentConnectionId { get; set; }
        public long YearlySalaryId { get; set; }
    }
}