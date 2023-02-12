using _0_Framework_b.Application;
using CompanyManagment.App.Contracts.TaskTitle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Company.TaskManager
{
    public class TaskTitleModel : PageModel
    {
        public List<TaskTitleViewModel> viewModels;

        public ITaskTitleApplication _taskTitleApplication { get; }

        public TaskTitleModel(ITaskTitleApplication taskTitleApplication)
        {
            _taskTitleApplication = taskTitleApplication;
        }


        public void OnGet()
        {
            viewModels = _taskTitleApplication.Search(new TaskTitleSearchModel());
        }

        public IActionResult OnGetCreateOrEditTaskTitle(long? Id)
        {
            var editTaskTitle = new EditTaskTitle();

            if (Id != null)
            {
                editTaskTitle = _taskTitleApplication.GetDetails((long)Id);
            }

            return Partial("CreateOrEditTaskTitle", editTaskTitle);
        }

        public IActionResult OnPostCreateOrEditTaskTitle(EditTaskTitle createTaskTitle)
        {
            var result = new OperationResult();

            if (createTaskTitle.Id == 0)
                result = _taskTitleApplication.Create(createTaskTitle);

            else
            {
                //var task = _taskApplication.GetDetails(createTask.Id);
                result = _taskTitleApplication.Edit(createTaskTitle);
            }

            return new JsonResult(result);
        }
        
        public IActionResult OnPostDeleteTaskTitle(long Id)
        {
            var result = _taskTitleApplication.Remove(Id);

            return new JsonResult(result.Succcedded());
        }
    }
}
