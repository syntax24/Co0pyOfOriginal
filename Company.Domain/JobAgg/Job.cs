using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Employer;
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
