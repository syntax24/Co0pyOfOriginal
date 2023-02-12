using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobGuild;
using System;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.CrossJobItems
{
    public class CrossJobItemsSearchModel
    {
        public CrossJobViewModel CrossJob { get; set; }
        public long crossJobId { get; set; }
        public long jobId { get; set; }


    }
}

