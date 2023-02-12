using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.TaskStatus;

namespace Company.Domain.TaskStatus
{
    public interface ITaskStatusRepository : IRepository<long, TaskStatus>
    {
        List<EditTaskStatus> Search(TaskStatusSearchModel searchModel);

        void CreateOrUpdateTaskStatus(EditTaskStatus editTaskStatus);
    }
}
