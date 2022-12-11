using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.MasterWorkHistory
{
    public class MasterWorkHistory : EntityBase
    {
        public MasterWorkHistory(DateTime fromDate, DateTime toDate, int? workingHoursPerDay, int? workingHoursPerWeek, string description, long masterPetition_Id)
        {
            FromDate = fromDate;
            ToDate = toDate;
            WorkingHoursPerDay = workingHoursPerDay;
            WorkingHoursPerWeek = workingHoursPerWeek;
            Description = description;
            MasterPetition_Id = masterPetition_Id;
        }

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public int? WorkingHoursPerDay { get; private set; }
        public int? WorkingHoursPerWeek { get; private set; }
        public string Description { get; private set; }
        public long MasterPetition_Id { get; private set; }

        public MasterPetition.MasterPetition MasterPetition { get; private set; }

        public void Edit(DateTime fromDate, DateTime toDate, int workingHoursPerDay, int workingHoursPerWeek, string description, long masterPetition_Id)
        {
            FromDate = fromDate;
            ToDate = toDate;
            WorkingHoursPerDay = workingHoursPerDay;
            WorkingHoursPerWeek = workingHoursPerWeek;
            Description = description;
            MasterPetition_Id = masterPetition_Id;
        }
    }
}