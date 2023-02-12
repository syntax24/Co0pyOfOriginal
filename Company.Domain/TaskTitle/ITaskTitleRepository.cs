using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.TaskTitle;

namespace Company.Domain.TaskTitle
{
    public interface ITaskTitleRepository : IRepository<long, TaskTitle>
    {
        List<TaskTitleViewModel> Search(TaskTitleSearchModel searchModel);
        public EditTaskTitle GetDetails(long id);
    }
}
