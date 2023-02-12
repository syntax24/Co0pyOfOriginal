using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagment.App.Contracts.TaskStatus
{
    public static class TaskStatusEnums
    {
        public const short NOTSET = 0;
        public const short UNAPPROVED = 1;
        public const short REJECTED = 2;
        public const short SENIOR_APPROVAL = 3;
        public const short MANAGER_APPROVAL = 4;
        public const short ALL = 5;

        //public const short UNDONE = 5;
        //public const short DONE = 6;
        //public const short DONE_OR_UNDONE = 7;
    }
}
