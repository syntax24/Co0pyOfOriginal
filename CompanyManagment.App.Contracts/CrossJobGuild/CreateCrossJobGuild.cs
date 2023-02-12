using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobItems;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Job;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagment.App.Contracts.CrossJobGuild
{
	public class CreateCrossJobGuild
	{
        public int Year { get;  set; }
        [Required(ErrorMessage = "این مقدار نمی تواند خالی باشد")]
        public string Title { get;  set; }
        public string EconomicCode { get;  set; }

        public List<CrossJobViewModel> crossJobsList { get; set; }
        public List<CrossJobItemsViewModel> crossJobItemsList { get; set; }
        public List<CrossJobViewModel> crossJobsListParent { get; set; }
        public List<EditCrossJob> editcrossJobsList { get; set; }
        public List<string> economicCodeList { get; set; }
        public SelectList jobs { get; set; }

    }
}

