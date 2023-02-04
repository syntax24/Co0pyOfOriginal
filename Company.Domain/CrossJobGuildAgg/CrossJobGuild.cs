using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;
using Company.Domain.CrossJobAgg;
using Company.Domain.EmployeeChildrenAgg;
using Company.Domain.LeftWorkAgg;

namespace Company.Domain.CrossJobGuildAgg
{
    public class CrossJobGuild : EntityBase
    {
        public CrossJobGuild( int year, string title, string economicCode)
        {
            Year = year;
            Title = title;
            EconomicCode = economicCode;
        }

        public int Year { get; private set; }
        public string Title { get; private set; }
        public string EconomicCode { get; private set; }

        public List<CrossJob> CrossJobList { get; private set; }

        public CrossJobGuild()
        {
            CrossJobList = new List<CrossJob>();
        }
        public void Edit(string economicCode, string title, int year)
        {
            Year = year;
            Title = title;
            EconomicCode = economicCode;
        }


    }
}
