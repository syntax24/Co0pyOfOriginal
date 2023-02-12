using _0_Framework.Domain;
using System;

namespace Company.Domain.Task
{
    public class Task : EntityBase
    {
        public Task(long commander_Id, long seniorUser_Id, long taskTitle_Id,
                     string customer, long customer_Id, DateTime? taskDate, string description)
        {
            Commander_Id = commander_Id;
            SeniorUser_Id = seniorUser_Id;
            TaskTitle_Id = taskTitle_Id;
            Customer = customer;
            Customer_Id = customer_Id;
            TaskDate = taskDate;
            Description = description;
        }

        public long Commander_Id { get; private set; }
        public long SeniorUser_Id { get; private set; }
        //public long ReferralRecipient_Id { get; private set; }
        public long TaskTitle_Id { get; private set; }
        public string Customer { get; private set; }
        public long Customer_Id { get; private set; }
        public DateTime? TaskDate { get; private set; }
        public string Description { get; private set; }
        
        
        public TaskStatus.TaskStatus TaskStatus { get; private set; }
        public TaskTitle.TaskTitle TaskTitle { get; private set; }


        public void Edit(long commander_Id, long seniorUser_Id, long taskTitle_Id,
                     string customer, long customer_Id, DateTime? taskDate, string description)
        {
            Commander_Id = commander_Id;
            SeniorUser_Id = seniorUser_Id;
            TaskTitle_Id = taskTitle_Id;
            Customer = customer;
            Customer_Id = customer_Id;
            TaskDate = taskDate;
            Description = description;
        }
    }
}
