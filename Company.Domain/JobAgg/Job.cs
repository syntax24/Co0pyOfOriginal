using System.Collections.Generic;
using _0_Framework.Domain;
using Contract = Company.Domain.ContractAgg.Contract;

namespace Company.Domain.JobAgg
{
    public class Job : EntityBase
    {
        public Job(string jobName, string jobCode)
        {
            JobName = jobName;
            JobCode = jobCode;
        }

        public string JobName { get; private set; }
        public string JobCode { get; private set; }
        public List<Contract> ContractsList { get; private set; }

        public Job()
        {
            ContractsList = new List<Contract>();
        }

        public void Edit(string jobName, string jobCode)
        {
            JobName = jobName;
            JobCode = jobCode;
        }
    }
}
