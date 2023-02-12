
using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.TaskTitle
{
    public class CreateTaskTitle
    {
        [Required(ErrorMessage = "وارد کردن عنوان الزامیست")]
        public string Title { get; set; }


    }
}
