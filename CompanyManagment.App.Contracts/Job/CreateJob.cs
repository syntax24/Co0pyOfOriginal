using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.Job    
{
    public class CreateJob
    {
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]

        public string JobCode { get; set; }
    }
}
