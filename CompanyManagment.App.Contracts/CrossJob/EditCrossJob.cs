using System;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Employee;

namespace CompanyManagment.App.Contracts.CrossJob
{

    public class EditCrossJob : CreateCrossJob
    {
        public long Id { get; set; }
        //public List<long> SelectedValues { get; set; }

    }
}

