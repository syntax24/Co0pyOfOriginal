
using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.Task
{
    public class CreateTask
    {
        public long Commander_Id { get; set; }

        [Required(ErrorMessage = "انتخاب کاربر الزامی است")]
        public long SeniorUser_Id { get; set; }
        //public long ReferralRecipient_Id { get; set; }

        [Required(ErrorMessage = "انتخاب عنوان وظیفه الزامی است")]
        public long TaskTitle_Id { get; set; }
        public string Customer { get; set; }
        public long Customer_Id { get; set; }
        public string TaskDate { get; set; }
        public string TaskFromDate { get; set; }
        public int TaskDuration { get; set; }
        public string Description { get; set; }
        public bool IsEditMode { get; set; }


        //public TaskStatus. TaskStatus { get; private set; }
        //public TaskTitle.TaskTitle TaskTitle { get; private set; }
    }
}
