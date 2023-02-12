using AccountManagement.Application.Contracts.Account;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.TaskTitle;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Task
{
    public class EditTask : CreateTask
    {
        public long Id { get; set; }
        //List<EmployeeViewModel> Commanders { get; set; }
        public List<AccountViewModel> SeniorUsers { get; set; }
        public List<EmployerViewModel> Customers { get; set; }
        //List<EmployeeViewModel> ReferralRecipients { get; set; }
        public List<TaskTitleViewModel> TaskTitles { get; set; }
    }
}