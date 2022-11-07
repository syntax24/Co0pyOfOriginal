using _0_Framework.Domain;
using System;

namespace Company.Domain.WorkHistory
{
    public class WorkHistory : EntityBase
    {
        public WorkHistory(DateTime fromDate, DateTime toDate, int? workingHoursPerDay, int? workingHoursPerWeek, string description, long petition_Id)
        {
            FromDate = fromDate;
            ToDate = toDate;
            WorkingHoursPerDay = workingHoursPerDay;
            WorkingHoursPerWeek = workingHoursPerWeek;
            Description = description;
            Petition_Id = petition_Id;
        }

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public int? WorkingHoursPerDay { get; private set; }
        public int? WorkingHoursPerWeek { get; private set; }
        public string Description { get; private set; }
        public long Petition_Id { get; private set; }
        public Petition.Petition Petition { get; set; }

        public void Edit(DateTime fromDate, DateTime toDate, int workingHoursPerDay, int workingHoursPerWeek, string description, long petition_Id)
        {
            FromDate = fromDate;
            ToDate = toDate;
            WorkingHoursPerDay = workingHoursPerDay;
            WorkingHoursPerWeek = workingHoursPerWeek;
            Description = description;
            Petition_Id = petition_Id;
        }
    }
}
