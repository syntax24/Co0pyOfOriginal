using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.FileTitle
{
    public class CreateFileTitle
    {
        [Required(ErrorMessage = "فیلد الزامی است")]
        public string Title { get; set; }
        public string Type { get; set; }

    }
}
