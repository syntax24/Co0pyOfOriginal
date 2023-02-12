using AccountManagement.Application.Contracts.Account;
using CompanyManagment.App.Contracts.TaskStatus;
using System;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Task
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
            TaskStatus = new EditTaskStatus();
        }
        public long Id { get; set; }
        public long Commander_Id { get; set; }
        public string CommanderName { get; set; }
        public long SeniorUser_Id { get; set; }
        public string SeniorUserName { get; set; }
        public long ReferralRecipient_Id { get; set; }
        public string ReferralRecipientName { get; set; }
        public long TaskTitle_Id { get; set; }
        public string TaskTitle { get; set; }
        public long Customer_Id { get; set; }
        public string CustomerName { get; set; }
        public string TaskDate { get; set; }
        public DateTime? TaskGDate { get; set; }
        public string Description { get; set; }

        public EditTaskStatus TaskStatus { get; set; }
        
    }
}