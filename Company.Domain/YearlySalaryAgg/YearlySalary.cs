using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;
using Company.Domain.YearlySalaryItemsAgg;

namespace Company.Domain.YearlySalaryAgg
{
    public class YearlySalary : EntityBase
    {
        public YearlySalary(DateTime startDate, DateTime endDate,int connectionId)
        {
            StartDate = startDate;
            EndDate = endDate;
            Year = startDate.ToFarsiYear();
            ConnectionId = connectionId;

        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Year { get; private set; }
        public int ConnectionId { get; private set; }
        public List<YearlySalaryItem> YearlySalaryItemsList { get; private set; }
        public List<Contract> Contracts { get; private set; }

        public YearlySalary()
        {
            YearlySalaryItemsList = new List<YearlySalaryItem>();
            Contracts = new List<Contract>();
        }


        public void Edit(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Year = startDate.ToFarsiYear();
        }
    }
}
