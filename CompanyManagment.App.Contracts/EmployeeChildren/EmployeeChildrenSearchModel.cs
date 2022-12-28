using System;

namespace CompanyManagment.App.Contracts.EmployeeChildren
{
    public class EmployeeChildrenSearchModel
    {
        public string FName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long EmployeeId { get; set; }
    }
}