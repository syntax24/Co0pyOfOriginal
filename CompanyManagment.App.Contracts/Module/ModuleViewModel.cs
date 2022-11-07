using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Module
{

    public class ModuleViewModel
    {
        public long Id { get; set; }
        public string NameSubModule { get; set; }

        //public long Id { get; set; }
        //public string Name { get; set; }
        public List<SelectListItem> drpModule { get; set; }

        //[Display(Name = "Subjects")]
        public long[] ModuleIds { get; set; }

    }
}
