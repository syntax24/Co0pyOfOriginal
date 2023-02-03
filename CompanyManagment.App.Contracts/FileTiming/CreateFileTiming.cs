using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.FileTiming
{
    public class CreateFileTiming
    {
        [Required(ErrorMessage = "فیلد الزامی است")]
        [Range(1, 100, ErrorMessage = "حداقل مقدار قابل قبول برابر 1 است")]
        public int Deadline { get; set; }
        public string Title { get; set; }
        public string Tips { get; set; }

    }
}
