using System;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Employee;

namespace CompanyManagment.App.Contracts.CrossJobGuild
{
    public class CrossJobGuildSearchModel
    {
        public long id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string EconomicCode { get; set; }
    }
}

