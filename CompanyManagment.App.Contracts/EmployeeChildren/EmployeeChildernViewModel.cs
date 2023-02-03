namespace CompanyManagment.App.Contracts.EmployeeChildren
{
    public class EmployeeChildernViewModel
    {
        public long Id { get; set; }
        public string FName { get; set; }
        public string DateOfBirth { get; set; }
        public string ParentNationalCode { get; set; }
        public long EmployeeId { get; set; }
        public bool IsRemoved { get; set; }
    }
}