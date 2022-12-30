using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.YearlySalaryAgg;

namespace Company.Domain.YearlySalaryItemsAgg
{
    public class YearlySalaryItem : EntityBase
    {
        public YearlySalaryItem(string itemName, double itemValue, int parentConnectionId, long yearlySalaryId, string valueType)
        {
            ItemName = itemName;
            ItemValue = itemValue;
            ValueType = valueType;
            ParentConnectionId = parentConnectionId;
            YearlySalaryId = yearlySalaryId;
          
        }

        public string ItemName { get; private set; }
        public double ItemValue { get; private set; }
        public string ValueType { get; private set; }
        public int ParentConnectionId { get; private set; }
        public long YearlySalaryId { get; private set; }


        public YearlySalary YearlySalary { get; private set; }

        public void Edit(string itemName, double itemValue, int parentConnectionId, long yearlySalaryId, string valueType)
        {
            ItemName = itemName;
            ItemValue = itemValue;
            ValueType = valueType;
            ParentConnectionId = parentConnectionId;
            YearlySalaryId = yearlySalaryId;
          
        }
    }
}
