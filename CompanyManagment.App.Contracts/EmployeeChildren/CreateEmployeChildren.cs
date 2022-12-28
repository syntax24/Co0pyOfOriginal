namespace CompanyManagment.App.Contracts.EmployeeChildren
{
    public class CreateEmployeChildren
    {
        public string FName { get; set; }
        public string DateOfBirth { get; set; }
        public string ParentNationalCode { get; set; }
        public long EmployeeId { get; set; }
        public bool IsRemoved { get; set; }
    }
}
