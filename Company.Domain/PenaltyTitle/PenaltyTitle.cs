using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.PenaltyTitle
{
    public class PenaltyTitle : EntityBase
    {
        public PenaltyTitle(DateTime? fromDate, DateTime? toDate, string title, string day, long petition_Id, string paidAmount, string remainingAmount)
        {
            FromDate = fromDate;
            ToDate = toDate;
            Title = title;
            Day = day;
            Petition_Id = petition_Id;
            PaidAmount = paidAmount;
            RemainingAmount = remainingAmount;
        }

        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public string Title { get; private set; }
        public string Day { get; private set; }
        public string PaidAmount { get; private set; }
        public string RemainingAmount { get; private set; }
        public long Petition_Id { get; private set; }
        public Petition.Petition Petition { get; private set; }

        public void Edit(DateTime fromDate, DateTime toDate, string title, string day, long petition_Id, string paidAmount, string remainingAmount)
        {
            FromDate = fromDate;
            ToDate = toDate;
            Title = title;
            Day = day;
            PaidAmount = paidAmount;
            RemainingAmount = remainingAmount;
            Petition_Id = petition_Id;
        }
    }
}
