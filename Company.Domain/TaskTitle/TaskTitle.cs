using _0_Framework.Domain;
using System.Collections.Generic;

namespace Company.Domain.TaskTitle
{
    public class TaskTitle : EntityBase
    {
        public TaskTitle(string title)
        {
            Title = title;

            TasksList = new List<Task.Task>();
        }

        public string Title { get; private set; }

        public List<Task.Task> TasksList { get; private set; }
        //public TaskStatus.TaskStatus TaskStatus { get; private set; }

        public void Edit(string title)
        {
            Title = title;
        }
    }
}
