namespace CompanyManagment.App.Contracts.Employee
{
    public class EmployeeSearchModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string NationalCode { get; set; }

        public string EmployeeFullName { get; set; }
        public string IdNumber { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string LevelOfEducation { get; set; }

        public bool IsActive { get; private set; }
        public string IsActiveString { get; set; }
    }
}