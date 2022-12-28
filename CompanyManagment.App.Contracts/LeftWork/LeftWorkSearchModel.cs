namespace CompanyManagment.App.Contracts.LeftWork
{
    public class LeftWorkSearchModel
    {
        public string LeftWorkDate { get; set; }
        public string StartWorkDate { get; set; }
        public long WorkshopId { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public string WorkshopName { get; set; }
    }
}