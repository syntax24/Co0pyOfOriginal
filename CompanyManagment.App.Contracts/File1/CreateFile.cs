using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;

namespace CompanyManagment.App.Contracts.File1
{
    public class CreateFile
    {
        [Required(ErrorMessage = "فیلد الزامی است")]
        [Range(0, int.MaxValue, ErrorMessage = "لطفا عدد وارد کنید")]
        public long ArchiveNo { get; set; }

        [Required(ErrorMessage = "فیلد الزامی است")]
        public string ClientVisitDate { get; set; }

        [Required(ErrorMessage = "فیلد الزامی است")]
        public string ProceederReference { get; set; }

        [Required(ErrorMessage = "فیلد الزامی است")]
        public long Reqester { get; set; }

        [Required(ErrorMessage = "فیلد الزامی است")]
        public long Summoned { get; set; }

        [Required(ErrorMessage = "فیلد الزامی است")]
        public int Client { get; set; }

        public string ClientFullName { get; set; }
        public string OppositePersonFullName { get; set; }


        public string FileClass { get; set; }

        [Required(ErrorMessage = "فیلد الزامی است")]
        public int HasMandate { get; set; }

        public int Status { get; set; } = 2;


        public string Description { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public List<EmployerViewModel> Employers { get; set; }
    }
}
