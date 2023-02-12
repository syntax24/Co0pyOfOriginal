using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using AccountManagement.Application.Contracts.Account;
using AccountMangement.Infrastructure.EFCore;
using Company.Domain.File1;
using Company.Domain.Task;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.Task;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class TaskRepository : RepositoryBase<long, Task>, ITaskRepository
    {
        private readonly CompanyContext _context;

        public TaskRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public void Remove(long id)
        {
            var task = Get(id);

            Remove(task);

            SaveChanges();
        }

        public List<TaskViewModel> Search(TaskSearchModel searchModel)
        {
            var query = _context.Tasks.Select(x => new TaskViewModel
            {
                Id = x.id,
                Commander_Id = x.Commander_Id,
                SeniorUser_Id = x.SeniorUser_Id,
                Customer_Id = x.Customer_Id,
                CustomerName = x.Customer,
                TaskTitle_Id = x.TaskTitle_Id,
                Description = x.Description,
                TaskDate = x.TaskDate.ToFarsi(),
                TaskGDate = x.TaskDate
            });

            if (searchModel.RoleId != 1)
            {
                query = query.Where(x => x.SeniorUser_Id == searchModel.AccountId || x.ReferralRecipient_Id == searchModel.AccountId);
            }

            return query.OrderByDescending(x => x.TaskGDate).ToList();
        }

        public void UpdateTask(Task editTask)
        {
            //var task = Get(editTask.id);

            //task.Edit(editTask.Commander_Id, editTask.SeniorUser_Id, editTask.TaskTitle_Id, editTask.Customer, editTask.Customer_Id, editTask.TaskDate.ToGeorgianDateTime(), editTask.Description);

            //SaveChanges();
        }
    }
}
