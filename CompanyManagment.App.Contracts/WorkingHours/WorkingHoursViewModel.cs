namespace CompanyManagment.App.Contracts.WorkingHours
{
    public class WorkingHoursViewModel
    {
        public long Id { get; set; }
        public string ShiftWork { get; set; }
        public string ContractNo { get; set; }
        public string NumberOfWorkingDays { get; set; }
        public string NumberOfFriday { get; set; }
        public string TotalHoursesH { get; set; }
        public string TotalHoursesM { get; set; }
        public string OverTimeWorkH { get; set; }
        public string OverTimeWorkM { get; set; }
        public string OverNightWorkH { get; set; }
        public string OverNightWorkM { get; set; }
        public string WeeklyWorkingTime { get; set; }
        public long ContractId { get; set; }
    }
}