using CompanyManagment.App.Contracts.CrossJobGuild;
using System;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.CrossJob
{
    public class CrossJobSearchModel
    {
        public string Title { get; set; }
        public double SalaryRatioUnder { get; set; }
        public long EquivalentRialUnder { get; set; }
        public double SalaryRatioOver { get; set; }
        public long EquivalentRialOver { get; set; }
        public long CrossJobGuildId { get; set; }
        public CrossJobGuildViewModel CrossJobGuild { get; set; }
        public long parentRowId { get; set; }

    }
}

