using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagment.App.Contracts.Workshop;

namespace CompanyManagment.App.Contracts.LeftWork
{
    public class CreateLeftWork
    {
      
        public string LeftWorkDate { get; set; }
        public string StartWorkDate { get; set; }
        [Required(ErrorMessage = "انتخاب کارگاه ضروری است")]
        public long WorkshopId { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public string WorkshopName { get; set; }
        public List<LeftWorkViewModel> LeftWorkSearch{ get; set; }
        public List<WorkshopViewModel> Workshops { get; set; }
    }
}
