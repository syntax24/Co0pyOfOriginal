
using System;

namespace CompanyManagment.App.Contracts.TaskStatus
{
    public class CreateTaskStatus
    {
        public short ReferralStatus { get; set; }
        public DateTime? ReferralRegDate { get; set; }
        public long ReferralUserId { get; set; }
        public string ReferralUserFullName { get; set; }
        public long ReferralRegUserId { get; set; }
        public string ReferralRegUserFullName { get; set; }
        public short DeadlineExtentionStatus { get; set; }
        public DateTime? DeadlineExtentionDate { get; set; }
        public string DeadlineExtentionFarsiDate { get; set; }
        public DateTime? DeadlineExtentionRegDate { get; set; }
        public long DeadlineExtentionRegUserId { get; set; }
        public string DeadlineExtentionRegUserFullName { get; set; }
        public short ImpossibilityStatus { get; set; }
        public string ImpossibilityDescription { get; set; }
        public DateTime? ImpossibilityRegDate { get; set; }
        public long ImpossibilityRegUserId { get; set; }
        public string ImpossibilityRegUserFullName { get; set; }
        public short DoneStatus { get; set; }
        public DateTime? DoneRegDate { get; set; }
        public long DoneRegUserId { get; set; }
        public string DoneRegUserFullName { get; set; }
        public long Task_Id { get; set; }
        public bool IsApproval { get; set; }
        public bool Approval { get; set; }




        //public Task.Task Task { get; set; }
    }
}
