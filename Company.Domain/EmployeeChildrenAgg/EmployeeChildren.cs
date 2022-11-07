using System;
using _0_Framework.Domain;
using Company.Domain.EmployeeAgg;

namespace Company.Domain.EmployeeChildrenAgg
{
    public class EmployeeChildren : EntityBase
    {
        public EmployeeChildren(string fName, DateTime dateOfBirth, string parentNationalCode, long employeeId)
        {
            FName = fName;
            DateOfBirth = dateOfBirth;
            ParentNationalCode = parentNationalCode;
            EmployeeId = employeeId;
        }

        public string FName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string ParentNationalCode { get; private set; }
        public long EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
       

        public void Edit(string fName, DateTime dateOfBirth, string parentNationalCode, long employeeId)
        {
            FName = fName;
            DateOfBirth = dateOfBirth;
            ParentNationalCode = parentNationalCode;
            EmployeeId = employeeId;
            
        }
    }
}
