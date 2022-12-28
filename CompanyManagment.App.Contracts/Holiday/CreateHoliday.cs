using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Holiday
{
    public class CreateHoliday
    {
        public string Year { get; set; }

        public List<string> PersiandatesList { get; set; }
        public List<string> PersiandatesList2 { get; set; }

    }
}
