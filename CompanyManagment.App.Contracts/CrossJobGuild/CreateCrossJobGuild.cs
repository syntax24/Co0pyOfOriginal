using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.Employee;

namespace CompanyManagment.App.Contracts.CrossJobGuild
{
	public class CreateCrossJobGuild
	{
        public int Year { get;  set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string Title { get;  set; }
        public string EconomicCode { get;  set; }

        public List<CrossJobViewModel> crossJobsList { get; set; }
        public List<CrossJobViewModel> crossJobsListParent { get; set; }
        public List<EditCrossJob> editcrossJobsList { get; set; }
        public List<string> economicCodeList { get; set; }
    }
}

