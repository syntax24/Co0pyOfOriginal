using AccountManagement.Application.Contracts.Account;
using CompanyManagment.App.Contracts.TaskTitle;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Task
{
    public class TaskSearchModel
    {
        public long AccountId { get; set; }
        public long RoleId { get; set; }
        public long Commander_Id { get; set; }
        public long SeniorUser_Id { get; set; }
        public long TaskTitle_Id { get; set; }
        public string Customer { get; set; }
        public string TaskDateFrom { get; set; }
        public string TaskDateTo { get; set; }
        public short ReferralStatus { get; set; }
        public short DeadlineExtensionStatus { get; set; }
        public short ImpossibilityStatus { get; set; }
        public short DoneStatus { get; set; }
        public string Description { get; set; }

        public List<AccountViewModel> Commanders { get; set; }
        public List<AccountViewModel> SeniorUsers { get; set; }
        public List<TaskTitleViewModel> TaskTitles { get; set; }
    }
}