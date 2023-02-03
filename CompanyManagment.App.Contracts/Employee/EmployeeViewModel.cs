namespace CompanyManagment.App.Contracts.Employee
{
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EmployeeFullName { get; set; }
        public string FatherName { get; set; }

        public string DateOfBirth { get; set; }

        public string DateOfIssue { get; set; }

        public string PlaceOfIssue { get; set; }
        public string NationalCode { get; set; }

        public string IdNumber { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string MaritalStatus { get; set; }
        public string MilitaryService { get; set; }
        public string LevelOfEducation { get; set; }
        public string FieldOfStudy { get; set; }
        public string BankCardNumber { get; set; }
        public string BankBranch { get; set; }
        public string InsuranceCode { get; set; }
        public string InsuranceHistoryByYear { get; set; }
        public string InsuranceHistoryByMonth { get; set; }
        public string NumberOfChildren { get; set; }
        public string IsActiveString { get; set; }
        public string OfficePhone { get; set; }
        public bool IsActive { get; set; }
     
    }
}