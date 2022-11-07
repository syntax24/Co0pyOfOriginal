namespace CompanyManagment.App.Contracts.WorkingHoursItems
{
    public class CreateWorkingHoursItems
    {
        public string DayOfWork { get; set; }
        public string Start1 { get; set; }
        public string End1 { get; set; }
        public string RestTime { get; set; }
        public string Start2 { get; set; }
        public string End2 { get; set; }
        public string Start3 { get; set; }
        public string End3 { get; set; }
        public string ComplexStart { get; set; }
        public string ComplexEnd { get; set; }
        public long WorkingHoursId { get; set; }
    }
}
