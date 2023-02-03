using System;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.CrossJobGuild;


namespace CompanyManagment.App.Contracts.CrossJob
{
    public class CrossJobViewModel
    {
        public long Id { get; set; }
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

