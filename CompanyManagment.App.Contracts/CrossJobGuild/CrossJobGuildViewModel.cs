using System;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Employee;

namespace CompanyManagment.App.Contracts.CrossJobGuild
{
    public class CrossJobGuildViewModel
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string EconomicCode { get; set; }
    }
}

