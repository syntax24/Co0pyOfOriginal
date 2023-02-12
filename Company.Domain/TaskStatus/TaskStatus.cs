using _0_Framework.Domain;
using CompanyManagment.App.Contracts.TaskStatus;
using System;

namespace Company.Domain.TaskStatus
{
    public class TaskStatus : EntityBase
    {
        public TaskStatus
        (
            short referralStatus, 
            long referralUserId, 
            DateTime? referralRegDate, 
            long referralRegUserId, 
            short deadlineExtentionStatus,
            DateTime? deadlineExtentionDate, 
            DateTime? deadlineExtentionRegDate, 
            long deadlineExtentionRegUserId, 
            short impossibilityStatus, 
            string impossibilityDescription, 
            DateTime? impossibilityRegDate, 
            long impossibilityRegUserId, 
            short doneStatus, 
            DateTime? doneRegDate, 
            long doneRegUserId, 
            long task_Id
        )
        {
            ReferralStatus = referralStatus;
            ReferralUserId = referralUserId;
            ReferralRegDate = referralRegDate;
            ReferralRegUserId = referralRegUserId;
            //DeadlineExtention = deadlineExtention;
            DeadlineExtentionStatus = deadlineExtentionStatus;
            DeadlineExtentionDate = deadlineExtentionDate;
            DeadlineExtentionRegDate = deadlineExtentionRegDate;
            DeadlineExtentionRegUserId = deadlineExtentionRegUserId;
            //Impossibility = impossibility;
            ImpossibilityStatus = impossibilityStatus;
            ImpossibilityDescription = impossibilityDescription;
            ImpossibilityRegDate = impossibilityRegDate;
            ImpossibilityRegUserId = impossibilityRegUserId;
            //Done = done;
            DoneStatus = doneStatus;
            DoneRegDate = doneRegDate;
            DoneRegUserId = doneRegUserId;
            Task_Id = task_Id;
        }

        public short ReferralStatus { get; set; }
        public long ReferralUserId { get; private set; }
        public DateTime? ReferralRegDate { get; private set; }
        public long ReferralRegUserId { get; private set; }

        //public int DeadlineExtention { get; private set; }
        public short DeadlineExtentionStatus { get; private set; }
        public DateTime? DeadlineExtentionDate { get; private set; }
        public DateTime? DeadlineExtentionRegDate { get; private set; }
        public long DeadlineExtentionRegUserId { get; private set; }

        //public int Impossibility { get; private set; }
        public short ImpossibilityStatus { get; private set; }
        public string ImpossibilityDescription { get; private set; }
        public DateTime? ImpossibilityRegDate { get; private set; }
        public long ImpossibilityRegUserId { get; private set; }

        //public int Done { get; private set; }
        public short DoneStatus { get; private set; }
        public DateTime? DoneRegDate { get; private set; }
        public long DoneRegUserId { get; private set; }
        public long Task_Id { get; private set; }

        public Task.Task Task { get; private set; }

        public void Edit
        (
            short referralStatus,
            long referralUserId,
            DateTime? referralRegDate,
            long referralRegUserId,
            short deadlineExtentionStatus,
            DateTime? deadlineExtentionDate,
            DateTime? deadlineExtentionRegDate,
            long deadlineExtentionRegUserId,
            short impossibilityStatus,
            string impossibilityDescription,
            DateTime? impossibilityRegDate,
            long impossibilityRegUserId,
            short doneStatus,
            DateTime? doneRegDate,
            long doneRegUserId,
            long task_Id
        )
        {
            ReferralStatus = referralStatus;
            ReferralUserId = referralUserId;
            ReferralRegDate = referralRegDate;
            ReferralRegUserId = referralRegUserId;
            //DeadlineExtention = deadlineExtention;
            DeadlineExtentionStatus = deadlineExtentionStatus;
            DeadlineExtentionDate = deadlineExtentionDate;
            DeadlineExtentionRegDate = deadlineExtentionRegDate;
            DeadlineExtentionRegUserId = deadlineExtentionRegUserId;
            //Impossibility = impossibility;
            ImpossibilityStatus = impossibilityStatus;
            ImpossibilityDescription = impossibilityDescription;
            ImpossibilityRegDate = impossibilityRegDate;
            ImpossibilityRegUserId = impossibilityRegUserId;
            //Done = done;
            DoneStatus = doneStatus;
            DoneRegDate = doneRegDate;
            DoneRegUserId = doneRegUserId;
            Task_Id = task_Id;
        }
    }
}
