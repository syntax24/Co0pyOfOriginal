using System;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.CrossJobGuild;
using CompanyManagment.App.Contracts.Job;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyManagment.App.Contracts.CrossJob
{
    public class CrossJobViewModel
    {
        public long Id { get; set; }
        public double SalaryRatioUnder { get; set; }
        public long EquivalentRialUnder { get; set; }
        public double SalaryRatioOver { get; set; }
        public long EquivalentRialOver { get; set; }
        public long CrossJobGuildId { get; set; }
        public CrossJobGuildViewModel CrossJobGuild { get; set; }
        public long[] jobItems { get; set; }
        public JobViewModel job { get; set; }

        public List<long> SelectedValues { get; set; }


    }
}

