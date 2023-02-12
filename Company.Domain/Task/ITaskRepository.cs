using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Task;

namespace Company.Domain.Task
{
    public interface ITaskRepository : IRepository<long, Task>
    {
        List<TaskViewModel> Search(TaskSearchModel searchModel);
        void Remove(long id);
        void UpdateTask(Task task);
    }
}
