using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.MasterPenaltyTitle
{
    public class MasterPenaltyTitle : EntityBase
    {
        public MasterPenaltyTitle(DateTime? fromDate, DateTime? toDate, string title, string day, long masterPetition_Id, string paidAmount, string remainingAmount)
        {
            FromDate = fromDate;
            ToDate = toDate;
            Title = title;
            Day = day;
            MasterPetition_Id = masterPetition_Id;
            PaidAmount = paidAmount;
            RemainingAmount = remainingAmount;
        }

        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public string Title { get; private set; }
        public string Day { get; private set; }
        public string PaidAmount { get; private set; }
        public string RemainingAmount { get; private set; }
        public long MasterPetition_Id { get; private set; }

        public MasterPetition.MasterPetition MasterPetition { get; private set; }

        public void Edit(DateTime fromDate, DateTime toDate, string title, string day, long masterPetition_Id, string paidAmount, string remainingAmount)
        {
            FromDate = fromDate;
            ToDate = toDate;
            Title = title;
            Day = day;
            PaidAmount = paidAmount;
            RemainingAmount = remainingAmount;
            MasterPetition_Id = masterPetition_Id;
        }
    }
}