using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;
using Company.Domain.CrossJobAgg;
using Company.Domain.CrossJobGuildAgg;
using Company.Domain.EmployeeChildrenAgg;
using Company.Domain.JobAgg;
using Company.Domain.LeftWorkAgg;

namespace Company.Domain.CrossJobItemsAgg
{
    public class CrossJobItems : EntityBase
    {
        public CrossJobItems(long crossJobId,long jobId)
        {
            CrossJobId = crossJobId; 
            JobId = jobId;
        }

        public long CrossJobId { get; private set; }
        public long JobId { get; set; }

        public CrossJob CrossJob { get; private set; }
        public Job Job { get; private set; }


        public void Edit(long crossJobId,long jobId)
        {
            JobId = jobId;
            CrossJobId = crossJobId;
        }


    }
}
