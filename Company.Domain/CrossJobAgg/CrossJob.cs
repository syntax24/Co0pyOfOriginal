using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;
using Company.Domain.CrossJobGuildAgg;
using Company.Domain.EmployeeChildrenAgg;
using Company.Domain.LeftWorkAgg;

namespace Company.Domain.CrossJobAgg
{
    public class CrossJob : EntityBase
    {
        public CrossJob(string title, double salaryRatioUnder, long equivalentRialUnder, double salaryRatioOver, long equivalentRialOver, long crossJobGuildId, long parentRowId)
        {
            Title = title;
            SalaryRatioUnder = salaryRatioUnder;
            EquivalentRialUnder = equivalentRialUnder;
            SalaryRatioOver = salaryRatioOver;
            EquivalentRialOver = equivalentRialOver;
            CrossJobGuildId = crossJobGuildId;
            ParentRowId = parentRowId;
        }

        public string Title { get; private set; }
        public double SalaryRatioUnder { get; private set; }
        public long EquivalentRialUnder { get; private set; }
        public double SalaryRatioOver { get; private set; }
        public long EquivalentRialOver { get; private set; }
        public long CrossJobGuildId { get; private set; }
        public long ParentRowId { get; private set; }

        public CrossJobGuild CrossJobGuild { get; private set; }


        public void Edit(string title, double salaryRatioUnder, long equivalentRialUnder, double salaryRatioOver, long equivalentRialOver, long crossJobGuildId, long parentRowId)
        {
            Title = title;
            SalaryRatioUnder = salaryRatioUnder;
            EquivalentRialUnder = equivalentRialUnder;
            SalaryRatioOver = salaryRatioOver;
            EquivalentRialOver = equivalentRialOver;
            CrossJobGuildId = crossJobGuildId;
            ParentRowId = parentRowId;
        }


    }
}
