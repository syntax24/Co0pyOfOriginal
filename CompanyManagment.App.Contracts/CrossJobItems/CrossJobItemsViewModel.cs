using System;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobGuild;
using CompanyManagment.App.Contracts.Job;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagment.App.Contracts.CrossJobItems
{
    public class CrossJobItemsViewModel
    {
        public long Id { get; set; }
        public long crossJobId { get; set; }
        public long[] jobItems { get; set; }
        public long jobId { get; set; }
        public JobViewModel job { get; set; }
        public CrossJobViewModel crossJob { get; set; }

        public List<long> SelectedValues { get; set; }


    }
}

