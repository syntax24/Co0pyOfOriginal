using CompanyManagment.App.Contracts.Job;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.CrossJobItems
{
    public class CreateCrossJobItems
    {
        public long crossJobId { get; set; }
        public long jobId { get; set; }
        public JobViewModel job { get; set; }


    }
}

