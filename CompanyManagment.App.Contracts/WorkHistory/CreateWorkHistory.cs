namespace CompanyManagment.App.Contracts.WorkHistory
{
    public class CreateWorkHistory
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string WorkingHoursPerDay { get; set; }
        public string WorkingHoursPerWeek { get; set; }
        public string Description { get; set; }
        public long Petition_Id { get; set; }
    }
}
